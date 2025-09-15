using System;

using System.Windows.Forms;
using LMSProject.Models;
using LMSProject.Utils;

namespace LMSProject.Forms
{
    public partial class frmMain_Admin : Form
    {
        public frmMain_Admin(User user)
        {
            InitializeComponent();
            lblvaiTro.Text = "Quản trị viên";
            lblHoten.Text = user.HoTen;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenChildForm(Form childForm)
        {
            if (pnlMain.Controls.Count > 0 && pnlMain.Controls[0].GetType() == childForm.GetType())
                return;

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
            frmLogin login = new frmLogin();
            login.Show();

            this.Close();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            DesignHelper.hoverLabel(lblClose);
            DesignHelper.hoverLabel(btnQlDocGia);
            DesignHelper.hoverLabel(btnQlNhanVien);
            DesignHelper.hoverLabel(btnDangXuat);
        }


        private void btnQlNhanVien_Click(object sender, EventArgs e)
        {
            frmQLNhanVien frmQLNhanVien = new frmQLNhanVien();
            OpenChildForm(frmQLNhanVien);
        }


        private void btnQlDocGia_Click(object sender, EventArgs e)
        {
            frmQLDocGia frmQLDocGia = new frmQLDocGia();
            OpenChildForm(frmQLDocGia);
        }
    }
}
