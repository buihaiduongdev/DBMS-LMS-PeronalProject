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
    public partial class frmQLDocGia : Form
    {
        public frmQLDocGia()
        {
            InitializeComponent();
        }
        //private List<DocGia> docGiaList;
        DocGiaService docGiaService = new DocGiaService();

        private void frmQLDocGia_Load(object sender, EventArgs e)
        {
            dgvDocGia.DataSource = docGiaService.GetAllDocGia();
            dgvDocGia.AllowUserToAddRows = false;

        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text;
            dgvDocGia.DataSource = docGiaService.TimKiemDocGia(tuKhoa);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            fromThemMoiDG fromThemMoiDG = new fromThemMoiDG();
            fromThemMoiDG.ShowDialog();
        }


        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string maDG = txtTuKhoa.Text;
            if (maDG.Equals(string.Empty))
                MessageBox.Show("Vui lòng nhập mã đọc giả");
            else
                MessageBox.Show(docGiaService.KiemTraTrangThaiThe(maDG));
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            string maDG = txtTuKhoa.Text;
            if (maDG.Equals(string.Empty))
                MessageBox.Show("Vui lòng nhập mã đọc giả");
            else
            {
                if (docGiaService.GiaHanTheDocGia(maDG, 3))
                    MessageBox.Show($"Gia hạn thành công cho đọc giả {maDG} 3 tháng");
                else
                    MessageBox.Show("Gia hạn không thành công");

            }

        }
        private void btnDanhSachSHH_Click(object sender, EventArgs e)
        {
            dgvDocGia.DataSource =  docGiaService.GetDocGiaSapHetHan();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvDocGia.DataSource = docGiaService.GetAllDocGia();

        }
        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iD = int.Parse(dgvDocGia.Rows[e.RowIndex].Cells["ID"].Value?.ToString());
            string maDG = dgvDocGia.Rows[e.RowIndex].Cells["MaDG"].Value.ToString();
            string hoTen = dgvDocGia.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
            string diaChi = dgvDocGia.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            string soDienThoai = dgvDocGia.Rows[e.RowIndex].Cells["SoDienThoai"].Value.ToString();
            string email = dgvDocGia.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            DateTime ngaySinh = Convert.ToDateTime(dgvDocGia.Rows[e.RowIndex].Cells["NgaySinh"].Value);
            DateTime ngayDangKy = Convert.ToDateTime(dgvDocGia.Rows[e.RowIndex].Cells["NgayDangKy"].Value);
            DateTime ngayHetHan = Convert.ToDateTime(dgvDocGia.Rows[e.RowIndex].Cells["NgayHetHan"].Value);
            string trangThai = dgvDocGia.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();

            if (dgvDocGia.Columns[e.ColumnIndex].Name == "Edit")
            {
                DocGia editDocGia = new DocGia(iD, hoTen, diaChi, soDienThoai, email, ngaySinh, ngayDangKy, ngayHetHan, trangThai);
                frmSuaDocGia frmSuaDocGia = new frmSuaDocGia(editDocGia);
                frmSuaDocGia.ShowDialog();

            }
            else if (dgvDocGia.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn xóa đọc giả này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (docGiaService.DeleteDocGia(iD))
                        {
                            MessageBox.Show("Xóa đọc giả thành công");
                            dgvDocGia.DataSource = docGiaService.GetAllDocGia();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        if (ex.Number == 277) // Permission denied
                        {
                            MessageBox.Show("Bạn không có quyền xóa đọc giả này!",
                                            "Lỗi quyền hạn",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy ra lỗi SQL: " + ex.Message,
                                            "Lỗi",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi hệ thống: " + ex.Message,
                                        "Lỗi",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }


            else if (dgvDocGia.Columns[e.ColumnIndex].Name == "MaDG")
            {
                txtTuKhoa.Text = maDG;
            }
        }

        private void btnKhoaChucNang_Click(object sender, EventArgs e)
        {

        }
    }
}
