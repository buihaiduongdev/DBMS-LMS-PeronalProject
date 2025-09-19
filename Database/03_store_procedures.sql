USE QuanLyThuVien;
GO
-------------------------- Bui Hai Duong - Quan Ly Doc Gia --------------------------

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
    -- 1. Kiem tra du lieu dau vao
    IF EXISTS (SELECT 1 FROM DocGia WHERE Email = @Email)
    BEGIN
        RAISERROR(N'Email đã được sử dụng bởi một độc giả khác.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM DocGia WHERE SoDienThoai = @SoDienThoai)
    BEGIN
        RAISERROR(N'Số điện thoại đã được sử dụng bởi một độc giả khác.', 16, 1);
        RETURN;
    END

    IF @NgaySinh > GETDATE()
    BEGIN
        RAISERROR(N'Ngày sinh không hợp lệ.', 16, 1);
        RETURN;
    END

    -- 2. Thuc hien them moi
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
    -- 1. Kiem tra du lieu dau vao
    IF NOT EXISTS (SELECT 1 FROM DocGia WHERE ID = @ID)
    BEGIN
        RAISERROR(N'Không tìm thấy độc giả với ID cung cấp.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM DocGia WHERE Email = @Email AND ID != @ID)
    BEGIN
        RAISERROR(N'Email đã được sử dụng bởi một độc giả khác.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM DocGia WHERE SoDienThoai = @SoDienThoai AND ID != @ID)
    BEGIN
        RAISERROR(N'Số điện thoại đã được sử dụng bởi một độc giả khác.', 16, 1);
        RETURN;
    END

    IF @NgaySinh > GETDATE()
    BEGIN
        RAISERROR(N'Ngày sinh không hợp lệ.', 16, 1);
        RETURN;
END

    -- 2. Thuc hien cap nhat
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
    -- 1. Kiem tra dieu kien xoa
    IF NOT EXISTS (SELECT 1 FROM DocGia WHERE ID = @ID)
    BEGIN
        RAISERROR(N'Không tìm thấy độc giả với ID cung cấp.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM TheMuon WHERE MaDG = @ID AND TrangThai = 'DangMuon')
    BEGIN
        RAISERROR(N'Không thể xóa độc giả này vì họ đang có sách chưa trả.', 16, 1);
        RETURN;
    END
    
    -- 2. Thuc hien xoa
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
    -- 1. Kiem tra du lieu dau vao
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        RAISERROR(N'Tên đăng nhập đã tồn tại.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM NhanVien WHERE Email = @Email)
    BEGIN
        RAISERROR(N'Email đã được sử dụng bởi một nhân viên khác.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM NhanVien WHERE SoDienThoai = @SoDienThoai)
    BEGIN
        RAISERROR(N'Số điện thoại đã được sử dụng bởi một nhân viên khác.', 16, 1);
        RETURN;
    END

    IF @NgaySinh > GETDATE()
    BEGIN
        RAISERROR(N'Ngày sinh không hợp lệ.', 16, 1);
        RETURN;
    END

    -- 2. Thuc hien them moi
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @MaTK INT;

        INSERT INTO TaiKhoan (TenDangNhap, MatKhauMaHoa, VaiTro, TrangThai)
        VALUES (@TenDangNhap, @MatKhauMaHoa, 1, 1); -- VaiTro 1 = NhanVien, TrangThai 1 = HoatDong

        SET @MaTK = SCOPE_IDENTITY();

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
    -- 1. Kiem tra du lieu dau vao
    IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE IdNV = @IdNV)
    BEGIN
        RAISERROR(N'Không tìm thấy nhân viên với ID cung cấp.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM NhanVien WHERE Email = @Email AND IdNV != @IdNV)
    BEGIN
        RAISERROR(N'Email đã được sử dụng bởi một nhân viên khác.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM NhanVien WHERE SoDienThoai = @SoDienThoai AND IdNV != @IdNV)
    BEGIN
        RAISERROR(N'Số điện thoại đã được sử dụng bởi một nhân viên khác.', 16, 1);
        RETURN;
    END

    IF @NgaySinh > GETDATE()
    BEGIN
        RAISERROR(N'Ngày sinh không hợp lệ.', 16, 1);
        RETURN;
    END

    -- 2. Thuc hien cap nhat
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
    -- 1. Kiem tra dieu kien
    IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE IdNV = @IdNV)
    BEGIN
        RAISERROR(N'Không tìm thấy nhân viên với ID cung cấp.', 16, 1);
        RETURN;
    END;

    -- 2. Thuc hien xoa vinh vien (hard delete)
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @MaTK INT;
        SELECT @MaTK = MaTK FROM NhanVien WHERE IdNV = @IdNV;

        DELETE FROM NhanVien WHERE IdNV = @IdNV;

        IF @MaTK IS NOT NULL
            DELETE FROM TaiKhoan WHERE MaTK = @MaTK;
        ELSE
             RAISERROR(N'Nhân viên này không có tài khoản liên kết để xóa.', 16, 1);

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