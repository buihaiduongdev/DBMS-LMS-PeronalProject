using System;

namespace LMSProject.Models
{

    public class NhanVien
    {
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
