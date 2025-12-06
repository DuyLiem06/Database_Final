namespace ASM_Final
{
    partial class SalesDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpProducts = new System.Windows.Forms.TabPage();
            this.grvProducts = new System.Windows.Forms.DataGridView();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpOrders = new System.Windows.Forms.TabPage();
            this.lblProName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbPaymentMethodID = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grvOrders = new System.Windows.Forms.DataGridView();
            this.btAddOrder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grvProducts_Sales = new System.Windows.Forms.DataGridView();
            this.txtSearch_Product = new System.Windows.Forms.TextBox();
            this.labelSearchPro = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtQualitiInStock = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.lblProID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblProQty = new System.Windows.Forms.Label();
            this.lblProCat = new System.Windows.Forms.Label();
            this.lblProSup = new System.Windows.Forms.Label();
            this.btAdd_Product = new System.Windows.Forms.Button();
            this.btUpdate_Product = new System.Windows.Forms.Button();
            this.btDelete_Product = new System.Windows.Forms.Button();
            this.btRefresh_Product = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts)).BeginInit();
            this.tpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrders)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts_Sales)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpProducts);
            this.tabControl1.Controls.Add(this.tpOrders);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1151, 569);
            this.tabControl1.TabIndex = 0;
            // 
            // tpProducts
            // 
            this.tpProducts.Controls.Add(this.grvProducts);
            this.tpProducts.Controls.Add(this.txtSearchProduct);
            this.tpProducts.Controls.Add(this.label1);
            this.tpProducts.Location = new System.Drawing.Point(4, 25);
            this.tpProducts.Name = "tpProducts";
            this.tpProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tpProducts.Size = new System.Drawing.Size(1143, 540);
            this.tpProducts.TabIndex = 0;
            this.tpProducts.Text = "View Products";
            this.tpProducts.UseVisualStyleBackColor = true;
            // 
            // grvProducts
            // 
            this.grvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvProducts.Location = new System.Drawing.Point(21, 62);
            this.grvProducts.Name = "grvProducts";
            this.grvProducts.RowHeadersWidth = 51;
            this.grvProducts.RowTemplate.Height = 24;
            this.grvProducts.Size = new System.Drawing.Size(1100, 458);
            this.grvProducts.TabIndex = 2;
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(167, 23);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(360, 22);
            this.txtSearchProduct.TabIndex = 1;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Product:";
            // 
            // tpOrders
            // 
            this.tpOrders.Controls.Add(this.lblProName);
            this.tpOrders.Controls.Add(this.txtName);
            this.tpOrders.Controls.Add(this.txtQuantity);
            this.tpOrders.Controls.Add(this.label13);
            this.tpOrders.Controls.Add(this.cbPaymentMethodID);
            this.tpOrders.Controls.Add(this.label20);
            this.tpOrders.Controls.Add(this.label5);
            this.tpOrders.Controls.Add(this.grvOrders);
            this.tpOrders.Controls.Add(this.btAddOrder);
            this.tpOrders.Controls.Add(this.label4);
            this.tpOrders.Controls.Add(this.dtpOrderDate);
            this.tpOrders.Controls.Add(this.label3);
            this.tpOrders.Controls.Add(this.cbEmployee);
            this.tpOrders.Controls.Add(this.label2);
            this.tpOrders.Controls.Add(this.cbCustomer);
            this.tpOrders.Location = new System.Drawing.Point(4, 25);
            this.tpOrders.Name = "tpOrders";
            this.tpOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrders.Size = new System.Drawing.Size(1143, 540);
            this.tpOrders.TabIndex = 1;
            this.tpOrders.Text = "Create Order";
            this.tpOrders.UseVisualStyleBackColor = true;
            // 
            // lblProName
            // 
            this.lblProName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProName.AutoSize = true;
            this.lblProName.Location = new System.Drawing.Point(402, 18);
            this.lblProName.Name = "lblProName";
            this.lblProName.Size = new System.Drawing.Size(93, 16);
            this.lblProName.TabIndex = 62;
            this.lblProName.Text = "Product Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(501, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 22);
            this.txtName.TabIndex = 61;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Location = new System.Drawing.Point(501, 50);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(208, 22);
            this.txtQuantity.TabIndex = 60;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(402, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 59;
            this.label13.Text = "Quantity";
            // 
            // cbPaymentMethodID
            // 
            this.cbPaymentMethodID.FormattingEnabled = true;
            this.cbPaymentMethodID.Location = new System.Drawing.Point(531, 86);
            this.cbPaymentMethodID.Name = "cbPaymentMethodID";
            this.cbPaymentMethodID.Size = new System.Drawing.Size(178, 24);
            this.cbPaymentMethodID.TabIndex = 43;
            this.cbPaymentMethodID.SelectedIndexChanged += new System.EventHandler(this.cbPaymentMethodID_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(383, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(118, 16);
            this.label20.TabIndex = 41;
            this.label20.Text = "PaymentMethodID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Order History:";
            // 
            // grvOrders
            // 
            this.grvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvOrders.Location = new System.Drawing.Point(26, 195);
            this.grvOrders.Name = "grvOrders";
            this.grvOrders.RowHeadersWidth = 51;
            this.grvOrders.RowTemplate.Height = 24;
            this.grvOrders.Size = new System.Drawing.Size(1091, 324);
            this.grvOrders.TabIndex = 7;
            this.grvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvOrders_CellContentClick);
            // 
            // btAddOrder
            // 
            this.btAddOrder.BackColor = System.Drawing.Color.LightGreen;
            this.btAddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddOrder.Location = new System.Drawing.Point(774, 18);
            this.btAddOrder.Name = "btAddOrder";
            this.btAddOrder.Size = new System.Drawing.Size(164, 108);
            this.btAddOrder.TabIndex = 6;
            this.btAddOrder.Text = "CREATE ORDER";
            this.btAddOrder.UseVisualStyleBackColor = false;
            this.btAddOrder.Click += new System.EventHandler(this.btAddOrder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Date:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(96, 84);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(248, 22);
            this.dtpOrderDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Staff:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbEmployee
            // 
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(96, 44);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(248, 24);
            this.cbEmployee.TabIndex = 2;
            this.cbEmployee.SelectedIndexChanged += new System.EventHandler(this.cbEmployee_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer:";
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(96, 6);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(248, 24);
            this.cbCustomer.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grvProducts_Sales);
            this.tabPage1.Controls.Add(this.txtSearch_Product);
            this.tabPage1.Controls.Add(this.labelSearchPro);
            this.tabPage1.Controls.Add(this.txtProductID);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.txtQualitiInStock);
            this.tabPage1.Controls.Add(this.cbCategory);
            this.tabPage1.Controls.Add(this.cbSupplier);
            this.tabPage1.Controls.Add(this.lblProID);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lblProQty);
            this.tabPage1.Controls.Add(this.lblProCat);
            this.tabPage1.Controls.Add(this.lblProSup);
            this.tabPage1.Controls.Add(this.btAdd_Product);
            this.tabPage1.Controls.Add(this.btUpdate_Product);
            this.tabPage1.Controls.Add(this.btDelete_Product);
            this.tabPage1.Controls.Add(this.btRefresh_Product);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1143, 540);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = " Manage Product";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grvProducts_Sales
            // 
            this.grvProducts_Sales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvProducts_Sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvProducts_Sales.Location = new System.Drawing.Point(406, 42);
            this.grvProducts_Sales.Name = "grvProducts_Sales";
            this.grvProducts_Sales.RowHeadersWidth = 51;
            this.grvProducts_Sales.Size = new System.Drawing.Size(667, 492);
            this.grvProducts_Sales.TabIndex = 18;
            // 
            // txtSearch_Product
            // 
            this.txtSearch_Product.Location = new System.Drawing.Point(562, 6);
            this.txtSearch_Product.Name = "txtSearch_Product";
            this.txtSearch_Product.Size = new System.Drawing.Size(300, 22);
            this.txtSearch_Product.TabIndex = 19;
            this.txtSearch_Product.TextChanged += new System.EventHandler(this.txtSearch_Product_TextChanged);
            // 
            // labelSearchPro
            // 
            this.labelSearchPro.AutoSize = true;
            this.labelSearchPro.Location = new System.Drawing.Point(438, 12);
            this.labelSearchPro.Name = "labelSearchPro";
            this.labelSearchPro.Size = new System.Drawing.Size(102, 16);
            this.labelSearchPro.TabIndex = 20;
            this.labelSearchPro.Text = "Search Product:";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(136, 43);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(200, 22);
            this.txtProductID.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 22);
            this.textBox1.TabIndex = 22;
            // 
            // txtQualitiInStock
            // 
            this.txtQualitiInStock.Location = new System.Drawing.Point(136, 123);
            this.txtQualitiInStock.Name = "txtQualitiInStock";
            this.txtQualitiInStock.Size = new System.Drawing.Size(200, 22);
            this.txtQualitiInStock.TabIndex = 23;
            // 
            // cbCategory
            // 
            this.cbCategory.Location = new System.Drawing.Point(136, 163);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(200, 24);
            this.cbCategory.TabIndex = 24;
            // 
            // cbSupplier
            // 
            this.cbSupplier.Location = new System.Drawing.Point(136, 203);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(200, 24);
            this.cbSupplier.TabIndex = 25;
            // 
            // lblProID
            // 
            this.lblProID.AutoSize = true;
            this.lblProID.Location = new System.Drawing.Point(16, 43);
            this.lblProID.Name = "lblProID";
            this.lblProID.Size = new System.Drawing.Size(72, 16);
            this.lblProID.TabIndex = 26;
            this.lblProID.Text = "Product ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Product Name:";
            // 
            // lblProQty
            // 
            this.lblProQty.AutoSize = true;
            this.lblProQty.Location = new System.Drawing.Point(16, 123);
            this.lblProQty.Name = "lblProQty";
            this.lblProQty.Size = new System.Drawing.Size(95, 16);
            this.lblProQty.TabIndex = 28;
            this.lblProQty.Text = "Stock Quantity:";
            // 
            // lblProCat
            // 
            this.lblProCat.AutoSize = true;
            this.lblProCat.Location = new System.Drawing.Point(16, 163);
            this.lblProCat.Name = "lblProCat";
            this.lblProCat.Size = new System.Drawing.Size(65, 16);
            this.lblProCat.TabIndex = 29;
            this.lblProCat.Text = "Category:";
            // 
            // lblProSup
            // 
            this.lblProSup.AutoSize = true;
            this.lblProSup.Location = new System.Drawing.Point(16, 203);
            this.lblProSup.Name = "lblProSup";
            this.lblProSup.Size = new System.Drawing.Size(60, 16);
            this.lblProSup.TabIndex = 30;
            this.lblProSup.Text = "Supplier:";
            // 
            // btAdd_Product
            // 
            this.btAdd_Product.Location = new System.Drawing.Point(16, 253);
            this.btAdd_Product.Name = "btAdd_Product";
            this.btAdd_Product.Size = new System.Drawing.Size(100, 40);
            this.btAdd_Product.TabIndex = 31;
            this.btAdd_Product.Text = "Add";
            // 
            // btUpdate_Product
            // 
            this.btUpdate_Product.Location = new System.Drawing.Point(126, 253);
            this.btUpdate_Product.Name = "btUpdate_Product";
            this.btUpdate_Product.Size = new System.Drawing.Size(100, 40);
            this.btUpdate_Product.TabIndex = 32;
            this.btUpdate_Product.Text = "Update";
            // 
            // btDelete_Product
            // 
            this.btDelete_Product.Location = new System.Drawing.Point(236, 253);
            this.btDelete_Product.Name = "btDelete_Product";
            this.btDelete_Product.Size = new System.Drawing.Size(100, 40);
            this.btDelete_Product.TabIndex = 33;
            this.btDelete_Product.Text = "Delete";
            // 
            // btRefresh_Product
            // 
            this.btRefresh_Product.Location = new System.Drawing.Point(16, 303);
            this.btRefresh_Product.Name = "btRefresh_Product";
            this.btRefresh_Product.Size = new System.Drawing.Size(320, 40);
            this.btRefresh_Product.TabIndex = 34;
            this.btRefresh_Product.Text = "Refresh";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.Location = new System.Drawing.Point(1047, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(112, 38);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(16, 18);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(276, 25);
            this.labelWelcome.TabIndex = 2;
            this.labelWelcome.Text = "Sales Management System";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.dtpToDate);
            this.tabPage2.Controls.Add(this.dtpFromDate);
            this.tabPage2.Controls.Add(this.chartStatistics);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1143, 540);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Report";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartStatistics
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStatistics.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStatistics.Legends.Add(legend1);
            this.chartStatistics.Location = new System.Drawing.Point(266, 101);
            this.chartStatistics.Name = "chartStatistics";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStatistics.Series.Add(series1);
            this.chartStatistics.Size = new System.Drawing.Size(660, 364);
            this.chartStatistics.TabIndex = 0;
            this.chartStatistics.Text = "chart1";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(316, 54);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 22);
            this.dtpFromDate.TabIndex = 1;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(665, 54);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 22);
            this.dtpToDate.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(45, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 87);
            this.button2.TabIndex = 4;
            this.button2.Text = "Statistics by Customer";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(45, 331);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 87);
            this.button3.TabIndex = 5;
            this.button3.Text = "Revenue Over Time";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "From Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(662, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "To Date";
            // 
            // SalesDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 627);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Name = "SalesDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Dashboard - StoreX";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SalesDashboard_FormClosed);
            this.Load += new System.EventHandler(this.SalesDashboard_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpProducts.ResumeLayout(false);
            this.tpProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts)).EndInit();
            this.tpOrders.ResumeLayout(false);
            this.tpOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrders)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts_Sales)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpProducts;
        private System.Windows.Forms.TabPage tpOrders;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView grvProducts;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Button btAddOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grvOrders;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.ComboBox cbPaymentMethodID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblProName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grvProducts_Sales;
        private System.Windows.Forms.TextBox txtSearch_Product;
        private System.Windows.Forms.Label labelSearchPro;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtQualitiInStock;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.Label lblProID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblProQty;
        private System.Windows.Forms.Label lblProCat;
        private System.Windows.Forms.Label lblProSup;
        private System.Windows.Forms.Button btAdd_Product;
        private System.Windows.Forms.Button btUpdate_Product;
        private System.Windows.Forms.Button btDelete_Product;
        private System.Windows.Forms.Button btRefresh_Product;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistics;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
    }
}