using System;

namespace LMSProject.Models
{

    public class NhanVien
    {
        public NhanVien(string hoTen, DateTime? ngaySinh, string email, string soDienThoai, string chucVu)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            Email = email;
            SoDienThoai = soDienThoai;
            ChucVu = chucVu;
        }

        public NhanVien(int idNV, string hoTen, DateTime? ngaySinh, string email, string soDienThoai, string chucVu)
        {
            IdNV = idNV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            Email = email;
            SoDienThoai = soDienThoai;
            ChucVu = chucVu;
        }

        public int IdNV { get; set; }
        public string MaNV { get; set; }
        public int? MaTK { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
    }
}
