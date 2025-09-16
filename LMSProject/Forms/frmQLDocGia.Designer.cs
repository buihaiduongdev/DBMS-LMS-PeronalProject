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
            this.btnDanhSachSHH = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete});
            this.dgvDocGia.Location = new System.Drawing.Point(16, 59);
            this.dgvDocGia.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.RowHeadersWidth = 51;
            this.dgvDocGia.Size = new System.Drawing.Size(1155, 726);
            this.dgvDocGia.TabIndex = 0;
            this.dgvDocGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocGia_CellClick);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.MinimumWidth = 6;
            this.Edit.Name = "Edit";
            this.Edit.Width = 50;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.Width = 50;
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(16, 19);
            this.txtTuKhoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(173, 27);
            this.txtTuKhoa.TabIndex = 1;
            this.txtTuKhoa.TextChanged += new System.EventHandler(this.txtTuKhoa_TextChanged);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(195, 18);
            this.btnThemMoi.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(141, 36);
            this.btnThemMoi.TabIndex = 2;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(498, 18);
            this.btnGiaHan.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(141, 36);
            this.btnGiaHan.TabIndex = 3;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(347, 18);
            this.btnKiemTra.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(141, 36);
            this.btnKiemTra.TabIndex = 4;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnDanhSachSHH
            // 
            this.btnDanhSachSHH.Location = new System.Drawing.Point(649, 18);
            this.btnDanhSachSHH.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDanhSachSHH.Name = "btnDanhSachSHH";
            this.btnDanhSachSHH.Size = new System.Drawing.Size(190, 36);
            this.btnDanhSachSHH.TabIndex = 6;
            this.btnDanhSachSHH.Text = "Danh sách sắp hết hạn";
            this.btnDanhSachSHH.UseVisualStyleBackColor = true;
            this.btnDanhSachSHH.Click += new System.EventHandler(this.btnDanhSachSHH_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(849, 18);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(141, 36);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmQLDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 844);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnDanhSachSHH);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.dgvDocGia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
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
        private System.Windows.Forms.Button btnDanhSachSHH;
        private System.Windows.Forms.Button btnLamMoi;
    }
}