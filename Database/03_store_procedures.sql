USE QuanLyThuVien;
GO
-------------------------- Bui Hai Duong - Quan Ly Doc Gia --------------------------

USE QuanLyThuVien;
GO

CREATE OR ALTER PROCEDURE sp_InsertDocGia
    @HoTen NVARCHAR(50),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(255),
    @Email VARCHAR(50),
    @SoDienThoai VARCHAR(20),
    @NgayDangKy DATE,
    @NgayHetHan DATE
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO DocGia(HoTen, NgaySinh, DiaChi, Email, SoDienThoai, NgayDangKy, NgayHetHan, TrangThai)
        VALUES(@HoTen, @NgaySinh, @DiaChi, @Email, @SoDienThoai, @NgayDangKy, @NgayHetHan, 'ConHan');
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateDocGia
    @ID INT,
    @HoTen NVARCHAR(50),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(255),
    @Email VARCHAR(50),
    @SoDienThoai VARCHAR(20),
    @NgayDangKy DATE,
    @NgayHetHan DATE,
    @TrangThai NVARCHAR(20)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE DocGia
        SET HoTen = @HoTen,
            NgaySinh = @NgaySinh,
            DiaChi = @DiaChi,
            Email = @Email,
            SoDienThoai = @SoDienThoai,
            NgayDangKy = @NgayDangKy,
            NgayHetHan = @NgayHetHan,
            TrangThai = @TrangThai
        WHERE ID = @ID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteDocGia
    @ID INT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        
        DELETE FROM DocGia WHERE ID = @ID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertNhanVien
    @TenDangNhap VARCHAR(50),
    @MatKhauMaHoa VARCHAR(255),
    @HoTen NVARCHAR(50),
    @NgaySinh DATE,
    @Email VARCHAR(50),
    @SoDienThoai VARCHAR(20),
    @ChucVu NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @MaTK INT;

        -- 1. Tạo tài khoản
        INSERT INTO TaiKhoan (TenDangNhap, MatKhauMaHoa, VaiTro, TrangThai)
        VALUES (@TenDangNhap, @MatKhauMaHoa, 1, 1);

        SET @MaTK = SCOPE_IDENTITY();

        -- 2. Tạo nhân viên gắn với tài khoản
        INSERT INTO NhanVien(MaTK, HoTen, NgaySinh, Email, SoDienThoai, ChucVu)
        VALUES(@MaTK, @HoTen, @NgaySinh, @Email, @SoDienThoai, @ChucVu);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
	THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateNhanVien
    @IdNV INT,
    @HoTen NVARCHAR(50),
    @NgaySinh DATE,
    @Email VARCHAR(50),
    @SoDienThoai VARCHAR(20),
    @ChucVu NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE NhanVien
        SET HoTen = @HoTen,
            NgaySinh = @NgaySinh,
            Email = @Email,
            SoDienThoai = @SoDienThoai,
            ChucVu = @ChucVu
        WHERE IdNV = @IdNV;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteNhanVien
    @IdNV INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @MaTK INT;

        -- Lấy MaTK gắn với nhân viên
        SELECT @MaTK = MaTK FROM NhanVien WHERE IdNV = @IdNV;

        -- Xóa nhân viên
        DELETE FROM NhanVien WHERE IdNV = @IdNV;

        -- Xóa tài khoản
        IF @MaTK IS NOT NULL
            DELETE FROM TaiKhoan WHERE MaTK = @MaTK;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
	THROW;
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE sp_GiaHanTheDocGia (
    @MaDG VARCHAR(50),
    @SoThangGiaHan INT
)
AS
BEGIN
    DECLARE @NgayHetHanHienTai DATE;
    SELECT @NgayHetHanHienTai = NgayHetHan FROM DocGia WHERE MaDG = @MaDG;

    -- Nếu thẻ đã hết hạn, gia hạn từ ngày hiện tại.
    -- Nếu thẻ còn hạn, gia hạn từ ngày hết hạn cũ.
    DECLARE @NgayHetHanMoi DATE;
    IF (@NgayHetHanHienTai < GETDATE())
        SET @NgayHetHanMoi = DATEADD(MONTH, @SoThangGiaHan, GETDATE());
    ELSE
        SET @NgayHetHanMoi = DATEADD(MONTH, @SoThangGiaHan, @NgayHetHanHienTai);

    UPDATE DocGia
    SET
        NgayHetHan = @NgayHetHanMoi,
        TrangThai = 'ConHan'
    WHERE
        MaDG = @MaDG;

    PRINT N'Gia hạn thẻ thành công cho độc giả ' + @MaDG;
END;
GO
CREATE OR ALTER PROCEDURE sp_Admin_SetDocGiaEditLock
    @IsLocked BIT

AS
BEGIN
    IF @IsLocked = 1
    BEGIN        
        DENY INSERT, UPDATE ON OBJECT::DocGia TO RoleNhanVien;
    END
    ELSE
    BEGIN        
        REVOKE INSERT, UPDATE ON OBJECT::DocGia FROM RoleNhanVien;
        GRANT INSERT, UPDATE ON OBJECT::DocGia TO RoleNhanVien;
    END
END
GO