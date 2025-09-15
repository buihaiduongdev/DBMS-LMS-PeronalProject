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
        private List<DocGia> docGiaList;
        DocGiaService docGiaService = new DocGiaService();

        private void frmQLDocGia_Load(object sender, EventArgs e)
        {
            if (UserService.CurrentUser.VaiTro == 0)
                btnKhoaChucNang.Visible = true;
            docGiaList = docGiaService.GetAllDocGiaList();
            dgvDocGia.DataSource = docGiaService.GetAllDocGia();
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text;
            dgvDocGia.DataSource = docGiaService.TimKiemDocGia(tuKhoa);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //mo form con add
        }


        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string maDG = txtTuKhoa.Text;
            MessageBox.Show(docGiaService.KiemTraTrangThaiThe(maDG));
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            string maDG = txtTuKhoa.Text;
            if (docGiaService.GiaHanTheDocGia(maDG, 3)) {
                MessageBox.Show($"Gia hạn thành công cho đọc giả {maDG} 3 tháng");
            }
        }
        private void btnDanhSachSHH_Click(object sender, EventArgs e)
        {
            dgvDocGia.DataSource =  docGiaService.GetDocGiaSapHetHan();
        }

        private void btnKhoaChucNang_Click(object sender, EventArgs e)
        {

        }
        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maDG = dgvDocGia.Rows[e.RowIndex].Cells["MaDG"].Value.ToString();
            if (dgvDocGia.Columns[e.ColumnIndex].Name == "Edit")
            {
                //mo form con edit
            }
            else if (dgvDocGia.Columns[e.ColumnIndex].Name == "Delete")
            {
                //msg xoa
            }
            else if (dgvDocGia.Columns[e.ColumnIndex].Name == "MaDG")
            {
                txtTuKhoa.Text = maDG;
            }
        }


    }
}
