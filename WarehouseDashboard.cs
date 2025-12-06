using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace ASM_Final
{
    public partial class WarehouseDashboard : Form
    {
        // Declare connection object
        SqlConnection conn;

        public WarehouseDashboard()
        {
            InitializeComponent();
            conn = new SqlConnection(DbHelper.ConnectionString);
        }

        private void WarehouseDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. UI Configuration: Prevent manual ID editing
                txtProductID.ReadOnly = true;

                // Disable typing in Category/Supplier ID ComboBoxes
                cbCategoryID.Enabled = false;
                cbSupplierID.Enabled = false;

                // 2. Load initial data
                FillProductsData();
                FillCategoryData();
                FillSuppliersData();

                // 3. Load ComboBoxes for Product tab (For selection when adding/updating products)
                LoadComboboxesForProductTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Initialization error: " + ex.Message);
            }
        }

        // ================================================================
        // HELPER METHODS
        // ================================================================
        private void ExecuteQuery(string sql, Action<SqlCommand> addParams, string successMessage)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (addParams != null) addParams(cmd);
                    cmd.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(successMessage))
                    MessageBox.Show(successMessage, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                // Error 547: Foreign Key Constraint (e.g., deleting a Category that has Products)
                if (sqlEx.Number == 547)
                    MessageBox.Show("This data is currently in use (constraint violation) and cannot be deleted!", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("SQL Error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        // ================================================================
        // 1. MANAGE PRODUCTS (PRODUCT TAB)
        // ================================================================

        private void FillProductsData(string search = "")
        {
            string sql = @"SELECT p.ProductID, p.ProductName, p.StockQuantity, 
                                  c.CategoryName, s.SupplierName,
                                  p.CategoryID, p.SupplierID 
                           FROM tblProducts p
                           LEFT JOIN tblCategory c ON p.CategoryID = c.CategoryID
                           LEFT JOIN tblSuppliers s ON p.SupplierID = s.SupplierID";

            if (!string.IsNullOrEmpty(search)) sql += " WHERE p.ProductName LIKE @search";

            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            if (!string.IsNullOrEmpty(search)) adp.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grvProducts.DataSource = tbl;
        }

        private void LoadComboboxesForProductTab()
        {
            // Load Category into ComboBox
            SqlDataAdapter daCat = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM tblCategory", conn);
            DataTable dtCat = new DataTable();
            daCat.Fill(dtCat);
            cbCategory.DataSource = dtCat;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";
            cbCategory.SelectedIndex = -1;

            // Load Supplier into ComboBox
            SqlDataAdapter daSup = new SqlDataAdapter("SELECT SupplierID, SupplierName FROM tblSuppliers", conn);
            DataTable dtSup = new DataTable();
            daSup.Fill(dtSup);
            cbSupplier.DataSource = dtSup;
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierID";
            cbSupplier.SelectedIndex = -1;
        }

        private void ClearProductInputs()
        {
            txtProductID.Clear(); txtName.Clear(); txtQualitiInStock.Clear();
            cbCategory.SelectedIndex = -1;
            cbSupplier.SelectedIndex = -1;
        }

        private void btAdd_Product_Click(object sender, EventArgs e)
        {
            // --- VALIDATION ---
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter product name!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            int quantity;
            if (!int.TryParse(txtQualitiInStock.Text, out quantity)) // Check if integer
            {
                MessageBox.Show("Stock quantity must be a valid integer!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (quantity < 0) { MessageBox.Show("Quantity cannot be negative!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (cbCategory.SelectedValue == null || cbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please select Category and Supplier!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            // --- INSERT ---
            string sql = "INSERT INTO tblProducts (ProductName, StockQuantity, CategoryID, SupplierID) VALUES (@name, @qty, @cid, @sid)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@cid", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", cbSupplier.SelectedValue);
            }, "Product added to warehouse successfully!");

            FillProductsData(); ClearProductInputs();
        }

        private void btUpdate_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text)) { MessageBox.Show("Please select a product to update!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // --- VALIDATION ---
            int quantity;
            if (!int.TryParse(txtQualitiInStock.Text, out quantity))
            {
                MessageBox.Show("Stock quantity must be an integer!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (quantity < 0) { MessageBox.Show("Quantity cannot be negative!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // --- UPDATE ---
            string sql = "UPDATE tblProducts SET ProductName=@name, StockQuantity=@qty, CategoryID=@cid, SupplierID=@sid WHERE ProductID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@cid", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", cbSupplier.SelectedValue);
                cmd.Parameters.AddWithValue("@id", txtProductID.Text);
            }, "Warehouse updated successfully!");

            FillProductsData(); ClearProductInputs();
        }

        private void btDelete_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text)) return;
            if (MessageBox.Show("Delete this product from warehouse?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblProducts WHERE ProductID=@id";
                ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@id", txtProductID.Text), "Product deleted!");
                FillProductsData(); ClearProductInputs();
            }
        }

        private void grvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grvProducts.Rows[e.RowIndex];
                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtName.Text = row.Cells["ProductName"].Value.ToString();
                txtQualitiInStock.Text = row.Cells["StockQuantity"].Value.ToString();

                if (row.Cells["CategoryID"].Value != DBNull.Value)
                    cbCategory.SelectedValue = row.Cells["CategoryID"].Value;

                if (row.Cells["SupplierID"].Value != DBNull.Value)
                    cbSupplier.SelectedValue = row.Cells["SupplierID"].Value;
            }
        }
        private void btRefresh_Product_Click(object sender, EventArgs e) { FillProductsData(); ClearProductInputs(); }
        private void txtSearch_Product_TextChanged(object sender, EventArgs e) { FillProductsData(txtSearch_Product.Text); }


        // ================================================================
        // 2. MANAGE CATEGORY (CATEGORY TAB)
        // ================================================================

        private void FillCategoryData(string search = "")
        {
            string sql = "SELECT * FROM tblCategory";
            if (!string.IsNullOrEmpty(search)) sql += " WHERE CategoryName LIKE @search";

            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            if (!string.IsNullOrEmpty(search)) adp.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grvCategory.DataSource = tbl;
        }

        private void btAdd_Category_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbCategoryName.Text)) { MessageBox.Show("Enter category name!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sql = "INSERT INTO tblCategory (CategoryName) VALUES (@name)";
            ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@name", cbCategoryName.Text), "Category added successfully!");

            FillCategoryData();
            LoadComboboxesForProductTab(); // Update ComboBox in Product tab
            cbCategoryID.Text = ""; cbCategoryName.Text = "";
        }

        private void btUpdate_Category_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCategoryID.Text)) { MessageBox.Show("Select a category to update!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sql = "UPDATE tblCategory SET CategoryName=@name WHERE CategoryID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", cbCategoryName.Text);
                cmd.Parameters.AddWithValue("@id", cbCategoryID.Text);
            }, "Category updated successfully!");

            FillCategoryData();
            LoadComboboxesForProductTab(); // Data synchronization
        }

        private void btDelete_Category_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCategoryID.Text)) return;
            if (MessageBox.Show("Delete this category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblCategory WHERE CategoryID=@id";
                ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@id", cbCategoryID.Text), "Category deleted!");
                FillCategoryData();
                LoadComboboxesForProductTab(); // Data synchronization
                cbCategoryID.Text = ""; cbCategoryName.Text = "";
            }
        }

        private void grvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grvCategory.Rows[e.RowIndex];
                cbCategoryID.Text = row.Cells["CategoryID"].Value.ToString();
                cbCategoryName.Text = row.Cells["CategoryName"].Value.ToString();
            }
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e) { FillCategoryData(txtCategoryName.Text); }
        private void btRefresh_Category_Click(object sender, EventArgs e) { FillCategoryData(); cbCategoryID.Text = ""; cbCategoryName.Text = ""; }


        // ================================================================
        // 3. MANAGE SUPPLIER (SUPPLIER TAB)
        // ================================================================

        private void FillSuppliersData(string search = "")
        {
            string sql = "SELECT * FROM tblSuppliers";
            if (!string.IsNullOrEmpty(search)) sql += " WHERE SupplierName LIKE @search";

            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            if (!string.IsNullOrEmpty(search)) adp.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgvSupplier.DataSource = tbl;
        }

        private void btAdd_Supplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbSupplierName.Text)) { MessageBox.Show("Enter supplier name!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sql = "INSERT INTO tblSuppliers (SupplierName, SupplierPhone) VALUES (@name, @phone)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", cbSupplierName.Text);
                cmd.Parameters.AddWithValue("@phone", txtSupplierPhone.Text);
            }, "Supplier added successfully!");

            FillSuppliersData();
            LoadComboboxesForProductTab(); // Data synchronization
            cbSupplierID.Text = ""; cbSupplierName.Text = ""; txtSupplierPhone.Clear();
        }

        private void btUpdate_Supplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbSupplierID.Text)) { MessageBox.Show("Select a supplier to update!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sql = "UPDATE tblSuppliers SET SupplierName=@name, SupplierPhone=@phone WHERE SupplierID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", cbSupplierName.Text);
                cmd.Parameters.AddWithValue("@phone", txtSupplierPhone.Text);
                cmd.Parameters.AddWithValue("@id", cbSupplierID.Text);
            }, "Update successful!");

            FillSuppliersData();
            LoadComboboxesForProductTab(); // Data synchronization
        }

        private void btDelete_Supplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbSupplierID.Text)) return;
            if (MessageBox.Show("Delete this supplier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblSuppliers WHERE SupplierID=@id";
                ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@id", cbSupplierID.Text), "Deleted!");
                FillSuppliersData();
                LoadComboboxesForProductTab(); // Data synchronization
                cbSupplierID.Text = ""; cbSupplierName.Text = ""; txtSupplierPhone.Clear();
            }
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];
                cbSupplierID.Text = row.Cells["SupplierID"].Value.ToString();
                cbSupplierName.Text = row.Cells["SupplierName"].Value.ToString();
                txtSupplierPhone.Text = row.Cells["SupplierPhone"].Value.ToString();
            }
        }

        private void txtSearch_Supplier_TextChanged(object sender, EventArgs e) { FillSuppliersData(txtSearch_Supplier.Text); }
        private void btRefresh_Supplier_Click(object sender, EventArgs e) { FillSuppliersData(); cbSupplierID.Text = ""; cbSupplierName.Text = ""; txtSupplierPhone.Clear(); }

        // ================================================================
        // SYSTEM FUNCTIONS
        // ================================================================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close(); // Close this form to return to Login (since Login opened via ShowDialog)
            }
        }

        private void WarehouseDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Do not use Application.Exit() here to allow returning to Login form
        }

        // Placeholder events to avoid designer errors
        private void tpProduct_Click(object sender, EventArgs e) { }
        private void tpCategory_Click(object sender, EventArgs e) { }
        private void tpSupplier_Click(object sender, EventArgs e) { }
        private void cbSupplierID_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvProducts.Rows.Count == 0)
                {
                    MessageBox.Show("No data available to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save Products Data",
                    FileName = "Products.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Products");
                        for (int i = 0; i < grvProducts.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = grvProducts.Columns[i].HeaderText;
                        }
                        for (int i = 0; i < grvProducts.Rows.Count; i++)
                        {
                            for (int j = 0; j < grvProducts.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = grvProducts.Rows[i].Cells[j].Value?.ToString();
                            }
                        }
                        workbook.SaveAs(saveFileDialog.FileName);
                    }
                    MessageBox.Show("Exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}