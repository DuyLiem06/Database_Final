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
    public partial class SalesDashboard : Form
    {
        // Kết nối CSDL
        SqlConnection conn;

        public SalesDashboard()
        {
            InitializeComponent();
            conn = new SqlConnection(DbHelper.ConnectionString);
        }

        private void SalesDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                // Cấu hình giao diện
                txtProductID.ReadOnly = true; // Không cho sửa ID sản phẩm thủ công

                // Mở kết nối nếu chưa mở
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Tải dữ liệu ban đầu
                FillProductsData();          // Tab View Products
                FillProductsDataForManage(); // Tab Manage Products
                FillOrderData();             // Lịch sử đơn hàng

                // Tải dữ liệu vào các ComboBox
                LoadComboboxes();
                LoadProductComboboxes();     // Cho tab Manage Product
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo dữ liệu: " + ex.Message);
            }
        }

        // =============================================================
        // HÀM DÙNG CHUNG (HELPER)
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
                if (ex.Number == 547) MessageBox.Show("Dữ liệu đang được sử dụng, không thể xóa!", "Lỗi ràng buộc");
                else MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi hệ thống: " + ex.Message); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void Logout()
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide(); // Ẩn form Sales
                // Quay lại form Login (Lưu ý: Login phải được mở trước đó bằng Show() hoặc Application.Run)
                // Nếu Login mở Sales bằng ShowDialog(), chỉ cần this.Close()
                this.Close();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void SalesDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }


        // ==========================================
        // 1. TAB: VIEW PRODUCTS (Chỉ xem)
        // ==========================================
        private void FillProductsData(string search = "")
        {
            try
            {
                string sql = "SELECT ProductID, ProductName, StockQuantity, Price FROM tblProducts"; // Thêm Price nếu có
                if (!string.IsNullOrEmpty(search)) sql += " WHERE ProductName LIKE @search";

                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                if (!string.IsNullOrEmpty(search)) adp.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                grvProducts.DataSource = tbl;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message); }
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            FillProductsData(txtSearchProduct.Text.Trim());
        }


        // ==========================================
        // 2. TAB: CREATE ORDER (Tạo đơn hàng)
        // ==========================================
        private void LoadComboboxes()
        {
            try
            {
                // Customer
                SqlDataAdapter daCus = new SqlDataAdapter("SELECT CustomerID, CustomerName FROM tblCustomer", conn);
                DataTable dtCus = new DataTable(); daCus.Fill(dtCus);
                cbCustomer.DataSource = dtCus; cbCustomer.DisplayMember = "CustomerName"; cbCustomer.ValueMember = "CustomerID";
                cbCustomer.SelectedIndex = -1;

                // Employee
                SqlDataAdapter daEmp = new SqlDataAdapter("SELECT EmployeeID, EmployeeName FROM tblEmployee", conn);
                DataTable dtEmp = new DataTable(); daEmp.Fill(dtEmp);
                cbEmployee.DataSource = dtEmp; cbEmployee.DisplayMember = "EmployeeName"; cbEmployee.ValueMember = "EmployeeID";
                cbEmployee.SelectedIndex = -1;

                // Payment Method (Mới thêm)
                SqlDataAdapter daPay = new SqlDataAdapter("SELECT PaymentMethodID, MethodName FROM tblPaymentMethod", conn);
                DataTable dtPay = new DataTable(); daPay.Fill(dtPay);
                cbPaymentMethodID.DataSource = dtPay; cbPaymentMethodID.DisplayMember = "MethodName"; cbPaymentMethodID.ValueMember = "PaymentMethodID";
                cbPaymentMethodID.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách chọn: " + ex.Message); }
        }

        private void FillOrderData()
        {
            try
            {
                string sql = "SELECT * FROM [Order] ORDER BY OrderDate DESC";
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                DataTable tbl = new DataTable(); adp.Fill(tbl);
                grvOrders.DataSource = tbl;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lịch sử đơn hàng: " + ex.Message); }
        }

        private void btAddOrder_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (cbCustomer.SelectedValue == null || cbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng và Nhân viên!", "Thiếu thông tin"); return;
            }

            // Insert Order
            string sql = "INSERT INTO [Order] (OrderDate, EmployeeID, CustomerID, PaymentMethodID) VALUES (@date, @eid, @cid, @pid)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@date", dtpOrderDate.Value);
                cmd.Parameters.AddWithValue("@eid", cbEmployee.SelectedValue);
                cmd.Parameters.AddWithValue("@cid", cbCustomer.SelectedValue);

                // Xử lý PaymentID (có thể null nếu chưa chọn)
                if (cbPaymentMethodID.SelectedValue != null)
                    cmd.Parameters.AddWithValue("@pid", cbPaymentMethodID.SelectedValue);
                else
                    cmd.Parameters.AddWithValue("@pid", DBNull.Value);

            }, "Tạo đơn hàng thành công!");

            FillOrderData(); // Refresh lưới
        }


        // ==========================================
        // 3. TAB: MANAGE PRODUCT (Quản lý sản phẩm - MỚI)
        // ==========================================
        private void FillProductsDataForManage(string search = "")
        {
            try
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
                grvProducts_Sales.DataSource = tbl;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu sản phẩm: " + ex.Message); }
        }

        private void LoadProductComboboxes()
        {
            // Category
            SqlDataAdapter daCat = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM tblCategory", conn);
            DataTable dtCat = new DataTable(); daCat.Fill(dtCat);
            cbCategory.DataSource = dtCat; cbCategory.DisplayMember = "CategoryName"; cbCategory.ValueMember = "CategoryID";

            // Supplier
            SqlDataAdapter daSup = new SqlDataAdapter("SELECT SupplierID, SupplierName FROM tblSuppliers", conn);
            DataTable dtSup = new DataTable(); daSup.Fill(dtSup);
            cbSupplier.DataSource = dtSup; cbSupplier.DisplayMember = "SupplierName"; cbSupplier.ValueMember = "SupplierID";
        }

        private void ClearProductInputs()
        {
            txtProductID.Clear(); textBox1.Clear(); txtQualitiInStock.Clear(); // textBox1 là ProductName
            cbCategory.SelectedIndex = -1; cbSupplier.SelectedIndex = -1;
        }

        // Nút Thêm Sản Phẩm
        private void btAdd_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) { MessageBox.Show("Nhập tên sản phẩm!"); return; }
            int qty;
            if (!int.TryParse(txtQualitiInStock.Text, out qty)) { MessageBox.Show("Số lượng phải là số!"); return; }

            string sql = "INSERT INTO tblProducts (ProductName, StockQuantity, CategoryID, SupplierID) VALUES (@name, @qty, @cid, @sid)";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@cid", cbCategory.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@sid", cbSupplier.SelectedValue ?? DBNull.Value);
            }, "Thêm sản phẩm thành công!");

            FillProductsDataForManage(); ClearProductInputs();
        }

        // Nút Sửa Sản Phẩm
        private void btUpdate_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text)) return;
            int qty; int.TryParse(txtQualitiInStock.Text, out qty);

            string sql = "UPDATE tblProducts SET ProductName=@name, StockQuantity=@qty, CategoryID=@cid, SupplierID=@sid WHERE ProductID=@id";
            ExecuteQuery(sql, cmd => {
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@cid", cbCategory.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@sid", cbSupplier.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", txtProductID.Text);
            }, "Cập nhật thành công!");

            FillProductsDataForManage(); ClearProductInputs();
        }

        // Nút Xóa Sản Phẩm
        private void btDelete_Product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text)) return;
            if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteQuery("DELETE FROM tblProducts WHERE ProductID=@id", cmd =>
                    cmd.Parameters.AddWithValue("@id", txtProductID.Text), "Đã xóa!");
                FillProductsDataForManage(); ClearProductInputs();
            }
        }

        // Nút Làm Mới
        private void btRefresh_Product_Click(object sender, EventArgs e)
        {
            FillProductsDataForManage();
            ClearProductInputs();
        }

        // Sự kiện tìm kiếm ở Tab Manage Product
        private void txtSearch_Product_TextChanged(object sender, EventArgs e)
        {
            FillProductsDataForManage(txtSearch_Product.Text);
        }

        // Sự kiện Click vào lưới để đổ dữ liệu lên TextBox (Tab Manage Product)
        private void grvProducts_Sales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grvProducts_Sales.Rows[e.RowIndex];
                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                textBox1.Text = row.Cells["ProductName"].Value.ToString(); // Tên SP
                txtQualitiInStock.Text = row.Cells["StockQuantity"].Value.ToString();

                if (row.Cells["CategoryID"].Value != DBNull.Value) cbCategory.SelectedValue = row.Cells["CategoryID"].Value;
                if (row.Cells["SupplierID"].Value != DBNull.Value) cbSupplier.SelectedValue = row.Cells["SupplierID"].Value;
            }
        }

        // =============================================================
        // KẾT NỐI SỰ KIỆN RỖNG (PLACEHOLDERS)
        // =============================================================
        private void label1_Click(object sender, EventArgs e) { }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể reload data khi chuyển tab nếu muốn
            if (tabControl1.SelectedTab == tabPage1) FillProductsDataForManage();
        }
        private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void cbPaymentMethodID_SelectedIndexChanged(object sender, EventArgs e) { }
        private void grvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // Sự kiện click lưới ở Tab Manage Product (phải đảm bảo Designer trỏ vào hàm này)
        // Nếu Designer trỏ vào hàm khác, hãy đổi tên hàm này hoặc sửa trong Designer
        // Ví dụ nếu Designer trỏ vào grvProducts_Sales_CellClick thì đổi tên hàm dưới đây
        private void grvProducts_Sales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grvProducts_Sales_CellContentClick(sender, e);
        }
    }
}