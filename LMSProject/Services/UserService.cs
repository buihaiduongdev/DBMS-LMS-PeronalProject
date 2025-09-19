using LMSProject.Models;
using LMSProject.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LMSProject.Services
{
    public class UserService
    {
        public static User CurrentUser { get; set; }
        private DbHelper _dbHelper;

        public UserService()
        {
            _dbHelper = new DbHelper();
            
        }

        public User Login(string username, string password)
        {
            
            // Bước 1: Xác thực tài khoản
            string hashedPassword = SecurityHelper.HashMD5(password);
            string authSql = "SELECT MaTK, TenDangNhap, VaiTro, TrangThai FROM TaiKhoan WHERE TenDangNhap = @Username AND MatKhauMaHoa = @Password";
            var authParams = new Dictionary<string, object>
            {
                { "@Username", username },
                { "@Password", hashedPassword }
            };
            DbHelper.BuildAndSetConnectionString(username, password);
            DataTable authDt = _dbHelper.ExecuteReader(authSql, authParams);
           
            if (authDt.Rows.Count > 0)
            {
                DataRow authRow = authDt.Rows[0];
                var user = new User
                {
                    MaTK = Convert.ToInt32(authRow["MaTK"]),
                    TenDangNhap = authRow["TenDangNhap"].ToString(),
                    VaiTro = Convert.ToInt32(authRow["VaiTro"]),
                    TrangThai = Convert.ToInt32(authRow["TrangThai"])
                };

                if (user.VaiTro == 1)
                {
                    string staffSql = "SELECT ChucVu FROM NhanVien WHERE MaTK = @MaTK";
                    var staffParams = new Dictionary<string, object>
                    {
                        { "@MaTK", user.MaTK }
                    };

                    DataTable staffDt = _dbHelper.ExecuteReader(staffSql, staffParams);
                    if (staffDt.Rows.Count > 0)
                    {
                        user.ChucVu = staffDt.Rows[0]["ChucVu"].ToString();
                    }
                    else
                    {
                        user.ChucVu = "Nhan Vien"; 
                    }
                }
                else
                {
                    user.ChucVu = "Admin";
                }

                return user;
            }

            return null;
        }
    }
}
