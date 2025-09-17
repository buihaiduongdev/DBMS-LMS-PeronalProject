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
    public partial class frmQLNhanVien : Form
    {
        NhanVienService nhanVienService = new NhanVienService();
        public frmQLNhanVien()
        {
            InitializeComponent();
        }

        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                if(UserService.CurrentUser.VaiTro == 0)
                    gbKhoa.Visible = true;
                updateGridNV();
                dgvNhanVien.AllowUserToAddRows = false;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Bạn không đủ quyền hạn truy cập: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }
        private void updateGridNV()
        {
            if (UserService.CurrentUser.VaiTro == 0)
            {
                dgvNhanVien.DataSource = nhanVienService.GetAllNhanVien();
                dgvNhanVien.Columns["MatKhauMaHoa"].Visible = false;
                dgvNhanVien.Columns["TenDangNhap"].Visible = false;
            }
            else
                dgvNhanVien.DataSource = nhanVienService.GetNhanVienDetailsView();
        }
        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text;
            dgvNhanVien.DataSource = nhanVienService.TimKiemNhanVien(tuKhoa);
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            frmThemMoiNV frmThemMoiNV = new frmThemMoiNV();
            frmThemMoiNV.ShowDialog();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            updateGridNV();
        }

        private void btnKhoaChucNang_Click(object sender, EventArgs e)
        {

            if (nhanVienService.KhoaChucNang(1))
                MessageBox.Show("Đã khóa chức năng thao tác lên quản lý đọc giả đối với các nhân viên này!");
            if (nhanVienService.KhoaChucNang(0))
                MessageBox.Show("Đã mở chức năng thao tác lên quản lý đọc giả đối với các nhân viên!");
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            int iD = int.Parse(dgvNhanVien.Rows[e.RowIndex].Cells["IdNV"].Value?.ToString());
            string maNV = dgvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
            string hoTen = dgvNhanVien.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
            string soDienThoai = dgvNhanVien.Rows[e.RowIndex].Cells["SoDienThoai"].Value.ToString();
            string email = dgvNhanVien.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            DateTime ngaySinh = Convert.ToDateTime(dgvNhanVien.Rows[e.RowIndex].Cells["NgaySinh"].Value);
            string chucVu = dgvNhanVien.Rows[e.RowIndex].Cells["ChucVu"].Value.ToString();
            string trangThai = dgvNhanVien.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();

            string tenDangNhap = null;
            string matKhauMaHoa = null;
            if (dgvNhanVien.Columns.Contains("TenDangNhap"))
                tenDangNhap = dgvNhanVien.Rows[e.RowIndex].Cells["TenDangNhap"].Value?.ToString();
            if (dgvNhanVien.Columns.Contains("MatKhauMaHoa"))
                matKhauMaHoa = dgvNhanVien.Rows[e.RowIndex].Cells["MatKhauMaHoa"].Value?.ToString();

            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "Edit")
            {
                if (UserService.CurrentUser.VaiTro == 0) { 
                    NhanVien editNhanVien = new NhanVien(iD, hoTen, ngaySinh, email, soDienThoai, chucVu);
                    User editUser = new User(tenDangNhap, matKhauMaHoa, int.Parse(trangThai));
                    frmSuaNhanVien frmSuaNhanVien = new frmSuaNhanVien(editNhanVien, editUser);
                    frmSuaNhanVien.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn không đủ quyền hạn truy cập","Lỗi", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }

            }
            else if (dgvNhanVien.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn xóa đọc nhân viên này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (nhanVienService.DeleteNhanVien(iD))
                        {
                            MessageBox.Show("Xóa nhân viên thành công");
                            updateGridNV();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            else if (dgvNhanVien.Columns[e.ColumnIndex].Name == "MaNV")
            {
                txtTuKhoa.Text = maNV;
            }

        }


        private void btnOff_Click(object sender, EventArgs e)
        {

            if (nhanVienService.KhoaChucNang(1))
            {
                MessageBox.Show("Đã khóa chức năng thao tác lên quản lý độc giả đối với các nhân viên này!");
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            if (nhanVienService.KhoaChucNang(0))
            {
                MessageBox.Show("Đã mở chức năng thao tác lên quản lý độc giả đối với các nhân viên!");
            }
        }
    }
}
