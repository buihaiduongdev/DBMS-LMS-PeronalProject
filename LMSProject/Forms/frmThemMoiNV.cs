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
using LMSProject.Utils;

namespace LMSProject.Forms
{
    public partial class frmThemMoiNV : Form
    {
        public frmThemMoiNV()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUSN.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text)
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            DateTime ngaysinh = dtpNgaySinh.Value;
            string email = txtEmail.Text.Trim();
            string chuVu = cbbChuVu.Text;

            string usn = txtUSN.Text;
            string hashedPassword = SecurityHelper.HashMD5(txtMatKhau.Text);

            NhanVienService nhanVienService = new NhanVienService();
            User newUser = new User(usn, hashedPassword, 1);
            NhanVien newNhanVien = new NhanVien(hoTen, ngaysinh, email, soDienThoai, chuVu);
            if (nhanVienService.InsertNhanVien(newNhanVien, newUser))
            {
                MessageBox.Show("Thêm mới thành công thành công");
                Close();
            }
        }

        private void frmThemMoiNV_Load(object sender, EventArgs e)
        {
            cbbChuVu.SelectedIndex = 0;
        }
    }
}
