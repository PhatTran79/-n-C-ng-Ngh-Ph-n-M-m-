
namespace QLBH
{
    partial class fManagers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fManagers));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbThanhTien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numGiamGia = new System.Windows.Forms.NumericUpDown();
            this.panel7 = new System.Windows.Forms.Panel();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnAddHangHoa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowHangHoa = new System.Windows.Forms.Button();
            this.txbGiaBan = new System.Windows.Forms.TextBox();
            this.cbxMaHangHoa = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgvCheckHangHoa = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCheckHangHoa)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.Controls.Add(this.txbThanhTien);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numGiamGia);
            this.panel1.Location = new System.Drawing.Point(365, 338);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 32);
            this.panel1.TabIndex = 10;
            // 
            // txbThanhTien
            // 
            this.txbThanhTien.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbThanhTien.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbThanhTien.Location = new System.Drawing.Point(88, 5);
            this.txbThanhTien.Margin = new System.Windows.Forms.Padding(2);
            this.txbThanhTien.Name = "txbThanhTien";
            this.txbThanhTien.ReadOnly = true;
            this.txbThanhTien.Size = new System.Drawing.Size(176, 24);
            this.txbThanhTien.TabIndex = 7;
            this.txbThanhTien.Text = "0";
            this.txbThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tổng tiền:";
            // 
            // numGiamGia
            // 
            this.numGiamGia.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numGiamGia.Location = new System.Drawing.Point(268, 9);
            this.numGiamGia.Margin = new System.Windows.Forms.Padding(2);
            this.numGiamGia.Name = "numGiamGia";
            this.numGiamGia.Size = new System.Drawing.Size(43, 20);
            this.numGiamGia.TabIndex = 7;
            this.numGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.numSoLuong);
            this.panel7.Controls.Add(this.btnAddHangHoa);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.btnShowHangHoa);
            this.panel7.Controls.Add(this.txbGiaBan);
            this.panel7.Controls.Add(this.cbxMaHangHoa);
            this.panel7.Location = new System.Drawing.Point(11, 338);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(352, 84);
            this.panel7.TabIndex = 9;
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(320, 6);
            this.numSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.numSoLuong.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(32, 20);
            this.numSoLuong.TabIndex = 11;
            // 
            // btnAddHangHoa
            // 
            this.btnAddHangHoa.BackColor = System.Drawing.Color.White;
            this.btnAddHangHoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHangHoa.ForeColor = System.Drawing.Color.Firebrick;
            this.btnAddHangHoa.Image = global::QLBH.Properties.Resources.cart;
            this.btnAddHangHoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddHangHoa.Location = new System.Drawing.Point(245, 34);
            this.btnAddHangHoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddHangHoa.Name = "btnAddHangHoa";
            this.btnAddHangHoa.Size = new System.Drawing.Size(105, 43);
            this.btnAddHangHoa.TabIndex = 10;
            this.btnAddHangHoa.Text = "Thêm vào\r\ngiỏ hàng";
            this.btnAddHangHoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddHangHoa.UseVisualStyleBackColor = false;
            this.btnAddHangHoa.Click += new System.EventHandler(this.btnAddHangHoa_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Đơn giá:";
            // 
            // btnShowHangHoa
            // 
            this.btnShowHangHoa.BackColor = System.Drawing.Color.White;
            this.btnShowHangHoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowHangHoa.ForeColor = System.Drawing.Color.Firebrick;
            this.btnShowHangHoa.Image = global::QLBH.Properties.Resources.view;
            this.btnShowHangHoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowHangHoa.Location = new System.Drawing.Point(166, 34);
            this.btnShowHangHoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowHangHoa.Name = "btnShowHangHoa";
            this.btnShowHangHoa.Size = new System.Drawing.Size(75, 43);
            this.btnShowHangHoa.TabIndex = 12;
            this.btnShowHangHoa.Text = "Xem";
            this.btnShowHangHoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowHangHoa.UseVisualStyleBackColor = false;
            this.btnShowHangHoa.Click += new System.EventHandler(this.btnShowHangHoa_Click_1);
            // 
            // txbGiaBan
            // 
            this.txbGiaBan.Location = new System.Drawing.Point(59, 48);
            this.txbGiaBan.Margin = new System.Windows.Forms.Padding(2);
            this.txbGiaBan.Name = "txbGiaBan";
            this.txbGiaBan.ReadOnly = true;
            this.txbGiaBan.Size = new System.Drawing.Size(103, 20);
            this.txbGiaBan.TabIndex = 13;
            // 
            // cbxMaHangHoa
            // 
            this.cbxMaHangHoa.ForeColor = System.Drawing.Color.Firebrick;
            this.cbxMaHangHoa.FormattingEnabled = true;
            this.cbxMaHangHoa.Location = new System.Drawing.Point(4, 6);
            this.cbxMaHangHoa.Margin = new System.Windows.Forms.Padding(2);
            this.cbxMaHangHoa.Name = "cbxMaHangHoa";
            this.cbxMaHangHoa.Size = new System.Drawing.Size(312, 21);
            this.cbxMaHangHoa.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnCheckOut);
            this.panel5.Location = new System.Drawing.Point(365, 372);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(314, 50);
            this.panel5.TabIndex = 8;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.White;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCheckOut.Image = global::QLBH.Properties.Resources.pay;
            this.btnCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckOut.Location = new System.Drawing.Point(171, 2);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(117, 43);
            this.btnCheckOut.TabIndex = 7;
            this.btnCheckOut.Text = "Thanh\r\n toán";
            this.btnCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SeaGreen;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(688, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.adminToolStripMenuItem.Image = global::QLBH.Properties.Resources.admin_login;
            this.adminToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảngToolStripMenuItem
            // 
            this.thôngTinTàiKhoảngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảngToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.thôngTinTàiKhoảngToolStripMenuItem.Name = "thôngTinTàiKhoảngToolStripMenuItem";
            this.thôngTinTàiKhoảngToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.thôngTinTàiKhoảngToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Image = global::QLBH.Properties.Resources.information;
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = global::QLBH.Properties.Resources.log_out;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgvCheckHangHoa);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(11, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(352, 305);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết hàng hoá";
            // 
            // dtgvCheckHangHoa
            // 
            this.dtgvCheckHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCheckHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvCheckHangHoa.Location = new System.Drawing.Point(2, 15);
            this.dtgvCheckHangHoa.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvCheckHangHoa.Name = "dtgvCheckHangHoa";
            this.dtgvCheckHangHoa.RowHeadersWidth = 51;
            this.dtgvCheckHangHoa.RowTemplate.Height = 24;
            this.dtgvCheckHangHoa.Size = new System.Drawing.Size(348, 288);
            this.dtgvCheckHangHoa.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(368, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 305);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết đơn hàng";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.dtgvChiTietHoaDon);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(367, 49);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(314, 285);
            this.panel3.TabIndex = 8;
            // 
            // dtgvChiTietHoaDon
            // 
            this.dtgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvChiTietHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvChiTietHoaDon.Location = new System.Drawing.Point(0, 0);
            this.dtgvChiTietHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvChiTietHoaDon.Name = "dtgvChiTietHoaDon";
            this.dtgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dtgvChiTietHoaDon.RowTemplate.Height = 24;
            this.dtgvChiTietHoaDon.Size = new System.Drawing.Size(314, 285);
            this.dtgvChiTietHoaDon.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(2, -67);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(310, 62);
            this.panel6.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(2, 330);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(310, 67);
            this.panel4.TabIndex = 3;
            // 
            // fManagers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(688, 426);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fManagers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lí bán hàng";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.panel5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCheckHangHoa)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbThanhTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numGiamGia;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảngToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgvCheckHangHoa;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnAddHangHoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowHangHoa;
        private System.Windows.Forms.TextBox txbGiaBan;
        private System.Windows.Forms.ComboBox cbxMaHangHoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvChiTietHoaDon;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
    }
}

