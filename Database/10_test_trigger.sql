USE QuanLyThuVien;
GO

PRINT N'--- Bắt đầu kịch bản kiểm tra trigger trg_UpdateTrangThaiDG_TraTre ---';
BEGIN TRANSACTION;

-- ID Độc giả và Thẻ mượn sẽ được sử dụng cho kịch bản này
DECLARE @TestDocGiaID INT = 1;
DECLARE @TestTheMuonID INT = 1;

-- 1. Thiết lập kịch bản: Chỉnh sửa ngày hẹn trả của một phiếu mượn về quá khứ
PRINT N'1. Thiết lập: Cập nhật NgayHenTra của TheMuon ID ' + CAST(@TestTheMuonID AS VARCHAR) + N' thành 7 ngày trước.';
UPDATE TheMuon
SET NgayHenTra = DATEADD(day, -7, GETDATE())
WHERE MaTheMuon = @TestTheMuonID;

PRINT N'Trạng thái ban đầu của Độc giả ID ' + CAST(@TestDocGiaID AS VARCHAR) + ':';
SELECT ID, MaDG, TrangThai FROM DocGia WHERE ID = @TestDocGiaID;

-- 2. Hành động: Thêm một bản ghi vào TraSach để kích hoạt trigger
--    NgayTra (GETDATE()) sẽ muộn hơn NgayHenTra đã được cập nhật.
PRINT N'2. Hành động: INSERT vào TraSach cho TheMuon ID ' + CAST(@TestTheMuonID AS VARCHAR) + N' với ngày trả là hôm nay.';
INSERT INTO TraSach (MaTheMuon, IdNV, NgayTra, GhiChu, DaThongBao)
VALUES (@TestTheMuonID, 1, GETDATE(), N'Kiểm tra trigger trả sách trễ', 0);

PRINT N'Trigger đã được kích hoạt.';

-- 3. Kiểm tra kết quả: Trạng thái của độc giả phải được cập nhật thành 'TamKhoa'
PRINT N'3. Kết quả: Kiểm tra trạng thái của Độc giả ID ' + CAST(@TestDocGiaID AS VARCHAR) + N' sau khi trả trễ.';
SELECT ID, MaDG, TrangThai FROM DocGia WHERE ID = @TestDocGiaID;

-- Dọn dẹp: Quay lại trạng thái ban đầu để không ảnh hưởng dữ liệu
ROLLBACK TRANSACTION;
PRINT N'--- Kịch bản hoàn tất và dữ liệu đã được khôi phục (ROLLBACK) ---';
GO
