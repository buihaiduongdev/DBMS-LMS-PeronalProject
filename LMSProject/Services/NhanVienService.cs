using LMSProject.Models;
using LMSProject.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace LMSProject.Services
{
    public class NhanVienService
    {
        private readonly DbHelper _dbHelper;

        public NhanVienService()
        {
            _dbHelper = new DbHelper();
        }
        public DataTable GetAllNhanVien()
        {
            string sql = "SELECT * FROM NhanVien nv " +
                            "JOIN TaiKhoan tk ON nv.MaTK = tk.MaTK " +
                            "ORDER BY nv.IdNV ASC";
            try
            {
                DataTable dt = _dbHelper.ExecuteReader(sql);
                return dt;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    throw new Exception("Bạn không có quyền xóa dữ liệu này.\n" + ex);
                }
                throw;
            }
        }

        public DataTable GetNhanVienDetailsView()
        {
            try
            {
                string sql = "SELECT * FROM vw_ThongTinNhanVienChiTiet ORDER BY MaNV ASC";
                return _dbHelper.ExecuteReader(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    throw new Exception("Bạn không có quyền xóa dữ liệu này.\n" + ex);
                }
                throw;
            }

        }

        public bool InsertNhanVien(NhanVien nhanVien, User user)
        {
            string spName = "sp_InsertNhanVien";
            var parameters = new Dictionary<string, object>
            {
                { "@TenDangNhap", user.TenDangNhap },
                { "@MatKhauMaHoa", user.MatKhauMaHoa},                
                { "@HoTen", nhanVien.HoTen },
                { "@NgaySinh", (object)nhanVien.NgaySinh ?? DBNull.Value },
                { "@Email", nhanVien.Email },
                { "@SoDienThoai", nhanVien.SoDienThoai },
                { "@ChucVu", nhanVien.ChucVu }
            };
            try
            {
                int rowsAffected = _dbHelper.ExecuteNonQuery(spName, parameters, isStoredProcedure: true);
                return rowsAffected != 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tên đăng nhập hoặc Số điện thoại hoặc Email đã được đăng ký. Vui lòng nhập lại!");
                return false; 
            }
        }

        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            string spName = "sp_UpdateNhanVien";
            var parameters = new Dictionary<string, object>
            {
                { "@IdNV", nhanVien.IdNV },
                { "@HoTen", nhanVien.HoTen },
                { "@NgaySinh", (object)nhanVien.NgaySinh ?? DBNull.Value },
                { "@Email", nhanVien.Email },
                { "@SoDienThoai", nhanVien.SoDienThoai },
                { "@ChucVu", nhanVien.ChucVu },
            };

            try
            {
                int rowsAffected = _dbHelper.ExecuteNonQuery(spName, parameters, isStoredProcedure: true);
                return rowsAffected != 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Số điện thoại hoặc Email đã được đăng ký. Vui lòng nhập lại!");
                return false;
            }
        }
        public bool ResetMatKhauNhanVien(int idNV)
        {
            // mật khẩu mặc định "123456" đã mã hóa MD5
            string defaultPassword = "e10adc3949ba59abbe56e057f20f883e";

             string query = @"
                UPDATE TaiKhoan
                SET MatKhauMaHoa = @MatKhau
                WHERE MaTK = (SELECT MaTK FROM NhanVien WHERE IdNV = @IdNV)";

                    var parameters = new Dictionary<string, object>
            {
                { "@MatKhau", defaultPassword },
                { "@IdNV", idNV }
            };

            int rowsAffected = _dbHelper.ExecuteNonQuery(query, parameters, isStoredProcedure: false);
            return rowsAffected > 0;
        }

        public bool DeleteNhanVien(int idNV)
        {
            string spName = "sp_DeleteNhanVien";
            var parameters = new Dictionary<string, object>
            {
                { "@IdNV", idNV }
            };

            try
            {
                int rowsAffected = _dbHelper.ExecuteNonQuery(spName, parameters, isStoredProcedure: true);
                return rowsAffected != 0;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    throw new Exception("Bạn không có quyền xóa dữ liệu này.\n" + ex);
                }

                if (ex.Number == 547)
                {
                    throw new Exception("Không thể xóa vì dữ liệu đang được sử dụng ở bảng khác.");
                }

                throw;
            }
        }
        public DataTable TimKiemNhanVien(string tuKhoa)
        {
            return _dbHelper.ExecuteTableFunction("dbo.fn_TimKiemNhanVien", new Dictionary<string, object> { { "@TuKhoa ", tuKhoa } });
        }

        public bool KhoaChucNang(int trangThai)
        {
            string spName = "sp_Admin_SetDocGiaEditLock";
            var parameters = new Dictionary<string, object>
            {
                { "@IsLocked", trangThai },
            };

            try
            {
                int rowsAffected = _dbHelper.ExecuteNonQuery(spName, parameters, isStoredProcedure: true);
                return rowsAffected != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
