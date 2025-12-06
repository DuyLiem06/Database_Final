namespace ASM_Final
{
    partial class Manager_PaymentMethod
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
            this.txtPaymentMethodID = new System.Windows.Forms.TextBox();
            this.txtMethodName = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch_Product = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.grvPaymentMethod = new System.Windows.Forms.DataGridView();
            this.btRefresh_PaymentMethod = new System.Windows.Forms.Button();
            this.btDelete_PaymentMethod = new System.Windows.Forms.Button();
            this.btUpdate_PaymentMethod = new System.Windows.Forms.Button();
            this.btAdd_PaymentMethod = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grvPaymentMethod)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPaymentMethodID
            // 
            this.txtPaymentMethodID.Location = new System.Drawing.Point(155, 158);
            this.txtPaymentMethodID.Name = "txtPaymentMethodID";
            this.txtPaymentMethodID.Size = new System.Drawing.Size(141, 22);
            this.txtPaymentMethodID.TabIndex = 0;
            // 
            // txtMethodName
            // 
            this.txtMethodName.Location = new System.Drawing.Point(155, 204);
            this.txtMethodName.Name = "txtMethodName";
            this.txtMethodName.Size = new System.Drawing.Size(141, 22);
            this.txtMethodName.TabIndex = 1;
            this.txtMethodName.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "PaymentMethodID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "MethodName";
            // 
            // txtSearch_Product
            // 
            this.txtSearch_Product.Location = new System.Drawing.Point(442, 89);
            this.txtSearch_Product.Name = "txtSearch_Product";
            this.txtSearch_Product.Size = new System.Drawing.Size(316, 22);
            this.txtSearch_Product.TabIndex = 47;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(322, 92);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(109, 16);
            this.label26.TabIndex = 46;
            this.label26.Text = "Search By Name";
            // 
            // grvPaymentMethod
            // 
            this.grvPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grvPaymentMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvPaymentMethod.Location = new System.Drawing.Point(320, 131);
            this.grvPaymentMethod.Name = "grvPaymentMethod";
            this.grvPaymentMethod.RowHeadersWidth = 51;
            this.grvPaymentMethod.RowTemplate.Height = 24;
            this.grvPaymentMethod.Size = new System.Drawing.Size(605, 289);
            this.grvPaymentMethod.TabIndex = 48;
            this.grvPaymentMethod.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Order_CellContentClick);
            // 
            // btRefresh_PaymentMethod
            // 
            this.btRefresh_PaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh_PaymentMethod.Location = new System.Drawing.Point(777, 445);
            this.btRefresh_PaymentMethod.Name = "btRefresh_PaymentMethod";
            this.btRefresh_PaymentMethod.Size = new System.Drawing.Size(123, 49);
            this.btRefresh_PaymentMethod.TabIndex = 52;
            this.btRefresh_PaymentMethod.Text = "Refresh";
            this.btRefresh_PaymentMethod.UseVisualStyleBackColor = true;
            // 
            // btDelete_PaymentMethod
            // 
            this.btDelete_PaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete_PaymentMethod.Location = new System.Drawing.Point(636, 445);
            this.btDelete_PaymentMethod.Name = "btDelete_PaymentMethod";
            this.btDelete_PaymentMethod.Size = new System.Drawing.Size(123, 49);
            this.btDelete_PaymentMethod.TabIndex = 51;
            this.btDelete_PaymentMethod.Text = "Delete";
            this.btDelete_PaymentMethod.UseVisualStyleBackColor = true;
            // 
            // btUpdate_PaymentMethod
            // 
            this.btUpdate_PaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate_PaymentMethod.Location = new System.Drawing.Point(491, 445);
            this.btUpdate_PaymentMethod.Name = "btUpdate_PaymentMethod";
            this.btUpdate_PaymentMethod.Size = new System.Drawing.Size(123, 49);
            this.btUpdate_PaymentMethod.TabIndex = 50;
            this.btUpdate_PaymentMethod.Text = "Update";
            this.btUpdate_PaymentMethod.UseVisualStyleBackColor = true;
            // 
            // btAdd_PaymentMethod
            // 
            this.btAdd_PaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd_PaymentMethod.Location = new System.Drawing.Point(346, 445);
            this.btAdd_PaymentMethod.Name = "btAdd_PaymentMethod";
            this.btAdd_PaymentMethod.Size = new System.Drawing.Size(123, 49);
            this.btAdd_PaymentMethod.TabIndex = 49;
            this.btAdd_PaymentMethod.Text = "Add";
            this.btAdd_PaymentMethod.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.Location = new System.Drawing.Point(813, 54);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(112, 37);
            this.btnLogout.TabIndex = 53;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // Manager_PaymentMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 519);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btRefresh_PaymentMethod);
            this.Controls.Add(this.btDelete_PaymentMethod);
            this.Controls.Add(this.btUpdate_PaymentMethod);
            this.Controls.Add(this.btAdd_PaymentMethod);
            this.Controls.Add(this.grvPaymentMethod);
            this.Controls.Add(this.txtSearch_Product);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMethodName);
            this.Controls.Add(this.txtPaymentMethodID);
            this.Name = "Manager_PaymentMethod";
            this.Text = "Manager_PaymentMethod";
            ((System.ComponentModel.ISupportInitialize)(this.grvPaymentMethod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPaymentMethodID;
        private System.Windows.Forms.MaskedTextBox txtMethodName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch_Product;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridView grvPaymentMethod;
        private System.Windows.Forms.Button btRefresh_PaymentMethod;
        private System.Windows.Forms.Button btDelete_PaymentMethod;
        private System.Windows.Forms.Button btUpdate_PaymentMethod;
        private System.Windows.Forms.Button btAdd_PaymentMethod;
        private System.Windows.Forms.Button btnLogout;
    }
}