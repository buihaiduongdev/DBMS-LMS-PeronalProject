using LMSProject.Models;
using LMSProject.Services;
using LMSProject.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMSProject.Forms
{
    public partial class frmSuaDocGia : Form
    {
        DocGia docGia;
        public frmSuaDocGia(DocGia docGia)
        {
            this.docGia = docGia;
            InitializeComponent();
        }

        private void frmSuaDocGia_Load(object sender, EventArgs e)
        {
            txtMaDG.Text = DesignHelper.MappingID(docGia.ID);
            txtHoTen.Text = docGia.HoTen;
            dtpNgaySinh.Value = docGia.NgaySinh ?? DateTime.Now;
            txtDiaChi.Text = docGia.DiaChi;
            txtEmail.Text = docGia.Email;
            txtSoDienThoai.Text = docGia.SoDienThoai;
            dtpNgayDangKy.Value = docGia.NgayDangKy;
            dtpNgayHetHan.Value = docGia.NgayHetHan;
            cbbTrangThai.SelectedIndex = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string trangThai = cbbTrangThai.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            DateTime ngayDangKy = dtpNgayDangKy.Value;
            DateTime ngayHetHan = dtpNgayHetHan.Value;


            DocGiaService docGiaService = new DocGiaService();
            DocGia editDocGia = new DocGia(docGia.ID , hoTen, diaChi, soDienThoai, email, ngaySinh, ngayDangKy, ngayHetHan, trangThai);
            if (docGiaService.UpdateDocGia(editDocGia))
            {
                MessageBox.Show("Sửa thông tin đọc giả thành công");
                Close();
            }
        }
    }
}
