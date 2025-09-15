namespace LMSProject.Models
{
    public class User
    {
        public int MaTK { get; set; }
        public string TenDangNhap { get; set; }
        public int VaiTro { get; set; } // 0: Admin, 1: NhanVien
        public int TrangThai { get; set; } // 0: Khoa vinh vien, 1: Hoat dong, 2: Tam khoa
        public string ChucVu { get; set; }
    }
}
