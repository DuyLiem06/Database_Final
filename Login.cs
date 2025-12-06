using ASM_Final;
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
using System.Xml.Linq;

namespace ASM_Final
{
    public partial class Login : Form
    {
        // Declare connection object
        SqlConnection conn;

        public Login()
        {
            InitializeComponent();
            // Get connection string from DbHelper class
            conn = new SqlConnection(DbHelper.ConnectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Validate input
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both Username and Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = "SELECT AuthorityLevel, EmployeeName FROM tblEmployee WHERE Username = @user AND Password = @pass";

                // Use 'using' to automatically dispose resources for SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());

                    // Use 'using' for SqlDataReader
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Login successful
                        {
                            // Get information from database
                            int role = Convert.ToInt32(reader["AuthorityLevel"]);
                            string empName = reader["EmployeeName"].ToString();

                            // Important: Close Reader and Connection before opening new form
                            // to avoid connection conflicts.
                            reader.Close();
                            conn.Close();

                            // Hide Login form
                            this.Hide();

                            // Navigate based on Role
                            Form dashboard = null;

                            if (role == 1) // Admin
                            {
                                MessageBox.Show("Welcome Administrator: " + empName, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dashboard = new AdminDashboard();
                            }
                            else if (role == 2) // Sales
                            {
                                MessageBox.Show("Welcome Sales Staff: " + empName, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dashboard = new SalesDashboard();
                            }
                            else if (role == 3) // Warehouse
                            {
                                MessageBox.Show("Welcome Warehouse Keeper: " + empName, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dashboard = new WarehouseDashboard();
                            }
                            else
                            {
                                MessageBox.Show("This account has not been assigned a role!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Show(); // Show login form again
                                return;
                            }

                            // Show Dashboard if initialized successfully
                            if (dashboard != null)
                            {
                                dashboard.ShowDialog(); // Program stops here until Dashboard is closed

                                // When Dashboard closes, this line runs to reshow Login
                                this.Show();
                                txtPassword.Clear();
                                txtName.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is always closed
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the program?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}