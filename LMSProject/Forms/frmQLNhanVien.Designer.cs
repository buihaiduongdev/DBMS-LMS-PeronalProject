namespace LMSProject.Forms
{
    partial class frmQLNhanVien
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
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnOn = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.gbKhoa = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.gbKhoa.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete});
            this.dgvNhanVien.Location = new System.Drawing.Point(28, 85);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.Size = new System.Drawing.Size(1155, 701);
            this.dgvNhanVien.TabIndex = 8;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
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
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(358, 20);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(141, 36);
            this.btnLamMoi.TabIndex = 14;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(207, 19);
            this.btnThemMoi.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(141, 36);
            this.btnThemMoi.TabIndex = 10;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(28, 20);
            this.txtTuKhoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(173, 20);
            this.txtTuKhoa.TabIndex = 9;
            this.txtTuKhoa.TextChanged += new System.EventHandler(this.txtTuKhoa_TextChanged);
            // 
            // btnOn
            // 
            this.btnOn.Location = new System.Drawing.Point(109, 20);
            this.btnOn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(83, 36);
            this.btnOn.TabIndex = 15;
            this.btnOn.Text = "Mở";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // btnOff
            // 
            this.btnOff.Location = new System.Drawing.Point(8, 20);
            this.btnOff.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(83, 36);
            this.btnOff.TabIndex = 16;
            this.btnOff.Text = "Khóa";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // gbKhoa
            // 
            this.gbKhoa.Controls.Add(this.btnOff);
            this.gbKhoa.Controls.Add(this.btnOn);
            this.gbKhoa.Location = new System.Drawing.Point(983, 12);
            this.gbKhoa.Name = "gbKhoa";
            this.gbKhoa.Size = new System.Drawing.Size(200, 66);
            this.gbKhoa.TabIndex = 17;
            this.gbKhoa.TabStop = false;
            this.gbKhoa.Text = "Chức năng thao tác lên đọc giả";
            this.gbKhoa.Visible = false;
            // 
            // frmQLNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 805);
            this.Controls.Add(this.gbKhoa);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.txtTuKhoa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQLNhanVien";
            this.Text = "frmQLNhanVien";
            this.Load += new System.EventHandler(this.frmQLNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.gbKhoa.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.GroupBox gbKhoa;
    }
}