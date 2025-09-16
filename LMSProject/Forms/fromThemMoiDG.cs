using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMSProject.Models;
using LMSProject.Services;

namespace LMSProject.Forms
{
    public partial class fromThemMoiDG : Form
    {
        public fromThemMoiDG()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
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
            DateTime ngaySinh = dtpNgaySinh.Value;
            DateTime ngayDangKy = dtpNgayDangKy.Value;
            DateTime ngayHetHan = dtpNgayHetHan.Value;


            DocGiaService docGiaService = new DocGiaService();
            DocGia newDocGia = new DocGia(hoTen, diaChi, soDienThoai, email, ngaySinh, ngayDangKy, ngayHetHan);
            if (docGiaService.InsertDocGia(newDocGia))
            {
                MessageBox.Show("Thêm mới đọc giả thành công");
                txtHoTen.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtSoDienThoai.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
        }

        private void fromThemMoiDG_Load(object sender, EventArgs e)
        {
            dtpNgayDangKy.Value = DateTime.Today;
            dtpNgayHetHan.Value = DateTime.Today.AddMonths(3);
        }
    }
}
