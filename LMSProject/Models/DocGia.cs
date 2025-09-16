using System;

namespace LMSProject.Models
{
    public class DocGia
    {
        public DocGia(string hoTen, string diaChi, string email, string soDienThoai, DateTime? ngaySinh, DateTime ngayDangKy, DateTime ngayHetHan)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            Email = email;
            SoDienThoai = soDienThoai;
            NgayDangKy = ngayDangKy;
            NgayHetHan = ngayHetHan;
        }

        public DocGia(int iD, string hoTen, string diaChi, string email, string soDienThoai, DateTime? ngaySinh, DateTime ngayDangKy, DateTime ngayHetHan, string trangThai)
        {
            ID = iD;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            Email = email;
            SoDienThoai = soDienThoai;
            NgayDangKy = ngayDangKy;
            NgayHetHan = ngayHetHan;
            TrangThai = trangThai;
        }

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
