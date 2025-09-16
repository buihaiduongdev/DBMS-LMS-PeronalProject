
USE QuanLyThuVien;
GO

----------------- Tao cac vai tro ----------------- 
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'RoleNhanVien' AND type = 'R') CREATE ROLE RoleNhanVien;
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'RoleQuanLy' AND type = 'R') CREATE ROLE RoleQuanLy;
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'RoleAdmin' AND type = 'R') CREATE ROLE RoleAdmin;
GO

----------------- Tao cac tai khoan dang nhap ----------------- 

-- Tao Login cho man hinh dang nhap
IF NOT EXISTS (SELECT name FROM sys.sql_logins WHERE name = 'login_user')
BEGIN
    CREATE LOGIN login_user WITH PASSWORD = 'LoginPassword123!';
END
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'login_user' AND type = 'S')
BEGIN
    CREATE USER login_user FOR LOGIN login_user;
END
GO

----------------- Tao Login va User cho cac vai tro nghiep vu ----------------- 
IF NOT EXISTS (SELECT name FROM sys.sql_logins WHERE name = 'userNV') CREATE LOGIN userNV WITH PASSWORD = 'StrongPassword123!';
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'userNV' AND type = 'S') CREATE USER userNV FOR LOGIN userNV;

IF NOT EXISTS (SELECT name FROM sys.sql_logins WHERE name = 'userQL') CREATE LOGIN userQL WITH PASSWORD = 'StrongPassword123!';
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'userQL' AND type = 'S') CREATE USER userQL FOR LOGIN userQL;

IF NOT EXISTS (SELECT name FROM sys.sql_logins WHERE name = 'userAD') CREATE LOGIN userAD WITH PASSWORD = 'StrongPassword123!';
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'userAD' AND type = 'S') CREATE USER userAD FOR LOGIN userAD;
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
GRANT SELECT ON OBJECT::TaiKhoan TO login_user;
GRANT SELECT ON OBJECT::NhanVien TO login_user;
GRANT EXECUTE ON OBJECT::sp_InsertDocGia TO RoleNhanVien;
GRANT EXECUTE ON OBJECT::sp_UpdateDocGia TO RoleNhanVien;
GRANT EXECUTE ON OBJECT::sp_GiaHanTheDocGia TO RoleNhanVien;
GRANT SELECT ON OBJECT::fn_TimKiemDocGia TO RoleNhanVien;
GRANT SELECT ON OBJECT::vw_DocGiaSapHetHan TO RoleNhanVien;

GRANT EXECUTE ON OBJECT::fn_KiemTraTrangThaiThe TO RoleNhanVien;
GRANT SELECT, INSERT, UPDATE ON OBJECT::DocGia TO RoleNhanVien;

-- Quyen cho RoleQuanLy: Co them quyen Xoa va Gia han the doc gia
-- (Da ke thua quyen Them/Sua tu RoleNhanVien)
GRANT SELECT ON OBJECT::TaiKhoan TO login_user;
GRANT SELECT ON OBJECT::NhanVien TO login_user;
GRANT EXECUTE ON OBJECT::sp_DeleteDocGia TO RoleQuanLy; -- Chi QuanLy moi duoc xoa
GRANT SELECT ON OBJECT::vw_ThongTinNhanVienChiTiet TO RoleQuanLy;
GRANT DELETE ON OBJECT::DocGia TO RoleQuanLy;

-- Quyen cho RoleAdmin: Full CRUD cho NhanVien
-- (Da ke thua toan bo quyen cua QuanLy)
GRANT SELECT ON OBJECT::TaiKhoan TO login_user;
GRANT SELECT ON OBJECT::NhanVien TO login_user;
GRANT EXECUTE ON OBJECT::sp_InsertNhanVien TO RoleAdmin;
GRANT EXECUTE ON OBJECT::sp_UpdateNhanVien TO RoleAdmin;
GRANT EXECUTE ON OBJECT::sp_DeleteNhanVien TO RoleAdmin;
GRANT SELECT, INSERT, UPDATE, DELETE ON OBJECT::NhanVien TO RoleAdmin;
GRANT SELECT, INSERT, UPDATE, DELETE ON OBJECT::TaiKhoan TO RoleAdmin;
GRANT EXECUTE ON OBJECT::sp_Admin_SetDocGiaEditLock TO RoleAdmin;

GO

SELECT 
    r.name AS role_name, 
    m.name AS member_name
FROM sys.database_role_members drm
JOIN sys.database_principals r ON drm.role_principal_id = r.principal_id
JOIN sys.database_principals m ON drm.member_principal_id = m.principal_id
ORDER BY r.name, m.name;
GO