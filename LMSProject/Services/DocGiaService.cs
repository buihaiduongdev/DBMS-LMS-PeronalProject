using LMSProject.Models;
using LMSProject.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LMSProject.Services
{
    public class DocGiaService
    {
        private readonly DbHelper _dbHelper;

        public DocGiaService()
        {
            _dbHelper = new DbHelper();
        }

        public List<DocGia> GetAllDocGia()
        {
            string sql = "SELECT * FROM DocGia ORDER BY ID DESC";
            DataTable dt = _dbHelper.ExecuteReader(sql);
            return ConvertDataTableToList(dt);
        }

        public string KiemTraTrangThaiThe(string maDG)
        {
            string sql = "SELECT dbo.fn_KiemTraTrangThaiThe(@MaDG)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDG", maDG)
            };

            object result = _dbHelper.ExecuteScalar(sql, CommandType.Text, parameters);
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
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HoTen", docGia.HoTen),
                new SqlParameter("@NgaySinh", (object)docGia.NgaySinh ?? DBNull.Value),
                new SqlParameter("@DiaChi", docGia.DiaChi),
                new SqlParameter("@Email", docGia.Email),
                new SqlParameter("@SoDienThoai", docGia.SoDienThoai),
                new SqlParameter("@NgayDangKy", docGia.NgayDangKy),
                new SqlParameter("@NgayHetHan", docGia.NgayHetHan)
            };
            int rowsAffected = _dbHelper.ExecuteNonQuery(spName, CommandType.StoredProcedure, parameters);
            return rowsAffected > 0;
        }

        public bool UpdateDocGia(DocGia docGia)
        {
            string sql = "UPDATE DocGia SET " +
                         "HoTen = @HoTen, " +
                         "NgaySinh = @NgaySinh, " +
                         "DiaChi = @DiaChi, " +
                         "Email = @Email, " +
                         "SoDienThoai = @SoDienThoai, " +
                         "NgayDangKy = @NgayDangKy, " +
                         "NgayHetHan = @NgayHetHan, " +
                         "TrangThai = @TrangThai " +
                         "WHERE ID = @ID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HoTen", docGia.HoTen),
                new SqlParameter("@NgaySinh", (object)docGia.NgaySinh ?? DBNull.Value),
                new SqlParameter("@DiaChi", docGia.DiaChi),
                new SqlParameter("@Email", docGia.Email),
                new SqlParameter("@SoDienThoai", docGia.SoDienThoai),
                new SqlParameter("@NgayDangKy", docGia.NgayDangKy),
                new SqlParameter("@NgayHetHan", docGia.NgayHetHan),
                new SqlParameter("@TrangThai", docGia.TrangThai),
                new SqlParameter("@ID", docGia.ID)
            };

            int rowsAffected = _dbHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rowsAffected > 0;
        }

        public bool DeleteDocGia(int docGiaId)
        {
            string sql = "DELETE FROM DocGia WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", docGiaId)
            };

            int rowsAffected = _dbHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rowsAffected > 0;
        }

        public DataTable TimKiemDocGia(string tuKhoa)
        {
            string sql = "SELECT * FROM dbo.fn_TimKiemDocGia(@tuKhoa)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tuKhoa", tuKhoa)
            };

            DataTable dt = _dbHelper.ExecuteReader(sql, CommandType.Text, parameters);
            return dt;
        }

        public bool GiaHanTheDocGia(string maDG, int soThangGiaHan)
        {
            string spName = "sp_GiaHanTheDocGia";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDG", maDG),
                new SqlParameter("@SoThangGiaHan", soThangGiaHan)
            };

            int rowsAffected = _dbHelper.ExecuteNonQuery(spName, CommandType.StoredProcedure, parameters);
            return rowsAffected > 0;
        }

        private List<DocGia> ConvertDataTableToList(DataTable dt)
        {
            List<DocGia> docGias = new List<DocGia>();
            foreach (DataRow row in dt.Rows)
            {
                DocGia dg = new DocGia
                {
                    ID = Convert.ToInt32(row["ID"]),
                    MaDG = row["MaDG"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : (DateTime?)null,
                    DiaChi = row["DiaChi"].ToString(),
                    Email = row["Email"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    NgayDangKy = Convert.ToDateTime(row["NgayDangKy"]),
                    NgayHetHan = Convert.ToDateTime(row["NgayHetHan"]),
                    TrangThai = row["TrangThai"].ToString()
                };
                docGias.Add(dg);
            }
            return docGias;
        }
    }
}
