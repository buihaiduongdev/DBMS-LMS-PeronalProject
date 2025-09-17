using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMSProject.Models;
using LMSProject.Services;

namespace LMSProject.Forms
{
    public partial class frmSuaNhanVien : Form
    {
        NhanVien editNhanVien;
        User editUser;
        NhanVienService nhanVienService = new NhanVienService();
        public frmSuaNhanVien(NhanVien editNhanVien, User editUser)
        {
            this.editNhanVien = editNhanVien;
            this.editUser = editUser;
            InitializeComponent();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            DateTime ngaysinh = dtpNgaySinh.Value;
            string email = txtEmail.Text.Trim();
            string chuVu = cbbChuVu.Text;
            NhanVien editedNhanVien = new NhanVien(editNhanVien.IdNV, hoTen, ngaysinh, email, soDienThoai, chuVu);
            if (nhanVienService.UpdateNhanVien(editedNhanVien))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                Close();
            }
            
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (nhanVienService.ResetMatKhauNhanVien(editNhanVien.IdNV))
            {
                MessageBox.Show("Mật khẩu reset: 123456");
            }
            
        }
        private void frmSuaNhanVien_Load(object sender, EventArgs e)
        {
            txtUSN.Text = editUser.TenDangNhap;
            txtMatKhau.Text = editUser.MatKhauMaHoa;
            txtHoTen.Text = editNhanVien.HoTen;
            txtSoDienThoai.Text = editNhanVien.SoDienThoai;
            txtEmail.Text = editNhanVien.Email;
            dtpNgaySinh.Value = editNhanVien.NgaySinh.Value;
            cbbChuVu.Text = editNhanVien.ChucVu;
        }
    }
}
