using System;

namespace LMSProject.Models
{
    /// <summary>
    /// Model này phản ánh chính xác cấu trúc của bảng NhanVien trong CSDL.
    /// </summary>
    public class NhanVien
    {
        public int IdNV { get; set; }
        public string MaNV { get; set; }
        public int? MaTK { get; set; } // Foreign Key, có thể là NULL
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
    }
}
