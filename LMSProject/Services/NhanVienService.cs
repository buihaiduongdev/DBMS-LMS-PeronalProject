using LMSProject.Models;
using LMSProject.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LMSProject.Services
{
    public class NhanVienService
    {
        private readonly DbHelper _dbHelper;

        public NhanVienService()
        {
            _dbHelper = new DbHelper();
        }
        
        public List<NhanVien> GetAllNhanVien()
        {
            string sql = "SELECT * FROM NhanVien ORDER BY IdNV DESC";
            DataTable dt = _dbHelper.ExecuteReader(sql);
            return ConvertDataTableToList(dt);
        }

        public DataTable GetNhanVienDetailsView()
        {
            string sql = "SELECT * FROM vw_ThongTinNhanVienChiTiet ORDER BY MaNV DESC";
            return _dbHelper.ExecuteReader(sql);
        }

        public bool InsertNhanVien(NhanVien nhanVien)
        {
            string spName = "sp_InsertNhanVien";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaTK", (object)nhanVien.MaTK ?? DBNull.Value),
                new SqlParameter("@HoTen", nhanVien.HoTen),
                new SqlParameter("@NgaySinh", (object)nhanVien.NgaySinh ?? DBNull.Value),
                new SqlParameter("@Email", nhanVien.Email),
                new SqlParameter("@SoDienThoai", nhanVien.SoDienThoai),
                new SqlParameter("@ChucVu", nhanVien.ChucVu)
            };

            int rowsAffected = _dbHelper.ExecuteNonQuery(spName, CommandType.StoredProcedure, parameters);
            return rowsAffected > 0;
        }

        private List<NhanVien> ConvertDataTableToList(DataTable dt)
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            foreach (DataRow row in dt.Rows)
            {
                NhanVien nv = new NhanVien
                {
                    IdNV = Convert.ToInt32(row["IdNV"]),
                    MaNV = row["MaNV"].ToString(),
                    MaTK = row["MaTK"] != DBNull.Value ? Convert.ToInt32(row["MaTK"]) : (int?)null,
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : (DateTime?)null,
                    Email = row["Email"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    ChucVu = row["ChucVu"].ToString()
                };
                nhanViens.Add(nv);
            }
            return nhanViens;
        }
    }
}
