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
using System.Windows.Forms.DataVisualization.Charting;

namespace ASM_Final
{
    public partial class AdminDashboard : Form
    {
        // Khởi tạo kết nối
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
                // 1. Cấu hình giao diện: Chặn sửa ID thủ công
                txtEmployeeID.ReadOnly = true;
                txtCustomerID.ReadOnly = true;
                txtProductID.ReadOnly = true;
                txtOrderID.ReadOnly = true;

                // Các ID của Tab mới
                txtOrderDetailD.ReadOnly = true;
                txtMethodID.ReadOnly = true;
                txtTotalAmount.ReadOnly = true; // Tổng tiền nên để tự tính toán

                // Vô hiệu hóa nhập liệu trên ComboBox ID (chỉ cho chọn)
                cbSupplierID.Enabled = false;
                cbCategoryID.Enabled = false;

                // 2. Tải dữ liệu cho tất cả các Tab
                FillEmployeeData();
                FillCustomerData();
                FillSuppliersData();
                FillCategoryData();

                // Load ComboBox phụ thuộc trước
                LoadProductComboboxes();
                LoadOrderComboboxes();

                // Load dữ liệu chính
                FillProductsData();
                FillOrderData();

                // Load dữ liệu cho 2 Tab mới
                FillOrderDetailData();
                FillPaymentMethodData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo hệ thống: " + ex.Message);
            }
        }

        // =============================================================
        // HÀM DÙNG CHUNG (HELPER METHODS)
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
                    MessageBox.Show(successMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Dữ liệu đang được sử dụng ở bảng khác, không thể xóa/sửa!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (ex.Number == 2627)
                    MessageBox.Show("Mã ID hoặc dữ liệu này đã tồn tại!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        // Hàm Logout chung cho tất cả các nút
        private void Logout()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new Login().Show();
            }
        }

        // --- SỰ KIỆN LOGOUT CHO TỪNG TAB ---
        private void btLogout_Employee_Click(object sender, EventArgs e) { Logout(); }
        private void btLogout_Customer_Click(object sender, EventArgs e) { Logout(); }
        private void btLogout_Supplier_Click(object sender, EventArgs e) { Logout(); }
        private void btLogout_Category_Click(object sender, EventArgs e) { Logout(); }
        private void btLogout_Product_Click(object sender, EventArgs e) { Logout(); }
        private void btLogout_Order_Click(object sender, EventArgs e) { Logout(); }

        // Nút logout ở tab Order Detail (Tên trong designer là button1)
        private void button1_Click(object sender, EventArgs e) { Logout(); }

        // Nút logout ở tab Payment Method (Tên trong designer là btnLogout)
        private void btnLogout_Click(object sender, EventArgs e) { Logout(); }


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
        private void ClearEmployeeData() { txtEmployeeID.Clear(); txtUseName.Clear(); txtEmployeeName.Clear(); txtAuthorityLevel.Clear(); txtPassword.Clear(); }

        private void btAdd_Employee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUseName.Text)) { MessageBox.Show("Vui lòng nhập Username!"); return; }
            string sql = "INSERT INTO tblEmployee (EmployeeName, Username, Password, AuthorityLevel) VALUES (@name, @user, @pass, @auth)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@user", txtUseName.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                int auth; int.TryParse(txtAuthorityLevel.Text, out auth);
                cmd.Parameters.AddWithValue("@auth", auth);
            }, "Thêm nhân viên thành công!");
            FillEmployeeData(); ClearEmployeeData(); LoadOrderComboboxes();
        }

        private void btUpdate_Employee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text)) { MessageBox.Show("Chọn nhân viên cần sửa!"); return; }
            string sql = "UPDATE tblEmployee SET EmployeeName=@name, Username=@user, Password=@pass, AuthorityLevel=@auth WHERE EmployeeID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@user", txtUseName.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                int auth; int.TryParse(txtAuthorityLevel.Text, out auth);
                cmd.Parameters.AddWithValue("@auth", auth);
                cmd.Parameters.AddWithValue("@id", txtEmployeeID.Text);
            }, "Cập nhật thành công!");
            FillEmployeeData(); ClearEmployeeData(); LoadOrderComboboxes();
        }

        private void btDelete_Employee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text)) return;
            if (MessageBox.Show("Xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteQuery("DELETE FROM tblEmployee WHERE EmployeeID=@id", cmd => cmd.Parameters.AddWithValue("@id", txtEmployeeID.Text), "Đã xóa!");
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
            }, "Thêm khách hàng thành công!");
            FillCustomerData(); ClearCustomerData(); LoadOrderComboboxes();
        }

        private void btUpdate__Customer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text)) return;
            string sql = "UPDATE tblCustomer SET CustomerName=@name, Phone=@phone, Address=@addr WHERE CustomerID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
                cmd.Parameters.AddWithValue("@id", txtCustomerID.Text);
            }, "Cập nhật thành công!");
            FillCustomerData(); ClearCustomerData(); LoadOrderComboboxes();
        }

        private void btDelete_Customer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text)) return;
            if (MessageBox.Show("Xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteQuery("DELETE FROM tblCustomer WHERE CustomerID=@id", cmd => cmd.Parameters.AddWithValue("@id", txtCustomerID.Text), "Đã xóa!");
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
            }, "Thêm NCC thành công!");
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
            }, "Cập nhật thành công!");
            FillSuppliersData(); LoadProductComboboxes();
        }

        private void btDelete_Supplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbSupplierID.Text)) return;
            if (MessageBox.Show("Xóa NCC này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteQuery("DELETE FROM tblSuppliers WHERE SupplierID=@id", cmd => cmd.Parameters.AddWithValue("@id", cbSupplierID.Text), "Đã xóa!");
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
        private void txtSearch_Supplier_TextChanged(object sender, EventArgs e) { FillSuppliersData(txtSearch_Supplier.Text); }
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
            ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@name", cbCategoryName.Text), "Thêm danh mục thành công!");
            FillCategoryData(); LoadProductComboboxes();
        }

        private void btUpdate_Category_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCategoryID.Text)) return;
            string sql = "UPDATE tblCategory SET CategoryName=@name WHERE CategoryID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", cbCategoryName.Text);
                cmd.Parameters.AddWithValue("@id", cbCategoryID.Text);
            }, "Cập nhật thành công!");
            FillCategoryData(); LoadProductComboboxes();
        }

        private void btDelete_Category_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCategoryID.Text)) return;
            if (MessageBox.Show("Xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteQuery("DELETE FROM tblCategory WHERE CategoryID=@id", cmd => cmd.Parameters.AddWithValue("@id", cbCategoryID.Text), "Đã xóa!");
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
        private void txtCategoryName_TextChanged(object sender, EventArgs e) { FillCategoryData(txtCategoryName.Text); }
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
            SqlDataAdapter daCat = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM tblCategory", conn);
            DataTable dtCat = new DataTable();
            daCat.Fill(dtCat);
            cbCategory.DataSource = dtCat;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";

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
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Nhập tên sản phẩm!"); return; }
            int quantity;
            if (!int.TryParse(txtQualitiInStock.Text, out quantity)) { MessageBox.Show("Số lượng không hợp lệ!"); return; }

            string sql = "INSERT INTO tblProducts (ProductName, StockQuantity, CategoryID, SupplierID) VALUES (@name, @qty, @cid, @sid)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@cid", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", cbSupplier.SelectedValue);
            }, "Thêm sản phẩm thành công!");
            FillProductsData(); ClearProductData();
        }

        private void btUpdate_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text)) return;
            int quantity;
            if (!int.TryParse(txtQualitiInStock.Text, out quantity)) { MessageBox.Show("Số lượng không hợp lệ!"); return; }

            string sql = "UPDATE tblProducts SET ProductName=@name, StockQuantity=@qty, CategoryID=@cid, SupplierID=@sid WHERE ProductID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@cid", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", cbSupplier.SelectedValue);
                cmd.Parameters.AddWithValue("@id", txtProductID.Text);
            }, "Cập nhật thành công!");
            FillProductsData(); ClearProductData();
        }

        private void btDelete_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text)) return;
            if (MessageBox.Show("Xóa sản phẩm?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteQuery("DELETE FROM tblProducts WHERE ProductID=@id", cmd => cmd.Parameters.AddWithValue("@id", txtProductID.Text), "Đã xóa!");
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
        private void FillOrderData(string search = "")
        {
            string sql = "SELECT * FROM [Order]";

            // Xử lý tìm kiếm OrderID (chỉ tìm nếu nhập số)
            int searchID;
            bool isNumber = int.TryParse(search, out searchID);

            if (!string.IsNullOrEmpty(search) && isNumber)
                sql += " WHERE OrderID = @id";

            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            if (!string.IsNullOrEmpty(search) && isNumber)
                adp.SelectCommand.Parameters.AddWithValue("@id", searchID);

            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grvOrder.DataSource = tbl;
        }

        private void LoadOrderComboboxes()
        {
            SqlDataAdapter daEmp = new SqlDataAdapter("SELECT EmployeeID, EmployeeName FROM tblEmployee", conn);
            DataTable dtEmp = new DataTable();
            daEmp.Fill(dtEmp);
            cbEmployeeID.DataSource = dtEmp;
            cbEmployeeID.DisplayMember = "EmployeeName";
            cbEmployeeID.ValueMember = "EmployeeID";

            SqlDataAdapter daCus = new SqlDataAdapter("SELECT CustomerID, CustomerName FROM tblCustomer", conn);
            DataTable dtCus = new DataTable();
            daCus.Fill(dtCus);
            cbCustomerID.DataSource = dtCus;
            cbCustomerID.DisplayMember = "CustomerName";
            cbCustomerID.ValueMember = "CustomerID";
        }

        private void ClearOrderData()
        {
            txtOrderID.Clear(); txtOrderDate.Clear(); txtPaymentMethodID.Clear(); txtTotalAmount.Clear();
            if (cbEmployeeID.Items.Count > 0) cbEmployeeID.SelectedIndex = -1;
            if (cbCustomerID.Items.Count > 0) cbCustomerID.SelectedIndex = -1;
        }

        private void btAdd_Order_Click(object sender, EventArgs e)
        {
            if (cbEmployeeID.SelectedValue == null || cbCustomerID.SelectedValue == null)
            {
                MessageBox.Show("Chọn nhân viên và khách hàng!"); return;
            }

            string sql = "INSERT INTO [Order] (OrderDate, EmployeeID, CustomerID, PaymentMethodID) VALUES (@date, @eid, @cid, @pid)";
            ExecuteQuery(sql, cmd => {
                DateTime oDate;
                if (!DateTime.TryParse(txtOrderDate.Text, out oDate)) oDate = DateTime.Now;
                int pid; int.TryParse(txtPaymentMethodID.Text, out pid);

                cmd.Parameters.AddWithValue("@date", oDate);
                cmd.Parameters.AddWithValue("@eid", cbEmployeeID.SelectedValue);
                cmd.Parameters.AddWithValue("@cid", cbCustomerID.SelectedValue);
                cmd.Parameters.AddWithValue("@pid", pid > 0 ? (object)pid : DBNull.Value);
            }, "Thêm đơn hàng thành công!");
            FillOrderData(); ClearOrderData();
        }

        private void btUpdate_Order_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderID.Text)) return;
            string sql = "UPDATE [Order] SET OrderDate=@date, EmployeeID=@eid, CustomerID=@cid, PaymentMethodID=@pid WHERE OrderID=@id";
            ExecuteQuery(sql, cmd => {
                DateTime oDate;
                if (!DateTime.TryParse(txtOrderDate.Text, out oDate)) oDate = DateTime.Now;
                int pid; int.TryParse(txtPaymentMethodID.Text, out pid);

                cmd.Parameters.AddWithValue("@date", oDate);
                cmd.Parameters.AddWithValue("@eid", cbEmployeeID.SelectedValue);
                cmd.Parameters.AddWithValue("@cid", cbCustomerID.SelectedValue);
                cmd.Parameters.AddWithValue("@pid", pid > 0 ? (object)pid : DBNull.Value);
                cmd.Parameters.AddWithValue("@id", txtOrderID.Text);
            }, "Cập nhật thành công!");
            FillOrderData(); ClearOrderData();
        }

        private void btDelete_Order_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderID.Text)) return;
            if (MessageBox.Show("Xóa đơn hàng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteQuery("DELETE FROM [Order] WHERE OrderID=@id", cmd => cmd.Parameters.AddWithValue("@id", txtOrderID.Text), "Đã xóa!");
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
                if (row.Cells["PaymentMethodID"].Value != DBNull.Value) txtPaymentMethodID.Text = row.Cells["PaymentMethodID"].Value.ToString();
            }
        }

        private void btRefresh_Order_Click(object sender, EventArgs e) { FillOrderData(); ClearOrderData(); }


        // =============================================================
        // 7. MANAGE ORDER DETAIL (TAB MỚI)
        // =============================================================
        private void FillOrderDetailData(string search = "")
        {
            string sql = "SELECT * FROM tblOrderDetail";

            // Tìm kiếm theo OrderID
            int searchID;
            bool isNumber = int.TryParse(search, out searchID);

            if (!string.IsNullOrEmpty(search) && isNumber)
                sql += " WHERE OrderID = @id";

            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            if (!string.IsNullOrEmpty(search) && isNumber)
                adp.SelectCommand.Parameters.AddWithValue("@id", searchID);

            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView_OrderDetail.DataSource = tbl;
        }

        private void ClearOrderDetail()
        {
            txtOrderDetailD.Clear(); txtOrderID_OrderDetail.Clear(); ProductID.Clear();
            txtQuantity.Clear(); txtUnitPrice.Clear(); txtOrderDate_OrderDetail.Clear();
        }

        private void btAdd_OrderDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderID_OrderDetail.Text) || string.IsNullOrEmpty(ProductID.Text))
            {
                MessageBox.Show("Nhập OrderID và ProductID!"); return;
            }

            string sql = "INSERT INTO tblOrderDetail (OrderID, ProductID, Quantity, TotalAmount) VALUES (@oid, @pid, @qty, @total)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@oid", int.Parse(txtOrderID_OrderDetail.Text));
                cmd.Parameters.AddWithValue("@pid", int.Parse(ProductID.Text));

                int qty = 0; int.TryParse(txtQuantity.Text, out qty);
                decimal price = 0; decimal.TryParse(txtUnitPrice.Text, out price); // txtUnitPrice ở đây dùng làm Đơn Giá (Price)

                // Tính thành tiền = Số lượng * Đơn giá
                decimal total = qty * price;

                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@total", total);
            }, "Thêm chi tiết đơn thành công!");
            FillOrderDetailData(); ClearOrderDetail();
        }

        private void btUpdate_OrderDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderDetailD.Text)) return;

            string sql = "UPDATE tblOrderDetail SET OrderID=@oid, ProductID=@pid, Quantity=@qty, TotalAmount=@total WHERE OrderDetailID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@oid", int.Parse(txtOrderID_OrderDetail.Text));
                cmd.Parameters.AddWithValue("@pid", int.Parse(ProductID.Text));
                int qty = 0; int.TryParse(txtQuantity.Text, out qty);
                decimal price = 0; decimal.TryParse(txtUnitPrice.Text, out price);
                decimal total = qty * price;

                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@id", txtOrderDetailD.Text);
            }, "Cập nhật chi tiết đơn thành công!");
            FillOrderDetailData(); ClearOrderDetail();
        }

        private void btDelete_OrderDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderDetailD.Text)) return;
            if (MessageBox.Show("Xóa chi tiết này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteQuery("DELETE FROM tblOrderDetail WHERE OrderDetailID=@id", cmd => cmd.Parameters.AddWithValue("@id", txtOrderDetailD.Text), "Đã xóa!");
                FillOrderDetailData(); ClearOrderDetail();
            }
        }

        private void dataGridView_OrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_OrderDetail.Rows[e.RowIndex];
                txtOrderDetailD.Text = row.Cells["OrderDetailID"].Value.ToString();
                txtOrderID_OrderDetail.Text = row.Cells["OrderID"].Value.ToString();
                ProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();

                // Hiển thị TotalAmount vào ô UnitPrice
                if (row.Cells["TotalAmount"].Value != DBNull.Value)
                    txtUnitPrice.Text = row.Cells["TotalAmount"].Value.ToString();
            }
        }

  

        private void btRefresh_OrderDetail_Click(object sender, EventArgs e) { FillOrderDetailData(); ClearOrderDetail(); }


        // =============================================================
        // 8. PAYMENT METHOD (TAB MỚI)
        // =============================================================
        private void FillPaymentMethodData(string search = "")
        {
            string sql = "SELECT * FROM tblPaymentMethod";
            if (!string.IsNullOrEmpty(search)) sql += " WHERE MethodName LIKE @search";
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            if (!string.IsNullOrEmpty(search)) adp.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grvPaymentMethod.DataSource = tbl;
        }

        private void ClearPaymentMethod()
        {
            txtMethodID.Clear(); txtPaymentMethodName.Clear();
        }

        private void btAdd_Pay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPaymentMethodName.Text)) { MessageBox.Show("Nhập tên phương thức!"); return; }
            string sql = "INSERT INTO tblPaymentMethod (MethodName) VALUES (@name)";
            ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@name", txtPaymentMethodName.Text), "Thêm phương thức thành công!");
            FillPaymentMethodData(); ClearPaymentMethod();
        }

        private void btUpdate_Pay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMethodID.Text)) { MessageBox.Show("Chọn phương thức cần sửa!"); return; }
            string sql = "UPDATE tblPaymentMethod SET MethodName=@name WHERE PaymentMethodID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", txtPaymentMethodName.Text);
                cmd.Parameters.AddWithValue("@id", txtMethodID.Text);
            }, "Cập nhật thành công!");
            FillPaymentMethodData(); ClearPaymentMethod();
        }

        private void btDelete_Pay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMethodID.Text)) return;
            if (MessageBox.Show("Xóa phương thức này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteQuery("DELETE FROM tblPaymentMethod WHERE PaymentMethodID=@id", cmd => cmd.Parameters.AddWithValue("@id", txtMethodID.Text), "Đã xóa!");
                FillPaymentMethodData(); ClearPaymentMethod();
            }
        }

        private void grvPaymentMethod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grvPaymentMethod.Rows[e.RowIndex];
                txtMethodID.Text = row.Cells["PaymentMethodID"].Value.ToString();
                txtPaymentMethodName.Text = row.Cells["MethodName"].Value.ToString();
            }
        }

        private void btRefresh_Pay_Click(object sender, EventArgs e) { FillPaymentMethodData(); ClearPaymentMethod(); }


        // =============================================================
        // SỰ KIỆN RỖNG & LIÊN KẾT NÚT BẤM (QUAN TRỌNG)
        // =============================================================

        // Nếu Designer của bạn đang trỏ sự kiện Click vào tên hàm có đuôi _1, hãy dùng các hàm cầu nối này:

        // --- ORDER DETAIL ---
        private void btAdd_OrderDetail_Click_1(object sender, EventArgs e) { btAdd_OrderDetail_Click(sender, e); }
        private void btUpdate_OrderDetail_Click_1(object sender, EventArgs e) { btUpdate_OrderDetail_Click(sender, e); }
        private void btRefresh_OrderDetail_Click_1(object sender, EventArgs e) { btRefresh_OrderDetail_Click(sender, e); }

        // --- PAYMENT METHOD ---
        private void btAdd_Pay_Click_1(object sender, EventArgs e) { btAdd_Pay_Click(sender, e); }
        private void btUpdate_Pay_Click_1(object sender, EventArgs e) { btUpdate_Pay_Click(sender, e); }
        private void btDelete_Pay_Click_1(object sender, EventArgs e) { btDelete_Pay_Click(sender, e); }
        private void btRefresh_Pay_Click_1(object sender, EventArgs e) { btRefresh_Pay_Click(sender, e); }

        // --- PLACEHOLDERS ---
        private void tpEmployee_Click(object sender, EventArgs e) { }
        private void tpCustomer_Click_1(object sender, EventArgs e) { }
        private void tpSupplier_Click(object sender, EventArgs e) { }
        private void tpCategory_Click(object sender, EventArgs e) { }
        private void tpProduct_Click(object sender, EventArgs e) { }
        private void tpOrder_Click(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void cbSupplierID_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtOrderDate_TextChanged(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void lblProName_Click(object sender, EventArgs e) { }
        private void txtName_TextChanged(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadStatistics("Employee");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        private void LoadStatistics(string filterType, int role = 0)
        {
            try
            {
                DateTime fromDateOnly = dtpFromDate.Value.Date;
                DateTime toDateOnly = dtpToDate.Value.Date; // inclusive date

                string sql = "";

                if (filterType == "Employee")
                {
                    sql = @"
SELECT e.EmployeeName, SUM(o.TotalAmount) AS TotalRevenue
FROM [Order] o
JOIN Employee e ON o.EmployeeID = e.EmployeeID
WHERE o.OrderDate >= @FromDate AND o.OrderDate < DATEADD(day,1,@ToDate)
";
                    if (role != 0)
                    {
                        sql += " AND e.AuthorityLevel = @RoleID";
                    }
                    sql += @"
GROUP BY e.EmployeeName
ORDER BY TotalRevenue DESC";
                }
                else if (filterType == "Customer")
                {
                    sql = @"
SELECT c.CustomerName, SUM(o.TotalAmount) AS TotalSpent
FROM [Order] o
JOIN Customer c ON o.CustomerID = c.CustomerID
WHERE o.OrderDate >= @FromDate AND o.OrderDate < DATEADD(day,1,@ToDate)
GROUP BY c.CustomerName
ORDER BY TotalSpent DESC";
                }
                else if (filterType == "RevenueOverTime")
                {
                    sql = @"
SELECT CAST(o.OrderDate AS DATE) AS OrderDay, SUM(o.TotalAmount) AS TotalRevenue
FROM [Order] o
WHERE o.OrderDate >= @FromDate AND o.OrderDate < DATEADD(day,1,@ToDate)
GROUP BY CAST(o.OrderDate AS DATE)
ORDER BY OrderDay";
                }
                else
                {
                    MessageBox.Show("Unknown filter type.");
                    return;
                }

                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDateOnly);
                    cmd.Parameters.AddWithValue("@ToDate", toDateOnly);
                    if (role != 0) cmd.Parameters.AddWithValue("@RoleID", role);

                    new SqlDataAdapter(cmd).Fill(dt);
                }

                // Debug: show count and first rows if no data
                if (dt.Rows.Count == 0)
                {
                    string dbg = $"Query returned 0 rows.\nFrom: {fromDateOnly:yyyy-MM-dd}  To: {toDateOnly:yyyy-MM-dd}\n" +
                                 "Please check:\n- Are there Order rows in that date range?\n- Is connection string pointing to correct DB?";
                    MessageBox.Show(dbg, "No data for this period", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Prepare chart
                chartStatistics.Series.Clear();
                chartStatistics.Titles.Clear();
                chartStatistics.ChartAreas.Clear();
                chartStatistics.ChartAreas.Add(new ChartArea("MainArea"));
                decimal total = Convert.ToDecimal(dt.Compute("SUM(" + dt.Columns[1].ColumnName + ")", ""));

                Title totalTitle = new Title
                {
                    Text = "TỔNG: " + total.ToString("#,##0 VND"),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.DarkRed,
                    Docking = Docking.Top,
                    Alignment = ContentAlignment.TopRight
                };
                chartStatistics.Titles.Add(totalTitle);

                Series series = new Series(filterType)
                {
                    IsValueShownAsLabel = true,
                    ToolTip = "#VALX: #VALY",
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    ChartArea = "MainArea"
                };

                Random rand = new Random();

                if (filterType == "RevenueOverTime")
                {
                    // Line chart
                    series.ChartType = SeriesChartType.Line;
                    series.BorderWidth = 3;
                    series.MarkerStyle = MarkerStyle.Circle;
                    series.MarkerSize = 6;
                    series.XValueMember = dt.Columns[0].ColumnName;
                    series.YValueMembers = dt.Columns[1].ColumnName;

                    chartStatistics.Series.Add(series);
                    chartStatistics.DataSource = dt;
                    chartStatistics.DataBind();

                    var area = chartStatistics.ChartAreas["MainArea"];
                    area.AxisX.MajorGrid.LineColor = Color.LightGray;
                    area.AxisY.MajorGrid.LineColor = Color.LightGray;
                    area.AxisX.LabelStyle.Angle = -45;
                    area.AxisX.Interval = 1;
                }
                else if (filterType == "Employee")
                {
                    // Column chart
                    series.ChartType = SeriesChartType.Column;

                    foreach (DataRow row in dt.Rows)
                    {
                        double y = Convert.ToDouble(row[1]);
                        int idx = series.Points.AddXY(row[0].ToString(), y);
                        series.Points[idx].Label = y.ToString("N0");
                        series.Points[idx].Color = Color.FromArgb(rand.Next(50, 256), rand.Next(50, 256), rand.Next(50, 256));
                    }

                    chartStatistics.Series.Add(series);
                }
                else if (filterType == "Customer")
                {
                    // Pie chart
                    series.ChartType = SeriesChartType.Pie;
                    series["PieLabelStyle"] = "Outside";
                    series["PieLineColor"] = "Black";

                    foreach (DataRow row in dt.Rows)
                    {
                        double y = Convert.ToDouble(row[1]);
                        int idx = series.Points.AddXY(row[0].ToString(), y);
                        series.Points[idx].Color = Color.FromArgb(rand.Next(50, 256), rand.Next(50, 256), rand.Next(50, 256));
                        series.Points[idx].Label = $"{row[0]} ({(y / (double)total):P1})";
                    }

                    chartStatistics.Series.Add(series);
                    if (chartStatistics.Legends.Count == 0) chartStatistics.Legends.Add(new Legend("DefaultLegend"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadStatistics("Customer");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadStatistics("RevenueOverTime");
        }

        private void chartStatistics_Click(object sender, EventArgs e)
        {

        }
    }
}