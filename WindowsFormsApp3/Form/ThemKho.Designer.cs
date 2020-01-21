namespace WindowsFormsApp3.Form
{
    partial class ThemKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemKho));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.mmGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtDTKho = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDiaChiKho = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ckbConQuanLy = new System.Windows.Forms.CheckBox();
            this.txtTenKho = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaKho = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDTKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(402, 313);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnDong);
            this.panelControl2.Controls.Add(this.btnLuu);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 262);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(398, 49);
            this.panelControl2.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.ImageOptions.Image")));
            this.btnDong.Location = new System.Drawing.Point(231, 15);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(94, 29);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(89, 15);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(94, 29);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.mmGhiChu);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.txtDTKho);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.txtDiaChiKho);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 111);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(398, 200);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Thông Tin Khác";
            // 
            // mmGhiChu
            // 
            this.mmGhiChu.Location = new System.Drawing.Point(77, 93);
            this.mmGhiChu.Name = "mmGhiChu";
            this.mmGhiChu.Size = new System.Drawing.Size(286, 52);
            this.mmGhiChu.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 107);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(44, 16);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Ghi Chú";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 68);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 17);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Điện Thoại";
            // 
            // txtDTKho
            // 
            this.txtDTKho.Location = new System.Drawing.Point(77, 65);
            this.txtDTKho.Name = "txtDTKho";
            this.txtDTKho.Size = new System.Drawing.Size(286, 22);
            this.txtDTKho.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 17);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Địa Chỉ";
            // 
            // txtDiaChiKho
            // 
            this.txtDiaChiKho.Location = new System.Drawing.Point(77, 37);
            this.txtDiaChiKho.Name = "txtDiaChiKho";
            this.txtDiaChiKho.Size = new System.Drawing.Size(286, 22);
            this.txtDiaChiKho.TabIndex = 0;
            this.txtDiaChiKho.EditValueChanged += new System.EventHandler(this.textEdit3_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ckbConQuanLy);
            this.groupControl1.Controls.Add(this.txtTenKho);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtMaKho);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(398, 109);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông Tin Bắt Buộc";
            // 
            // ckbConQuanLy
            // 
            this.ckbConQuanLy.AutoSize = true;
            this.ckbConQuanLy.Location = new System.Drawing.Point(254, 30);
            this.ckbConQuanLy.Name = "ckbConQuanLy";
            this.ckbConQuanLy.Size = new System.Drawing.Size(109, 21);
            this.ckbConQuanLy.TabIndex = 4;
            this.ckbConQuanLy.Text = "còn Quản Lý";
            this.ckbConQuanLy.UseVisualStyleBackColor = true;
            // 
            // txtTenKho
            // 
            this.txtTenKho.Location = new System.Drawing.Point(77, 65);
            this.txtTenKho.Name = "txtTenKho";
            this.txtTenKho.Size = new System.Drawing.Size(286, 22);
            this.txtTenKho.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tên";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mã ";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtMaKho
            // 
            this.txtMaKho.Location = new System.Drawing.Point(77, 29);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Size = new System.Drawing.Size(171, 22);
            this.txtMaKho.TabIndex = 0;
            // 
            // ThemKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 313);
            this.Controls.Add(this.panelControl1);
            this.Name = "ThemKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Kho";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDTKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtMaKho;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtDiaChiKho;
        private System.Windows.Forms.CheckBox ckbConQuanLy;
        private DevExpress.XtraEditors.TextEdit txtTenKho;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtDTKho;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.MemoEdit mmGhiChu;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}