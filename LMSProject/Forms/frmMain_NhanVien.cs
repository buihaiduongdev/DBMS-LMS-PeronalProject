using System;

using System.Windows.Forms;
using LMSProject.Utils;
using System.Windows.Forms;
using LMSProject.Models;
using LMSProject.Services;

namespace LMSProject.Forms
{
    public partial class frmMain_NhanVien : Form
    {
        public frmMain_NhanVien(User user)
        {
            InitializeComponent();
            lblChucVu.Text = user.ChucVu;
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OpenChildForm(Form childForm)
        {
            // Nếu panel có form và form đó cùng kiểu với childForm thì không load lại
            if (pnlMain.Controls.Count > 0 && pnlMain.Controls[0].GetType() == childForm.GetType())
                return;

            // Xoá form cũ
            if (pnlMain.Controls.Count > 0)
            {
                pnlMain.Controls[0].Dispose();
                pnlMain.Controls.Clear();
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            UserService.CurrentUser = null;
            frmLogin login = new frmLogin();
            login.Show();

            this.Close();
        }

        private void btnQlDocGia_Click(object sender, EventArgs e)
        {
            frmQLDocGia frmQLDocGia = new frmQLDocGia();
            OpenChildForm(frmQLDocGia);
        }


        private void btnQLNV_Click(object sender, EventArgs e)
        {
            frmQLNhanVien frmQLNhanVien = new frmQLNhanVien();
            OpenChildForm(frmQLNhanVien);
        }

        private void frmMain_NhanVien_Load(object sender, EventArgs e)
        {
            DesignHelper.hoverLabel(lblClose);
            DesignHelper.hoverLabel(btnQlDocGia);
            DesignHelper.hoverLabel(btnQLNV);
            DesignHelper.hoverLabel(btnDangXuat);

        }
    }
}
