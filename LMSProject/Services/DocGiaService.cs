using LMSProject.Models;
using LMSProject.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace LMSProject.Services
{
    public class DocGiaService
    {
        private readonly DbHelper _dbHelper;

        public DocGiaService()
        {
            _dbHelper = new DbHelper();
        }

        public List<DocGia> GetAllDocGiaList()
        {
            string sql = "SELECT * FROM DocGia ORDER BY ID DESC";
            DataTable dt = _dbHelper.ExecuteReader(sql);
            return ConvertDataTableToList(dt);
        }
        public DataTable GetAllDocGia()
        {
            string sql = "SELECT * FROM DocGia ORDER BY ID DESC";
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
            int rowsAffected = _dbHelper.ExecuteNonQuery(spName, parameters, isStoredProcedure: true);
            return rowsAffected > 0;
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

            int rowsAffected = _dbHelper.ExecuteNonQuery(spName, parameters, isStoredProcedure: true);
            return rowsAffected > 0;
        }

        public bool DeleteDocGia(int docGiaId)
        {
            string spName = "sp_DeleteDocGia";
            var parameters = new Dictionary<string, object>
            {
                { "@ID", docGiaId }
            };

            int rowsAffected = _dbHelper.ExecuteNonQuery(spName, parameters, isStoredProcedure: true);
            return rowsAffected > 0;
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
