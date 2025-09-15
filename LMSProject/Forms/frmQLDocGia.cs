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
            docGiaList = docGiaService.GetAllDocGiaList();
            dgvDocGia.DataSource = docGiaService.GetAllDocGia();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text;
            dgvDocGia.DataSource = docGiaService.TimKiemDocGia(tuKhoa);
        }
    }
}
