using System;

namespace LMSProject.Models
{
    public class DocGia
    {
        public int ID { get; set; }
        public string MaDG { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string TrangThai { get; set; }
    }
}
