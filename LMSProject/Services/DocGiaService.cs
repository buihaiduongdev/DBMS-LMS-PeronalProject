using LMSProject.Models;
using LMSProject.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LMSProject.Services
{
    public class DocGiaService
    {
        private readonly DbHelper _dbHelper;

        public DocGiaService()
        {
            _dbHelper = new DbHelper();
        }

        public DataTable GetAllDocGia()
        {
            string sql = "SELECT * FROM DocGia ORDER BY ID ASC";
            DataTable dt = _dbHelper.ExecuteReader(sql);
            return dt;
        }
        public string KiemTraTrangThaiThe(string maDG)
        {
            string sql = "SELECT dbo.fn_KiemTraTrangThaiThe(@MaDG)";
            var parameters = new Dictionary<string, object>
            {
                { "@MaDG", maDG }
            };

            object result = _dbHelper.ExecuteScalar(sql, parameters);
            return result?.ToString();
        }

        public DataTable GetDocGiaSapHetHan()
        {
            string sql = "SELECT * FROM vw_DocGiaSapHetHan ORDER BY SoNgayConLai ASC";
            return _dbHelper.ExecuteReader(sql);
        }

        public bool InsertDocGia(DocGia docGia)
        {
            string spName = "sp_InsertDocGia";
            var parameters = new Dictionary<string, object>
            {
                { "@HoTen", docGia.HoTen },
                { "@NgaySinh", (object)docGia.NgaySinh ?? DBNull.Value },
                { "@DiaChi", docGia.DiaChi },
                { "@Email", docGia.Email },
                { "@SoDienThoai", docGia.SoDienThoai },
                { "@NgayDangKy", docGia.NgayDangKy },
                { "@NgayHetHan", docGia.NgayHetHan }
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

        public bool UpdateDocGia(DocGia docGia)
        {
            string spName = "sp_UpdateDocGia";
            var parameters = new Dictionary<string, object>
            {
                { "@ID", docGia.ID },
                { "@HoTen", docGia.HoTen },
                { "@NgaySinh", (object)docGia.NgaySinh ?? DBNull.Value },
                { "@DiaChi", docGia.DiaChi },
                { "@Email", docGia.Email },
                { "@SoDienThoai", docGia.SoDienThoai },
                { "@NgayDangKy", docGia.NgayDangKy },
                { "@NgayHetHan", docGia.NgayHetHan },
                { "@TrangThai", docGia.TrangThai }
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

        public bool DeleteDocGia(int docGiaId)
        {
            string spName = "sp_DeleteDocGia";
            var parameters = new Dictionary<string, object>
            {
                { "@ID", docGiaId }
            };

            try
            {
                int rowsAffected = _dbHelper.ExecuteNonQuery(spName, parameters, isStoredProcedure: true);
                return rowsAffected > 0;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Bạn không đủ quyền hạn truy cập: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

        }

        public DataTable TimKiemDocGia(string tuKhoa)
        {
            return _dbHelper.ExecuteTableFunction("dbo.fn_TimKiemDocGia", new Dictionary<string, object> { { "@TuKhoa ", tuKhoa } });
        }

        public bool GiaHanTheDocGia(string maDG, int soThangGiaHan)
        {
            string spName = "sp_GiaHanTheDocGia";
            var parameters = new Dictionary<string, object>
            {
                { "@MaDG", maDG },
                { "@SoThangGiaHan", soThangGiaHan }
            };

            int rowsAffected = _dbHelper.ExecuteNonQuery(spName, parameters, isStoredProcedure: true);
            return rowsAffected > 0;
        }
    }
}
