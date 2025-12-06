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

namespace ASM_Final
{
    public partial class AdminDashboard : Form
    {
        // Use connection string from DbHelper
        SqlConnection conn;

        public AdminDashboard()
        {
            InitializeComponent();
            conn = new SqlConnection(DbHelper.ConnectionString);
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                // UI Configuration: Prevent manual ID editing
                txtEmployeeID.ReadOnly = true;
                txtCustomerID.ReadOnly = true;
                txtProductID.ReadOnly = true;
                txtOrderID.ReadOnly = true;

                // Disable typing in ID ComboBoxes
                cbSupplierID.Enabled = false;
                cbCategoryID.Enabled = false;

                // Load data for all tabs
                FillEmployeeData();
                FillCustomerData();
                FillSuppliersData();
                FillCategoryData();

                // Load dependent ComboBoxes before loading Product/Order data
                LoadProductComboboxes();
                LoadOrderComboboxes();

                FillProductsData();
                FillOrderData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing data: " + ex.Message);
            }
        }

        // =============================================================
        // HELPER METHODS
        // =============================================================
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
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint error
                    MessageBox.Show("This data is currently used in another table (e.g., Products, Orders) and cannot be deleted!", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (ex.Number == 2627) // Primary key duplication error
                    MessageBox.Show("ID or unique data already exists!", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("SQL Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Logout()
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new Login().Show();
            }
        }

        // =============================================================
        // 1. MANAGE EMPLOYEE
        // =============================================================
        private void FillEmployeeData(string search = "")
        {
            string sql = "SELECT * FROM tblEmployee";
            if (!string.IsNullOrEmpty(search)) sql += " WHERE EmployeeName LIKE @search";

            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            if (!string.IsNullOrEmpty(search)) adp.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grvEmployee.DataSource = tbl;
        }

        private void ClearEmployeeData()
        {
            txtEmployeeID.Clear(); txtUseName.Clear(); txtEmployeeName.Clear();
            txtAuthorityLevel.Clear(); txtPassword.Clear();
        }

        private void btAdd_Employee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUseName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter Username and Password!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            string sql = "INSERT INTO tblEmployee (EmployeeName, Username, Password, AuthorityLevel) VALUES (@name, @user, @pass, @auth)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@user", txtUseName.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                int auth;
                int.TryParse(txtAuthorityLevel.Text, out auth); // Default to 0 if parsing fails
                cmd.Parameters.AddWithValue("@auth", auth);

            }, "Employee added successfully!");

            FillEmployeeData(); ClearEmployeeData(); LoadOrderComboboxes();
        }

        private void btUpdate_Employee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text)) { MessageBox.Show("No employee selected!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sql = "UPDATE tblEmployee SET EmployeeName=@name, Username=@user, Password=@pass, AuthorityLevel=@auth WHERE EmployeeID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@user", txtUseName.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                int auth; int.TryParse(txtAuthorityLevel.Text, out auth);
                cmd.Parameters.AddWithValue("@auth", auth);
                cmd.Parameters.AddWithValue("@id", txtEmployeeID.Text);
            }, "Update successful!");

            FillEmployeeData(); ClearEmployeeData(); LoadOrderComboboxes();
        }

        private void btDelete_Employee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text)) return;
            if (MessageBox.Show("Delete this employee?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblEmployee WHERE EmployeeID=@id";
                ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@id", txtEmployeeID.Text), "Deleted!");
                FillEmployeeData(); ClearEmployeeData(); LoadOrderComboboxes();
            }
        }

        private void grvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grvEmployee.Rows[e.RowIndex];
                txtEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                txtUseName.Text = row.Cells["Username"].Value.ToString();
                txtEmployeeName.Text = row.Cells["EmployeeName"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                txtAuthorityLevel.Text = row.Cells["AuthorityLevel"].Value.ToString();
            }
        }
        private void txtSearch_Employee_TextChanged(object sender, EventArgs e) { FillEmployeeData(txtSearch_Employee.Text); }
        private void btRefresh_Employee_Click(object sender, EventArgs e) { FillEmployeeData(); ClearEmployeeData(); }
        private void btLogout_Employee_Click(object sender, EventArgs e) { Logout(); }

        // =============================================================
        // 2. MANAGE CUSTOMER
        // =============================================================
        private void FillCustomerData(string search = "")
        {
            string sql = "SELECT * FROM tblCustomer";
            if (!string.IsNullOrEmpty(search)) sql += " WHERE CustomerName LIKE @search";

            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            if (!string.IsNullOrEmpty(search)) adp.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grvCustomer.DataSource = tbl;
        }

        private void ClearCustomerData() { txtCustomerID.Clear(); txtCustomerName.Clear(); txtPhone.Clear(); txtAddress.Clear(); }

        private void btAdd_Customer_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tblCustomer (CustomerName, Phone, Address) VALUES (@name, @phone, @addr)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
            }, "Customer added successfully!");
            FillCustomerData(); ClearCustomerData(); LoadOrderComboboxes();
        }

        private void btUpdate__Customer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text)) { MessageBox.Show("No customer selected!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sql = "UPDATE tblCustomer SET CustomerName=@name, Phone=@phone, Address=@addr WHERE CustomerID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
                cmd.Parameters.AddWithValue("@id", txtCustomerID.Text);
            }, "Update successful!");
            FillCustomerData(); ClearCustomerData(); LoadOrderComboboxes();
        }

        private void btDelete_Customer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text)) return;
            if (MessageBox.Show("Delete this customer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblCustomer WHERE CustomerID=@id";
                ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@id", txtCustomerID.Text), "Deleted!");
                FillCustomerData(); ClearCustomerData(); LoadOrderComboboxes();
            }
        }

        private void grvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grvCustomer.Rows[e.RowIndex];
                txtCustomerID.Text = row.Cells["CustomerID"].Value.ToString();
                txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }
        private void txtSearch_Customer_TextChanged(object sender, EventArgs e) { FillCustomerData(txtSearch_Customer.Text); }
        private void btRefresh_Customer_Click(object sender, EventArgs e) { FillCustomerData(); ClearCustomerData(); }

        // =============================================================
        // 3. MANAGE SUPPLIER
        // =============================================================
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
            string sql = "INSERT INTO tblSuppliers (SupplierName, SupplierPhone) VALUES (@name, @phone)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", cbSupplierName.Text);
                cmd.Parameters.AddWithValue("@phone", txtSupplierPhone.Text);
            }, "Supplier added successfully!");
            FillSuppliersData(); LoadProductComboboxes();
        }

        private void btUpdate_Supplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbSupplierID.Text)) return;
            string sql = "UPDATE tblSuppliers SET SupplierName=@name, SupplierPhone=@phone WHERE SupplierID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", cbSupplierName.Text);
                cmd.Parameters.AddWithValue("@phone", txtSupplierPhone.Text);
                cmd.Parameters.AddWithValue("@id", cbSupplierID.Text);
            }, "Update successful!");
            FillSuppliersData(); LoadProductComboboxes();
        }

        private void btDelete_Supplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbSupplierID.Text)) return;
            if (MessageBox.Show("Delete this supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblSuppliers WHERE SupplierID=@id";
                ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@id", cbSupplierID.Text), "Deleted!");
                FillSuppliersData(); LoadProductComboboxes();
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
        private void btRefresh_Supplier_Click(object sender, EventArgs e) { FillSuppliersData(); cbSupplierID.Text = ""; cbSupplierName.Text = ""; txtSupplierPhone.Clear(); }

        // =============================================================
        // 4. MANAGE CATEGORY
        // =============================================================
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
            string sql = "INSERT INTO tblCategory (CategoryName) VALUES (@name)";
            ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@name", cbCategoryName.Text), "Category added successfully!");
            FillCategoryData(); LoadProductComboboxes();
        }

        private void btUpdate_Category_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCategoryID.Text)) return;
            string sql = "UPDATE tblCategory SET CategoryName=@name WHERE CategoryID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", cbCategoryName.Text);
                cmd.Parameters.AddWithValue("@id", cbCategoryID.Text);
            }, "Update successful!");
            FillCategoryData(); LoadProductComboboxes();
        }

        private void btDelete_Category_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCategoryID.Text)) return;
            if (MessageBox.Show("Delete this category?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblCategory WHERE CategoryID=@id";
                ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@id", cbCategoryID.Text), "Deleted!");
                FillCategoryData(); LoadProductComboboxes();
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
        private void btRefresh_Category_Click(object sender, EventArgs e) { FillCategoryData(); cbCategoryID.Text = ""; cbCategoryName.Text = ""; }

        // =============================================================
        // 5. MANAGE PRODUCT
        // =============================================================
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

        private void LoadProductComboboxes()
        {
            // Category
            SqlDataAdapter daCat = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM tblCategory", conn);
            DataTable dtCat = new DataTable();
            daCat.Fill(dtCat);
            cbCategory.DataSource = dtCat;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";

            // Supplier
            SqlDataAdapter daSup = new SqlDataAdapter("SELECT SupplierID, SupplierName FROM tblSuppliers", conn);
            DataTable dtSup = new DataTable();
            daSup.Fill(dtSup);
            cbSupplier.DataSource = dtSup;
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierID";
        }

        private void ClearProductData()
        {
            txtProductID.Clear(); txtName.Clear(); txtQualitiInStock.Clear();
            if (cbCategory.Items.Count > 0) cbCategory.SelectedIndex = 0;
            if (cbSupplier.Items.Count > 0) cbSupplier.SelectedIndex = 0;
        }

        private void btAdd_Product_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter product name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            int quantity;
            if (!int.TryParse(txtQualitiInStock.Text, out quantity))
            {
                MessageBox.Show("Stock quantity must be an integer!", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (quantity < 0) { MessageBox.Show("Quantity cannot be negative!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cbCategory.SelectedValue == null || cbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please select Category and Supplier", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            string sql = "INSERT INTO tblProducts (ProductName, StockQuantity, CategoryID, SupplierID) VALUES (@name, @qty, @cid, @sid)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@cid", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", cbSupplier.SelectedValue);
            }, "Product added successfully!");
            FillProductsData(); ClearProductData();
        }

        private void btUpdate_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text)) { MessageBox.Show("No product selected!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // VALIDATION
            int quantity;
            if (!int.TryParse(txtQualitiInStock.Text, out quantity))
            {
                MessageBox.Show("Stock quantity must be an integer!", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (quantity < 0) { MessageBox.Show("Quantity cannot be negative!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sql = "UPDATE tblProducts SET ProductName=@name, StockQuantity=@qty, CategoryID=@cid, SupplierID=@sid WHERE ProductID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@cid", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", cbSupplier.SelectedValue);
                cmd.Parameters.AddWithValue("@id", txtProductID.Text);
            }, "Update successful!");
            FillProductsData(); ClearProductData();
        }

        private void btDelete_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text)) return;
            if (MessageBox.Show("Delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblProducts WHERE ProductID=@id";
                ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@id", txtProductID.Text), "Deleted!");
                FillProductsData(); ClearProductData();
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
                if (row.Cells["CategoryID"].Value != DBNull.Value) cbCategory.SelectedValue = row.Cells["CategoryID"].Value;
                if (row.Cells["SupplierID"].Value != DBNull.Value) cbSupplier.SelectedValue = row.Cells["SupplierID"].Value;
            }
        }
        private void txtSearch_Product_TextChanged(object sender, EventArgs e) { FillProductsData(txtSearch_Product.Text); }
        private void btRefresh_Product_Click(object sender, EventArgs e) { FillProductsData(); ClearProductData(); }

        // =============================================================
        // 6. MANAGE ORDER
        // =============================================================
        private void FillOrderData()
        {
            string sql = "SELECT * FROM [Order]";
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grvOrder.DataSource = tbl;
        }

        private void LoadOrderComboboxes()
        {
            // Employee
            SqlDataAdapter daEmp = new SqlDataAdapter("SELECT EmployeeID, EmployeeName FROM tblEmployee", conn);
            DataTable dtEmp = new DataTable();
            daEmp.Fill(dtEmp);
            cbEmployeeID.DataSource = dtEmp;
            cbEmployeeID.DisplayMember = "EmployeeName";
            cbEmployeeID.ValueMember = "EmployeeID";

            // Customer
            SqlDataAdapter daCus = new SqlDataAdapter("SELECT CustomerID, CustomerName FROM tblCustomer", conn);
            DataTable dtCus = new DataTable();
            daCus.Fill(dtCus);
            cbCustomerID.DataSource = dtCus;
            cbCustomerID.DisplayMember = "CustomerName";
            cbCustomerID.ValueMember = "CustomerID";
        }

        private void ClearOrderData()
        {
            txtOrderID.Clear(); txtOrderDate.Clear();
            if (cbEmployeeID.Items.Count > 0) cbEmployeeID.SelectedIndex = -1;
            if (cbCustomerID.Items.Count > 0) cbCustomerID.SelectedIndex = -1;
        }

        private void btAdd_Order_Click(object sender, EventArgs e)
        {
            if (cbEmployeeID.SelectedValue == null || cbCustomerID.SelectedValue == null)
            {
                MessageBox.Show("Please select Employee and Customer", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            string sql = "INSERT INTO [Order] (OrderDate, EmployeeID, CustomerID) VALUES (@date, @eid, @cid)";
            ExecuteQuery(sql, cmd => {
                DateTime oDate;
                if (DateTime.TryParse(txtOrderDate.Text, out oDate))
                    cmd.Parameters.AddWithValue("@date", oDate);
                else
                    cmd.Parameters.AddWithValue("@date", DateTime.Now); // Default to today if format is invalid

                cmd.Parameters.AddWithValue("@eid", cbEmployeeID.SelectedValue);
                cmd.Parameters.AddWithValue("@cid", cbCustomerID.SelectedValue);
            }, "Order added successfully!");
            FillOrderData(); ClearOrderData();
        }

        private void btUpdate_Order_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderID.Text)) { MessageBox.Show("No order selected!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sql = "UPDATE [Order] SET OrderDate=@date, EmployeeID=@eid, CustomerID=@cid WHERE OrderID=@id";
            ExecuteQuery(sql, cmd => {
                DateTime oDate;
                if (DateTime.TryParse(txtOrderDate.Text, out oDate))
                    cmd.Parameters.AddWithValue("@date", oDate);
                else
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);

                cmd.Parameters.AddWithValue("@eid", cbEmployeeID.SelectedValue);
                cmd.Parameters.AddWithValue("@cid", cbCustomerID.SelectedValue);
                cmd.Parameters.AddWithValue("@id", txtOrderID.Text);
            }, "Update successful!");
            FillOrderData(); ClearOrderData();
        }

        private void btDelete_Order_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderID.Text)) return;
            if (MessageBox.Show("Delete this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM [Order] WHERE OrderID=@id";
                ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@id", txtOrderID.Text), "Deleted!");
                FillOrderData(); ClearOrderData();
            }
        }

        private void grvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grvOrder.Rows[e.RowIndex];
                txtOrderID.Text = row.Cells["OrderID"].Value.ToString();
                if (row.Cells["EmployeeID"].Value != DBNull.Value) cbEmployeeID.SelectedValue = row.Cells["EmployeeID"].Value;
                if (row.Cells["CustomerID"].Value != DBNull.Value) cbCustomerID.SelectedValue = row.Cells["CustomerID"].Value;
                if (row.Cells["OrderDate"].Value != null) txtOrderDate.Text = row.Cells["OrderDate"].Value.ToString();
            }
        }
        private void btRefresh_Order_Click(object sender, EventArgs e) { FillOrderData(); ClearOrderData(); }

        // Placeholder events (Do not need code, just to avoid Designer errors)
        private void tpEmployee_Click(object sender, EventArgs e) { }
        private void tpCustomer_Click_1(object sender, EventArgs e) { }
        private void tpSupplier_Click(object sender, EventArgs e) { }
        private void tpCategory_Click(object sender, EventArgs e) { }
        private void tpProduct_Click(object sender, EventArgs e) { }
        private void cbSupplierID_SelectedIndexChanged(object sender, EventArgs e) { }

    }
}