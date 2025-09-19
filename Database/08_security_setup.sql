USE QuanLyThuVien;
GO
----- Tao role -------
CREATE ROLE RoleNhanVien;
CREATE ROLE RoleQuanLy;
CREATE ROLE RoleAdmin;
GO


----------------- Tao cac tai khoan dang nhap ----------------- 
-- Login
CREATE LOGIN login_user WITH PASSWORD = 'LoginPassword123!', DEFAULT_DATABASE = QuanLyThuVien;
CREATE USER login_user FOR LOGIN login_user;

-- Nhan Vien
CREATE LOGIN userNV WITH PASSWORD = 'StrongPassword123!', DEFAULT_DATABASE = QuanLyThuVien;
CREATE USER userNV FOR LOGIN userNV;

-- Quan ly
CREATE LOGIN userQL WITH PASSWORD = 'StrongPassword123!', DEFAULT_DATABASE = QuanLyThuVien;
CREATE USER userQL FOR LOGIN userQL;

-- Admin
CREATE LOGIN userAD WITH PASSWORD = 'StrongPassword123!', DEFAULT_DATABASE = QuanLyThuVien;
CREATE USER userAD FOR LOGIN userAD;
GO

----------------- Gan nguoi dung vao vai tro ----------------- 
ALTER ROLE RoleNhanVien ADD MEMBER userNV;
ALTER ROLE RoleQuanLy  ADD MEMBER userQL;
ALTER ROLE RoleAdmin   ADD MEMBER userAD;

ALTER ROLE RoleNhanVien ADD MEMBER RoleQuanLy;
ALTER ROLE RoleQuanLy ADD MEMBER RoleAdmin;
GO

----------------- Cap quyen cho cac vai tro ----------------- 
-- Quyen cho login_user: Chi SELECT tren bang TaiKhoan va NhanVien (de lay ChucVu)
GRANT SELECT ON OBJECT::TaiKhoan TO login_user;
GRANT SELECT ON OBJECT::NhanVien TO login_user;

-- Quyen cho RoleNhanVien: Them/Sua/Sp/Fn doc gia
GRANT SELECT ON OBJECT::TaiKhoan TO RoleNhanVien;
GRANT EXECUTE ON OBJECT::sp_InsertDocGia TO RoleNhanVien;
GRANT EXECUTE ON OBJECT::sp_UpdateDocGia TO RoleNhanVien;
GRANT EXECUTE ON OBJECT::sp_GiaHanTheDocGia TO RoleNhanVien;
GRANT SELECT ON OBJECT::fn_TimKiemDocGia TO RoleNhanVien;
GRANT SELECT ON OBJECT::vw_DocGiaSapHetHan TO RoleNhanVien;
GRANT EXECUTE ON OBJECT::fn_KiemTraTrangThaiThe TO RoleNhanVien;
GRANT SELECT, INSERT, UPDATE ON OBJECT::DocGia TO RoleNhanVien;

-- Quyen cho RoleQuanLy: Co them quyen Xoa va Gia han the doc gia
-- (Da ke thua quyen Them/Sua tu RoleNhanVien)
GRANT EXECUTE ON OBJECT::sp_DeleteDocGia TO RoleQuanLy; -- Chi QuanLy moi duoc xoa
GRANT DELETE ON OBJECT::DocGia TO RoleQuanLy;
GRANT SELECT ON OBJECT::vw_ThongTinNhanVienChiTiet TO RoleQuanLy;
GRANT SELECT ON OBJECT::fn_TimKiemNhanVien TO RoleNhanVien;

-- Quyen cho RoleAdmin: Full CRUD cho NhanVien
-- (Da ke thua toan bo quyen cua QuanLy)
GRANT SELECT, INSERT, UPDATE, DELETE ON OBJECT::TaiKhoan TO userAD;
GRANT EXECUTE ON OBJECT::sp_InsertNhanVien TO RoleAdmin;
GRANT EXECUTE ON OBJECT::sp_UpdateNhanVien TO RoleAdmin;
GRANT EXECUTE ON OBJECT::sp_DeleteNhanVien TO RoleAdmin;
GRANT SELECT, INSERT, UPDATE, DELETE ON OBJECT::NhanVien TO RoleAdmin;
GRANT EXECUTE ON OBJECT::sp_Admin_SetDocGiaEditLock TO RoleAdmin;

GRANT ALTER ANY ROLE TO userAD;
GRANT CONTROL ON DATABASE::QuanLyThuVien TO userAD;
GO
