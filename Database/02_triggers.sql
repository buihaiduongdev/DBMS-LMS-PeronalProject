
USE QuanLyThuVien;
GO
-------------------------- Bui Hai Duong - Quan Ly Doc Gia --------------------------
CREATE OR ALTER TRIGGER trg_InsertNV
ON NhanVien
AFTER INSERT
AS
BEGIN
	UPDATE NhanVien
	SET MaNV = 'NV' + RIGHT('0000' + CAST(i.IdNV AS varchar(4)), 4)
	FROM NhanVien NV
	INNER JOIN inserted i ON NV.IdNV = i.IdNV
END;
GO

CREATE OR ALTER TRIGGER trg_InsertDG
ON DocGia
AFTER INSERT
AS
BEGIN
	UPDATE DocGia
	SET MaDG = 'DG' + RIGHT('0000' + CAST(i.Id AS VARCHAR(4)),4)
	FROM DocGia DG
	INNER JOIN inserted i ON DG.Id = i.Id
END;
GO

CREATE OR ALTER TRIGGER trg_UpdateTrangThaiDG_TraTre
ON TraSach
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE DG
    SET TrangThai = 'TamKhoa'
    FROM DocGia DG
    INNER JOIN TheMuon TM ON DG.ID = TM.MaDG
    INNER JOIN inserted i ON TM.MaTheMuon = i.MaTheMuon
    WHERE i.NgayTra > TM.NgayHenTra;
END;
GO

CREATE OR ALTER TRIGGER trg_CreateLoginUser
ON TaiKhoan
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @username NVARCHAR(50), @password NVARCHAR(255), @role TINYINT;
    SELECT @username = i.TenDangNhap, @password = i.MatKhauMaHoa, @role = i.VaiTro
    FROM inserted i;

    DECLARE @sqlString NVARCHAR(MAX);

    SET @sqlString = 'CREATE LOGIN [' + @username + '] WITH PASSWORD = N''' + @password + ''', DEFAULT_DATABASE = [QuanLyThuVien], CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF';
    EXEC sp_executesql @sqlString;

    SET @sqlString = 'CREATE USER [' + @username + '] FOR LOGIN [' + @username + ']';
    EXEC sp_executesql @sqlString;

    IF (@role = 1) -- 1: Nhan vien
    BEGIN
        SET @sqlString = 'ALTER ROLE RoleNhanVien ADD MEMBER [' + @username + ']';
    END
    ELSE IF (@role = 0) -- 0: Admin
    BEGIN
        SET @sqlString = 'ALTER ROLE RoleAdmin ADD MEMBER [' + @username + ']';
    END
    EXEC sp_executesql @sqlString;
END;
GO

CREATE OR ALTER TRIGGER trg_DeleteLoginUser
ON TaiKhoan
FOR DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @username NVARCHAR(50);
    SELECT @username = d.TenDangNhap FROM deleted d;

    IF @username IS NULL RETURN;

    DECLARE @sessionID INT;
    DECLARE @sqlString NVARCHAR(MAX);

    SELECT @sessionID = session_id
    FROM sys.dm_exec_sessions
    WHERE login_name = @username;

    IF @sessionID IS NOT NULL
    BEGIN
        SET @sqlString = 'KILL ' + CONVERT(NVARCHAR(20), @sessionID);
        EXEC sp_executesql @sqlString;
    END

    BEGIN TRY
        SET @sqlString = 'DROP USER IF EXISTS [' + @username + ']';
        EXEC sp_executesql @sqlString;

        SET @sqlString = 'DROP LOGIN IF EXISTS [' + @username + ']';
        EXEC sp_executesql @sqlString;
    END TRY
    BEGIN CATCH
        DECLARE @err NVARCHAR(MAX);
        SELECT @err = N'Lỗi khi xóa tài khoản SQL: ' + ERROR_MESSAGE();
        RAISERROR(@err, 16, 1);
    END CATCH
END;
GO

-------------------------- Phan Ngoc Duy - Quan Ly Nhap Sach --------------------------

CREATE OR ALTER TRIGGER trg_InsertTacGia
ON TAC_GIA
AFTER INSERT
AS
BEGIN
    UPDATE TAC_GIA
    SET MaTacGia = 'TG' + RIGHT('000' + CAST(i.IdTG AS VARCHAR(3)), 3)
    FROM TAC_GIA TG
    INNER JOIN inserted i ON TG.IdTG = i.IdTG;
END;
GO

CREATE OR ALTER TRIGGER trg_InsertTheLoai
ON THE_LOAI
AFTER INSERT
AS
BEGIN
    UPDATE THE_LOAI
    SET MaTheLoai = 'TL' + RIGHT('000' + CAST(i.IdTL AS VARCHAR(3)), 3)
    FROM THE_LOAI TL
    INNER JOIN inserted i ON TL.IdTL = i.IdTL;
END;
GO

CREATE OR ALTER TRIGGER trg_InsertNXB
ON NHA_XUAT_BAN
AFTER INSERT
AS
BEGIN
    UPDATE NHA_XUAT_BAN
    SET MaNXB = 'NXB' + RIGHT('000' + CAST(i.IdNXB AS VARCHAR(3)), 3)
    FROM NHA_XUAT_BAN NXB
    INNER JOIN inserted i ON NXB.IdNXB = i.IdNXB;
END;
GO

CREATE OR ALTER TRIGGER trg_InsertSach
ON SACH
AFTER INSERT
AS
BEGIN
    UPDATE SACH
    SET MaSach = 'S' + RIGHT('000' + CAST(i.IdS AS VARCHAR(3)), 3)
    FROM SACH S
    INNER JOIN inserted i ON S.IdS = i.IdS;
END;
GO

CREATE OR ALTER TRIGGER trg_InsertTheNhap
ON The_Nhap
AFTER INSERT
AS
BEGIN
    UPDATE The_Nhap
    SET MaTheNhap = 'TN' + RIGHT('000' + CAST(i.IdTN AS VARCHAR(3)), 3)
    FROM The_Nhap TN
    INNER JOIN inserted i ON TN.IdTN = i.IdTN;
END;
GO
