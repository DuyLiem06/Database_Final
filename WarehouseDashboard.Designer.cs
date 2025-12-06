namespace ASM_Final
{
    partial class WarehouseDashboard
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpProduct = new System.Windows.Forms.TabPage();
            this.grvProducts = new System.Windows.Forms.DataGridView();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtSearch_Product = new System.Windows.Forms.TextBox();
            this.txtQualitiInStock = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btRefresh_Product = new System.Windows.Forms.Button();
            this.btDelete_Product = new System.Windows.Forms.Button();
            this.btUpdate_Product = new System.Windows.Forms.Button();
            this.btAdd_Product = new System.Windows.Forms.Button();
            this.tpCategory = new System.Windows.Forms.TabPage();
            this.grvCategory = new System.Windows.Forms.DataGridView();
            this.cbCategoryID = new System.Windows.Forms.ComboBox();
            this.cbCategoryName = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.btRefresh_Category = new System.Windows.Forms.Button();
            this.btDelete_Category = new System.Windows.Forms.Button();
            this.btUpdate_Category = new System.Windows.Forms.Button();
            this.btAdd_Category = new System.Windows.Forms.Button();
            this.tpSupplier = new System.Windows.Forms.TabPage();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.cbSupplierID = new System.Windows.Forms.ComboBox();
            this.cbSupplierName = new System.Windows.Forms.ComboBox();
            this.txtSupplierPhone = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.txtSearch_Supplier = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.btRefresh_Supplier = new System.Windows.Forms.Button();
            this.btDelete_Supplier = new System.Windows.Forms.Button();
            this.btUpdate_Supplier = new System.Windows.Forms.Button();
            this.btAdd_Supplier = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts)).BeginInit();
            this.tpCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCategory)).BeginInit();
            this.tpSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpProduct);
            this.tabControl1.Controls.Add(this.tpCategory);
            this.tabControl1.Controls.Add(this.tpSupplier);
            this.tabControl1.Location = new System.Drawing.Point(12, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(958, 536);
            this.tabControl1.TabIndex = 0;
            // 
            // tpProduct
            // 
            this.tpProduct.Controls.Add(this.btnExport);
            this.tpProduct.Controls.Add(this.grvProducts);
            this.tpProduct.Controls.Add(this.cbSupplier);
            this.tpProduct.Controls.Add(this.cbCategory);
            this.tpProduct.Controls.Add(this.label30);
            this.tpProduct.Controls.Add(this.label31);
            this.tpProduct.Controls.Add(this.txtSearch_Product);
            this.tpProduct.Controls.Add(this.txtQualitiInStock);
            this.tpProduct.Controls.Add(this.txtName);
            this.tpProduct.Controls.Add(this.txtProductID);
            this.tpProduct.Controls.Add(this.label27);
            this.tpProduct.Controls.Add(this.label29);
            this.tpProduct.Controls.Add(this.label32);
            this.tpProduct.Controls.Add(this.label26);
            this.tpProduct.Controls.Add(this.btRefresh_Product);
            this.tpProduct.Controls.Add(this.btDelete_Product);
            this.tpProduct.Controls.Add(this.btUpdate_Product);
            this.tpProduct.Controls.Add(this.btAdd_Product);
            this.tpProduct.Location = new System.Drawing.Point(4, 25);
            this.tpProduct.Name = "tpProduct";
            this.tpProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tpProduct.Size = new System.Drawing.Size(950, 507);
            this.tpProduct.TabIndex = 0;
            this.tpProduct.Text = "Manage Product";
            this.tpProduct.UseVisualStyleBackColor = true;
            this.tpProduct.Click += new System.EventHandler(this.tpProduct_Click);
            // 
            // grvProducts
            // 
            this.grvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvProducts.Location = new System.Drawing.Point(380, 71);
            this.grvProducts.Name = "grvProducts";
            this.grvProducts.RowHeadersWidth = 51;
            this.grvProducts.RowTemplate.Height = 24;
            this.grvProducts.Size = new System.Drawing.Size(554, 349);
            this.grvProducts.TabIndex = 50;
            this.grvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvProducts_CellContentClick);
            // 
            // cbSupplier
            // 
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(140, 185);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(215, 24);
            this.cbSupplier.TabIndex = 49;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(140, 145);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(215, 24);
            this.cbCategory.TabIndex = 48;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(30, 188);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(60, 16);
            this.label30.TabIndex = 47;
            this.label30.Text = "Supplier:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(30, 148);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 16);
            this.label31.TabIndex = 46;
            this.label31.Text = "Category:";
            // 
            // txtSearch_Product
            // 
            this.txtSearch_Product.Location = new System.Drawing.Point(520, 25);
            this.txtSearch_Product.Name = "txtSearch_Product";
            this.txtSearch_Product.Size = new System.Drawing.Size(316, 22);
            this.txtSearch_Product.TabIndex = 45;
            this.txtSearch_Product.TextChanged += new System.EventHandler(this.txtSearch_Product_TextChanged);
            // 
            // txtQualitiInStock
            // 
            this.txtQualitiInStock.Location = new System.Drawing.Point(140, 265);
            this.txtQualitiInStock.Name = "txtQualitiInStock";
            this.txtQualitiInStock.Size = new System.Drawing.Size(215, 22);
            this.txtQualitiInStock.TabIndex = 44;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(140, 225);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(215, 22);
            this.txtName.TabIndex = 43;
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(140, 105);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(215, 22);
            this.txtProductID.TabIndex = 42;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(30, 268);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(95, 16);
            this.label27.TabIndex = 41;
            this.label27.Text = "Stock Quantity:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(30, 228);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 16);
            this.label29.TabIndex = 40;
            this.label29.Text = "Product Name:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(30, 108);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 16);
            this.label32.TabIndex = 39;
            this.label32.Text = "Product ID:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(400, 28);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(109, 16);
            this.label26.TabIndex = 38;
            this.label26.Text = "Search By Name";
            // 
            // btRefresh_Product
            // 
            this.btRefresh_Product.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh_Product.Location = new System.Drawing.Point(811, 440);
            this.btRefresh_Product.Name = "btRefresh_Product";
            this.btRefresh_Product.Size = new System.Drawing.Size(123, 49);
            this.btRefresh_Product.TabIndex = 37;
            this.btRefresh_Product.Text = "Refresh";
            this.btRefresh_Product.UseVisualStyleBackColor = true;
            this.btRefresh_Product.Click += new System.EventHandler(this.btRefresh_Product_Click);
            // 
            // btDelete_Product
            // 
            this.btDelete_Product.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete_Product.Location = new System.Drawing.Point(670, 440);
            this.btDelete_Product.Name = "btDelete_Product";
            this.btDelete_Product.Size = new System.Drawing.Size(123, 49);
            this.btDelete_Product.TabIndex = 36;
            this.btDelete_Product.Text = "Delete";
            this.btDelete_Product.UseVisualStyleBackColor = true;
            this.btDelete_Product.Click += new System.EventHandler(this.btDelete_Product_Click);
            // 
            // btUpdate_Product
            // 
            this.btUpdate_Product.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate_Product.Location = new System.Drawing.Point(525, 440);
            this.btUpdate_Product.Name = "btUpdate_Product";
            this.btUpdate_Product.Size = new System.Drawing.Size(123, 49);
            this.btUpdate_Product.TabIndex = 35;
            this.btUpdate_Product.Text = "Update";
            this.btUpdate_Product.UseVisualStyleBackColor = true;
            this.btUpdate_Product.Click += new System.EventHandler(this.btUpdate_Product_Click);
            // 
            // btAdd_Product
            // 
            this.btAdd_Product.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd_Product.Location = new System.Drawing.Point(380, 440);
            this.btAdd_Product.Name = "btAdd_Product";
            this.btAdd_Product.Size = new System.Drawing.Size(123, 49);
            this.btAdd_Product.TabIndex = 34;
            this.btAdd_Product.Text = "Add";
            this.btAdd_Product.UseVisualStyleBackColor = true;
            this.btAdd_Product.Click += new System.EventHandler(this.btAdd_Product_Click);
            // 
            // tpCategory
            // 
            this.tpCategory.Controls.Add(this.grvCategory);
            this.tpCategory.Controls.Add(this.cbCategoryID);
            this.tpCategory.Controls.Add(this.cbCategoryName);
            this.tpCategory.Controls.Add(this.label39);
            this.tpCategory.Controls.Add(this.label40);
            this.tpCategory.Controls.Add(this.txtCategoryName);
            this.tpCategory.Controls.Add(this.label34);
            this.tpCategory.Controls.Add(this.btRefresh_Category);
            this.tpCategory.Controls.Add(this.btDelete_Category);
            this.tpCategory.Controls.Add(this.btUpdate_Category);
            this.tpCategory.Controls.Add(this.btAdd_Category);
            this.tpCategory.Location = new System.Drawing.Point(4, 25);
            this.tpCategory.Name = "tpCategory";
            this.tpCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tpCategory.Size = new System.Drawing.Size(950, 507);
            this.tpCategory.TabIndex = 1;
            this.tpCategory.Text = "Manage Category";
            this.tpCategory.UseVisualStyleBackColor = true;
            this.tpCategory.Click += new System.EventHandler(this.tpCategory_Click);
            // 
            // grvCategory
            // 
            this.grvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvCategory.Location = new System.Drawing.Point(380, 71);
            this.grvCategory.Name = "grvCategory";
            this.grvCategory.RowHeadersWidth = 51;
            this.grvCategory.RowTemplate.Height = 24;
            this.grvCategory.Size = new System.Drawing.Size(554, 349);
            this.grvCategory.TabIndex = 53;
            this.grvCategory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvCategory_CellContentClick);
            // 
            // cbCategoryID
            // 
            this.cbCategoryID.FormattingEnabled = true;
            this.cbCategoryID.Location = new System.Drawing.Point(140, 145);
            this.cbCategoryID.Name = "cbCategoryID";
            this.cbCategoryID.Size = new System.Drawing.Size(215, 24);
            this.cbCategoryID.TabIndex = 52;
            // 
            // cbCategoryName
            // 
            this.cbCategoryName.FormattingEnabled = true;
            this.cbCategoryName.Location = new System.Drawing.Point(140, 105);
            this.cbCategoryName.Name = "cbCategoryName";
            this.cbCategoryName.Size = new System.Drawing.Size(215, 24);
            this.cbCategoryName.TabIndex = 51;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(30, 148);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(81, 16);
            this.label39.TabIndex = 50;
            this.label39.Text = "Category ID:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(30, 108);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(105, 16);
            this.label40.TabIndex = 49;
            this.label40.Text = "Category Name:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(520, 25);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(316, 22);
            this.txtCategoryName.TabIndex = 48;
            this.txtCategoryName.TextChanged += new System.EventHandler(this.txtCategoryName_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(400, 28);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(109, 16);
            this.label34.TabIndex = 47;
            this.label34.Text = "Search By Name";
            // 
            // btRefresh_Category
            // 
            this.btRefresh_Category.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh_Category.Location = new System.Drawing.Point(811, 440);
            this.btRefresh_Category.Name = "btRefresh_Category";
            this.btRefresh_Category.Size = new System.Drawing.Size(123, 49);
            this.btRefresh_Category.TabIndex = 46;
            this.btRefresh_Category.Text = "Refresh";
            this.btRefresh_Category.UseVisualStyleBackColor = true;
            this.btRefresh_Category.Click += new System.EventHandler(this.btRefresh_Category_Click);
            // 
            // btDelete_Category
            // 
            this.btDelete_Category.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete_Category.Location = new System.Drawing.Point(670, 440);
            this.btDelete_Category.Name = "btDelete_Category";
            this.btDelete_Category.Size = new System.Drawing.Size(123, 49);
            this.btDelete_Category.TabIndex = 45;
            this.btDelete_Category.Text = "Delete";
            this.btDelete_Category.UseVisualStyleBackColor = true;
            this.btDelete_Category.Click += new System.EventHandler(this.btDelete_Category_Click);
            // 
            // btUpdate_Category
            // 
            this.btUpdate_Category.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate_Category.Location = new System.Drawing.Point(525, 440);
            this.btUpdate_Category.Name = "btUpdate_Category";
            this.btUpdate_Category.Size = new System.Drawing.Size(123, 49);
            this.btUpdate_Category.TabIndex = 44;
            this.btUpdate_Category.Text = "Update";
            this.btUpdate_Category.UseVisualStyleBackColor = true;
            this.btUpdate_Category.Click += new System.EventHandler(this.btUpdate_Category_Click);
            // 
            // btAdd_Category
            // 
            this.btAdd_Category.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd_Category.Location = new System.Drawing.Point(380, 440);
            this.btAdd_Category.Name = "btAdd_Category";
            this.btAdd_Category.Size = new System.Drawing.Size(123, 49);
            this.btAdd_Category.TabIndex = 43;
            this.btAdd_Category.Text = "Add";
            this.btAdd_Category.UseVisualStyleBackColor = true;
            this.btAdd_Category.Click += new System.EventHandler(this.btAdd_Category_Click);
            // 
            // tpSupplier
            // 
            this.tpSupplier.Controls.Add(this.dgvSupplier);
            this.tpSupplier.Controls.Add(this.cbSupplierID);
            this.tpSupplier.Controls.Add(this.cbSupplierName);
            this.tpSupplier.Controls.Add(this.txtSupplierPhone);
            this.tpSupplier.Controls.Add(this.label47);
            this.tpSupplier.Controls.Add(this.label46);
            this.tpSupplier.Controls.Add(this.label48);
            this.tpSupplier.Controls.Add(this.txtSearch_Supplier);
            this.tpSupplier.Controls.Add(this.label42);
            this.tpSupplier.Controls.Add(this.btRefresh_Supplier);
            this.tpSupplier.Controls.Add(this.btDelete_Supplier);
            this.tpSupplier.Controls.Add(this.btUpdate_Supplier);
            this.tpSupplier.Controls.Add(this.btAdd_Supplier);
            this.tpSupplier.Location = new System.Drawing.Point(4, 25);
            this.tpSupplier.Name = "tpSupplier";
            this.tpSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tpSupplier.Size = new System.Drawing.Size(950, 507);
            this.tpSupplier.TabIndex = 2;
            this.tpSupplier.Text = "Manage Supplier";
            this.tpSupplier.UseVisualStyleBackColor = true;
            this.tpSupplier.Click += new System.EventHandler(this.tpSupplier_Click);
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplier.Location = new System.Drawing.Point(380, 71);
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.RowHeadersWidth = 51;
            this.dgvSupplier.RowTemplate.Height = 24;
            this.dgvSupplier.Size = new System.Drawing.Size(554, 349);
            this.dgvSupplier.TabIndex = 60;
            this.dgvSupplier.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellContentClick);
            // 
            // cbSupplierID
            // 
            this.cbSupplierID.FormattingEnabled = true;
            this.cbSupplierID.Location = new System.Drawing.Point(140, 105);
            this.cbSupplierID.Name = "cbSupplierID";
            this.cbSupplierID.Size = new System.Drawing.Size(215, 24);
            this.cbSupplierID.TabIndex = 59;
            this.cbSupplierID.SelectedIndexChanged += new System.EventHandler(this.cbSupplierID_SelectedIndexChanged);
            // 
            // cbSupplierName
            // 
            this.cbSupplierName.FormattingEnabled = true;
            this.cbSupplierName.Location = new System.Drawing.Point(140, 145);
            this.cbSupplierName.Name = "cbSupplierName";
            this.cbSupplierName.Size = new System.Drawing.Size(215, 24);
            this.cbSupplierName.TabIndex = 58;
            // 
            // txtSupplierPhone
            // 
            this.txtSupplierPhone.Location = new System.Drawing.Point(140, 185);
            this.txtSupplierPhone.Name = "txtSupplierPhone";
            this.txtSupplierPhone.Size = new System.Drawing.Size(215, 22);
            this.txtSupplierPhone.TabIndex = 57;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(30, 108);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(76, 16);
            this.label47.TabIndex = 56;
            this.label47.Text = "Supplier ID:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(30, 148);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(100, 16);
            this.label46.TabIndex = 55;
            this.label46.Text = "Supplier Name:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(30, 188);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(102, 16);
            this.label48.TabIndex = 54;
            this.label48.Text = "Supplier Phone:";
            // 
            // txtSearch_Supplier
            // 
            this.txtSearch_Supplier.Location = new System.Drawing.Point(520, 25);
            this.txtSearch_Supplier.Name = "txtSearch_Supplier";
            this.txtSearch_Supplier.Size = new System.Drawing.Size(316, 22);
            this.txtSearch_Supplier.TabIndex = 53;
            this.txtSearch_Supplier.TextChanged += new System.EventHandler(this.txtSearch_Supplier_TextChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(400, 28);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(109, 16);
            this.label42.TabIndex = 52;
            this.label42.Text = "Search By Name";
            // 
            // btRefresh_Supplier
            // 
            this.btRefresh_Supplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh_Supplier.Location = new System.Drawing.Point(811, 440);
            this.btRefresh_Supplier.Name = "btRefresh_Supplier";
            this.btRefresh_Supplier.Size = new System.Drawing.Size(123, 49);
            this.btRefresh_Supplier.TabIndex = 51;
            this.btRefresh_Supplier.Text = "Refresh";
            this.btRefresh_Supplier.UseVisualStyleBackColor = true;
            this.btRefresh_Supplier.Click += new System.EventHandler(this.btRefresh_Supplier_Click);
            // 
            // btDelete_Supplier
            // 
            this.btDelete_Supplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete_Supplier.Location = new System.Drawing.Point(670, 440);
            this.btDelete_Supplier.Name = "btDelete_Supplier";
            this.btDelete_Supplier.Size = new System.Drawing.Size(123, 49);
            this.btDelete_Supplier.TabIndex = 50;
            this.btDelete_Supplier.Text = "Delete";
            this.btDelete_Supplier.UseVisualStyleBackColor = true;
            this.btDelete_Supplier.Click += new System.EventHandler(this.btDelete_Supplier_Click);
            // 
            // btUpdate_Supplier
            // 
            this.btUpdate_Supplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate_Supplier.Location = new System.Drawing.Point(525, 440);
            this.btUpdate_Supplier.Name = "btUpdate_Supplier";
            this.btUpdate_Supplier.Size = new System.Drawing.Size(123, 49);
            this.btUpdate_Supplier.TabIndex = 49;
            this.btUpdate_Supplier.Text = "Update";
            this.btUpdate_Supplier.UseVisualStyleBackColor = true;
            this.btUpdate_Supplier.Click += new System.EventHandler(this.btUpdate_Supplier_Click);
            // 
            // btAdd_Supplier
            // 
            this.btAdd_Supplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd_Supplier.Location = new System.Drawing.Point(380, 440);
            this.btAdd_Supplier.Name = "btAdd_Supplier";
            this.btAdd_Supplier.Size = new System.Drawing.Size(123, 49);
            this.btAdd_Supplier.TabIndex = 48;
            this.btAdd_Supplier.Text = "Add";
            this.btAdd_Supplier.UseVisualStyleBackColor = true;
            this.btAdd_Supplier.Click += new System.EventHandler(this.btAdd_Supplier_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.Location = new System.Drawing.Point(854, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(112, 37);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(12, 17);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(234, 25);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.Text = "Warehouse Dashboard";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(84, 329);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(158, 62);
            this.btnExport.TabIndex = 51;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // WarehouseDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Name = "WarehouseDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse Dashboard - StoreX";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WarehouseDashboard_FormClosed);
            this.Load += new System.EventHandler(this.WarehouseDashboard_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpProduct.ResumeLayout(false);
            this.tpProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts)).EndInit();
            this.tpCategory.ResumeLayout(false);
            this.tpCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCategory)).EndInit();
            this.tpSupplier.ResumeLayout(false);
            this.tpSupplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpProduct;
        private System.Windows.Forms.TabPage tpCategory;
        private System.Windows.Forms.TabPage tpSupplier;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label labelHeader;

        // Product Tab Controls
        private System.Windows.Forms.Button btAdd_Product;
        private System.Windows.Forms.Button btUpdate_Product;
        private System.Windows.Forms.Button btDelete_Product;
        private System.Windows.Forms.Button btRefresh_Product;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtQualitiInStock;
        private System.Windows.Forms.TextBox txtSearch_Product;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.DataGridView grvProducts;

        // Category Tab Controls
        private System.Windows.Forms.Button btAdd_Category;
        private System.Windows.Forms.Button btUpdate_Category;
        private System.Windows.Forms.Button btDelete_Category;
        private System.Windows.Forms.Button btRefresh_Category;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cbCategoryName;
        private System.Windows.Forms.ComboBox cbCategoryID;
        private System.Windows.Forms.DataGridView grvCategory;

        // Supplier Tab Controls
        private System.Windows.Forms.Button btAdd_Supplier;
        private System.Windows.Forms.Button btUpdate_Supplier;
        private System.Windows.Forms.Button btDelete_Supplier;
        private System.Windows.Forms.Button btRefresh_Supplier;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtSearch_Supplier;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtSupplierPhone;
        private System.Windows.Forms.ComboBox cbSupplierName;
        private System.Windows.Forms.ComboBox cbSupplierID;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.Button btnExport;
    }
}