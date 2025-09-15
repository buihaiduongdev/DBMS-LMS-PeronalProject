namespace LMSProject.Forms
{
    partial class frmQLDocGia
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
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnKhoaChucNang = new System.Windows.Forms.Button();
            this.btnDanhSachSHH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete});
            this.dgvDocGia.Location = new System.Drawing.Point(12, 135);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.Size = new System.Drawing.Size(952, 472);
            this.dgvDocGia.TabIndex = 0;
            this.dgvDocGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocGia_CellClick);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Width = 50;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Width = 50;
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(12, 109);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(151, 20);
            this.txtTuKhoa.TabIndex = 1;
            this.txtTuKhoa.TextChanged += new System.EventHandler(this.txtTuKhoa_TextChanged);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(169, 109);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(85, 23);
            this.btnThemMoi.TabIndex = 2;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(351, 109);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(85, 23);
            this.btnGiaHan.TabIndex = 3;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(260, 109);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(85, 23);
            this.btnKiemTra.TabIndex = 4;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnKhoaChucNang
            // 
            this.btnKhoaChucNang.Location = new System.Drawing.Point(829, 109);
            this.btnKhoaChucNang.Name = "btnKhoaChucNang";
            this.btnKhoaChucNang.Size = new System.Drawing.Size(135, 23);
            this.btnKhoaChucNang.TabIndex = 5;
            this.btnKhoaChucNang.Text = "Khóa chức năng";
            this.btnKhoaChucNang.UseVisualStyleBackColor = true;
            this.btnKhoaChucNang.Visible = false;
            this.btnKhoaChucNang.Click += new System.EventHandler(this.btnKhoaChucNang_Click);
            // 
            // btnDanhSachSHH
            // 
            this.btnDanhSachSHH.Location = new System.Drawing.Point(442, 109);
            this.btnDanhSachSHH.Name = "btnDanhSachSHH";
            this.btnDanhSachSHH.Size = new System.Drawing.Size(132, 23);
            this.btnDanhSachSHH.TabIndex = 6;
            this.btnDanhSachSHH.Text = "Danh sách sắp hết hạn";
            this.btnDanhSachSHH.UseVisualStyleBackColor = true;
            this.btnDanhSachSHH.Click += new System.EventHandler(this.btnDanhSachSHH_Click);
            // 
            // frmQLDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 619);
            this.Controls.Add(this.btnDanhSachSHH);
            this.Controls.Add(this.btnKhoaChucNang);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.dgvDocGia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQLDocGia";
            this.Text = "frmQLSach";
            this.Load += new System.EventHandler(this.frmQLDocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocGia;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Button btnKhoaChucNang;
        private System.Windows.Forms.Button btnDanhSachSHH;
    }
}