    
-- ===================================================
-- SCRIPT TẠO DATABASE HỆ THỐNG QUẢN LÝ THƯ VIỆN (MySQL)
-- ===================================================

-- Tạo database
CREATE DATABASE IF NOT EXISTS QuanLyThuVien CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE QuanLyThuVien;

-- ===================================================
-- TẠO CÁC BẢNG
-- ===================================================

-- Bảng Độc giả
CREATE TABLE DocGia (
    MaDocGia INT PRIMARY KEY AUTO_INCREMENT,
    -- TenDangNhap VARCHAR(50) UNIQUE NOT NULL,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh VARCHAR(10),
    DiaChi VARCHAR(200),
    Email VARCHAR(100),
    SoDienThoai VARCHAR(20),
    NgayDangKy DATE DEFAULT (CURRENT_DATE)
);

-- Bảng Nhân viên
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY AUTO_INCREMENT,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh VARCHAR(10),
    DiaChi VARCHAR(200),
    SoDienThoai VARCHAR(20),
    -- ChucVu VARCHAR(50),
    NgayVaoLam DATE DEFAULT (CURRENT_DATE)
);

-- Bảng Thẻ thư viện
CREATE TABLE TheThuVien (
    MaThe INT PRIMARY KEY AUTO_INCREMENT,
    MaDocGia INT,
    NgayTao DATE DEFAULT (CURRENT_DATE),
    TrangThai VARCHAR(20) DEFAULT 'Hoạt động', -- Hoạt động / Bị khóa
    QRCode VARCHAR(255) -- Mã QR cho check-in online
);

-- Bảng Thể loại
CREATE TABLE TheLoai (
    MaTheLoai INT PRIMARY KEY AUTO_INCREMENT,
    TenTheLoai VARCHAR(100) NOT NULL,
    MoTa TEXT
);

-- Bảng Nhà xuất bản
CREATE TABLE NhaXuatBan (
    MaNXB INT PRIMARY KEY AUTO_INCREMENT,
    TenNXB VARCHAR(100) NOT NULL,
    DiaChi VARCHAR(200),
    SoDienThoai VARCHAR(20)
);

-- Bảng Tác giả
CREATE TABLE TacGia (
    MaTacGia INT PRIMARY KEY AUTO_INCREMENT,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    QuocTich VARCHAR(50)
);

-- Bảng Sách
CREATE TABLE Sach (
    MaSach INT PRIMARY KEY AUTO_INCREMENT,
    TieuDe VARCHAR(200) NOT NULL,
    ISBN VARCHAR(20),
    NamXuatBan INT,
    GiaSach DECIMAL(10,2),
    SoLuongTong INT DEFAULT 0,
    SoLuongCon INT DEFAULT 0,
    MaNXB INT,
    MaTheLoai INT
);

-- Bảng Sách - Tác giả (nhiều-nhiều)
CREATE TABLE Sach_TacGia (
    MaSach INT,
    MaTacGia INT,
    PRIMARY KEY (MaSach, MaTacGia)
);

-- Bảng Nhà cung cấp
CREATE TABLE NhaCungCap (
    MaNCC INT PRIMARY KEY AUTO_INCREMENT,
    TenNCC VARCHAR(100) NOT NULL,
    DiaChi VARCHAR(200),
    SoDienThoai VARCHAR(20)
);

-- Bảng Nhập sách
CREATE TABLE NhapSach (
    MaPhieuNhap INT PRIMARY KEY AUTO_INCREMENT,
    MaNCC INT,
    NgayNhap DATE DEFAULT (CURRENT_DATE),
    MaNhanVien INT,
    TongTien DECIMAL(10,2)
);

-- Bảng Chi tiết nhập sách
CREATE TABLE ChiTietNhapSach (
    MaPhieuNhap INT,
    MaSach INT,
    SoLuong INT,
    DonGia DECIMAL(10,2),
    PRIMARY KEY (MaPhieuNhap, MaSach)
);

-- Bảng Phiếu mượn
CREATE TABLE PhieuMuon (
    MaPhieuMuon INT PRIMARY KEY AUTO_INCREMENT,
    MaDocGia INT,
    MaNhanVien INT,
    NgayMuon DATE DEFAULT (CURRENT_DATE),
    HanTra DATE,
    TrangThai VARCHAR(20) DEFAULT 'Đang mượn'
);

-- Bảng Chi tiết mượn
CREATE TABLE ChiTietMuon (
    MaPhieuMuon INT,
    MaSach INT,
    SoLuong INT,
    PRIMARY KEY (MaPhieuMuon, MaSach)
);

-- Bảng Phiếu trả
CREATE TABLE PhieuTra (
    MaPhieuTra INT PRIMARY KEY AUTO_INCREMENT,
    MaPhieuMuon INT,
    NgayTra DATE DEFAULT (CURRENT_DATE),
    TinhTrangSach VARCHAR(100),
    TienPhat DECIMAL(10,2) DEFAULT 0
);

-- Bảng Phiếu phạt
CREATE TABLE PhieuPhat (
    MaPhieuPhat INT PRIMARY KEY AUTO_INCREMENT,
    MaDocGia INT,
    LyDo VARCHAR(200),
    SoTien DECIMAL(10,2),
    NgayLap DATE DEFAULT (CURRENT_DATE)
);

-- Bảng Đăng nhập
CREATE TABLE DangNhap (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(255) NOT NULL,
    VaiTro ENUM('DocGia','NhanVien') NOT NULL,
    MaDocGia INT NULL,
    MaNhanVien INT NULL,
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);


-- ===================================================
-- TẠO CÁC RÀNG BUỘC KHÓA NGOẠI
-- ===================================================

-- Khóa ngoại cho bảng TheThuVien
ALTER TABLE TheThuVien
ADD CONSTRAINT FK_TheThuVien_DocGia
FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia);

-- Khóa ngoại cho bảng Sách
ALTER TABLE Sach
ADD CONSTRAINT FK_Sach_NhaXuatBan
FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB);

ALTER TABLE Sach
ADD CONSTRAINT FK_Sach_TheLoai
FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai);

-- Khóa ngoại cho bảng Sach_TacGia
ALTER TABLE Sach_TacGia
ADD CONSTRAINT FK_SachTacGia_Sach
FOREIGN KEY (MaSach) REFERENCES Sach(MaSach);

ALTER TABLE Sach_TacGia
ADD CONSTRAINT FK_SachTacGia_TacGia
FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia);

-- Khóa ngoại cho bảng NhapSach
ALTER TABLE NhapSach
ADD CONSTRAINT FK_NhapSach_NhaCungCap
FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC);

ALTER TABLE NhapSach
ADD CONSTRAINT FK_NhapSach_NhanVien
FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien);

-- Khóa ngoại cho bảng ChiTietNhapSach
ALTER TABLE ChiTietNhapSach
ADD CONSTRAINT FK_ChiTietNhapSach_NhapSach
FOREIGN KEY (MaPhieuNhap) REFERENCES NhapSach(MaPhieuNhap);

ALTER TABLE ChiTietNhapSach
ADD CONSTRAINT FK_ChiTietNhapSach_Sach
FOREIGN KEY (MaSach) REFERENCES Sach(MaSach);

-- Khóa ngoại cho bảng PhieuMuon
ALTER TABLE PhieuMuon
ADD CONSTRAINT FK_PhieuMuon_DocGia
FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia);

ALTER TABLE PhieuMuon
ADD CONSTRAINT FK_PhieuMuon_NhanVien
FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien);

-- Khóa ngoại cho bảng ChiTietMuon
ALTER TABLE ChiTietMuon
ADD CONSTRAINT FK_ChiTietMuon_PhieuMuon
FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon);

ALTER TABLE ChiTietMuon
ADD CONSTRAINT FK_ChiTietMuon_Sach
FOREIGN KEY (MaSach) REFERENCES Sach(MaSach);

-- Khóa ngoại cho bảng PhieuTra
ALTER TABLE PhieuTra
ADD CONSTRAINT FK_PhieuTra_PhieuMuon
FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon);

-- Khóa ngoại cho bảng PhieuPhat
ALTER TABLE PhieuPhat
ADD CONSTRAINT FK_PhieuPhat_DocGia
FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia);

-- Khóa ngoại cho bảng DangNhap
ALTER TABLE DangNhap
ADD CONSTRAINT FK_DangNhap_NhanVien
FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien);

ALTER TABLE DangNhap
ADD CONSTRAINT FK_DangNhap_DocGia
FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia);

-- ===================================================
-- THÊM DỮ LIỆU MẪU
-- ===================================================

-- Thêm dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, NgayVaoLam) VALUES
(N'Nguyễn Văn An', '1985-06-15', N'Nam', N'123 Trần Hưng Đạo, Q1, TP.HCM', '0901234567', '2020-01-15'),
(N'Trần Thị Bình', '1990-03-22', N'Nữ', N'456 Lê Lợi, Q3, TP.HCM', '0912345678', '2021-05-10'),
(N'Lê Minh Cường', '1988-11-08', N'Nam', N'789 Nguyễn Huệ, Q1, TP.HCM', '0923456789', '2022-02-20');

-- Thêm dữ liệu cho bảng DocGia
INSERT INTO DocGia (HoTen, NgaySinh, GioiTinh, DiaChi, Email, SoDienThoai, NgayDangKy) VALUES
(N'Phạm Văn Đức', '1995-07-12', N'Nam', N'12 Võ Văn Tần, Q3, TP.HCM', 'ducpv@gmail.com', '0934567890', '2023-01-10'),
(N'Nguyễn Thị Esen', '1992-09-25', N'Nữ', N'34 Hai Bà Trưng, Q1, TP.HCM', 'esenngt@gmail.com', '0945678901', '2023-02-15'),
(N'Trần Minh Phúc', '1998-04-03', N'Nam', N'56 Điện Biên Phủ, Q3, TP.HCM', 'phuctm@gmail.com', '0956789012', '2023-03-20'),
(N'Lê Thị Giang', '1996-12-18', N'Nữ', N'78 Cách Mạng Tháng Tám, Q10, TP.HCM', 'gianglt@gmail.com', '0967890123', '2023-04-05'),
(N'Hoàng Văn Hùng', '1994-02-28', N'Nam', N'90 Nam Kỳ Khởi Nghĩa, Q1, TP.HCM', 'hunghv@gmail.com', '0978901234', '2023-05-12');

-- Thêm dữ liệu cho bảng TheThuVien
INSERT INTO TheThuVien (MaDocGia, NgayTao, TrangThai, QRCode) VALUES
(1, '2023-01-10', 'Hoạt động', CONCAT('QR001_', UUID())),
(2, '2023-02-15', 'Hoạt động', CONCAT('QR002_', UUID())),
(3, '2023-03-20', 'Hoạt động', CONCAT('QR003_', UUID())),
(4, '2023-04-05', 'Hoạt động', CONCAT('QR004_', UUID())),
(5, '2023-05-12', 'Bị khóa', CONCAT('QR005_', UUID()));

-- Thêm dữ liệu cho bảng TheLoai
INSERT INTO TheLoai (TenTheLoai, MoTa) VALUES
(N'Văn học', N'Sách về văn học trong nước và quốc tế'),
(N'Khoa học kỹ thuật', N'Sách về các lĩnh vực khoa học và kỹ thuật'),
(N'Kinh tế', N'Sách về kinh tế, quản trị kinh doanh'),
(N'Lịch sử', N'Sách về lịch sử Việt Nam và thế giới'),
(N'Tâm lý học', N'Sách về tâm lý học và phát triển bản thân'),
(N'Tin học', N'Sách về tin học và công nghệ thông tin'),
(N'Y học', N'Sách về y học và sức khỏe'),
(N'Giáo dục', N'Sách giáo khoa và tham khảo giáo dục');

-- Thêm dữ liệu cho bảng NhaXuatBan
INSERT INTO NhaXuatBan (TenNXB, DiaChi, SoDienThoai) VALUES
(N'NXB Trẻ', N'161B Lý Chính Thắng, Q3, TP.HCM', '0283932419'),
(N'NXB Kim Đồng', N'55 Quang Trung, Hai Bà Trưng, Hà Nội', '0243943568'),
(N'NXB Giáo dục Việt Nam', N'81 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội', '0243822543'),
(N'NXB Lao động', N'175 Giảng Võ, Đống Đa, Hà Nội', '0243943361'),
(N'NXB Thông tin và Truyền thông', N'18 Nguyễn Du, Hai Bà Trưng, Hà Nội', '0243944359');

-- Thêm dữ liệu cho bảng TacGia
INSERT INTO TacGia (HoTen, NgaySinh, QuocTich) VALUES
(N'Nguyễn Nhật Ánh', '1955-05-07', N'Việt Nam'),
(N'Tô Hoài', '1920-09-27', N'Việt Nam'),
(N'Nam Cao', '1915-10-29', N'Việt Nam'),
(N'Haruki Murakami', '1949-01-12', N'Nhật Bản'),
(N'Paulo Coelho', '1947-08-24', N'Brazil'),
(N'Dale Carnegie', '1888-11-24', N'Mỹ'),
(N'Robert Kiyosaki', '1947-04-08', N'Mỹ'),
(N'Stephen Hawking', '1942-01-08', N'Anh');

-- Thêm dữ liệu cho bảng Sach
INSERT INTO Sach (TieuDe, ISBN, NamXuatBan, GiaSach, SoLuongTong, SoLuongCon, MaNXB, MaTheLoai) VALUES
(N'Tôi thấy hoa vàng trên cỏ xanh', '978-604-2-08529-3', 2010, 89000, 15, 12, 1, 1),
(N'Dế Mèn phiêu lưu ký', '978-604-2-13456-7', 2005, 65000, 20, 18, 2, 1),
(N'Chí Phèo', '978-604-2-45678-9', 1941, 45000, 10, 8, 3, 1),
(N'Kafka bên bờ biển', '978-604-2-78901-2', 2020, 125000, 8, 5, 1, 1),
(N'Nhà giả kim', '978-604-2-34567-8', 2018, 95000, 12, 10, 4, 1),
(N'Đắc nhân tâm', '978-604-2-56789-0', 2019, 78000, 25, 22, 4, 5),
(N'Cha giàu cha nghèo', '978-604-2-67890-1', 2017, 110000, 18, 15, 4, 3),
(N'Lược sử thời gian', '978-604-2-89012-3', 2016, 135000, 6, 4, 5, 2);

-- Thêm dữ liệu cho bảng Sach_TacGia
INSERT INTO Sach_TacGia (MaSach, MaTacGia) VALUES
(1, 1), -- Tôi thấy hoa vàng trên cỏ xanh - Nguyễn Nhật Ánh
(2, 2), -- Dế Mèn phiêu lưu ký - Tô Hoài
(3, 3), -- Chí Phèo - Nam Cao
(4, 4), -- Kafka bên bờ biển - Haruki Murakami
(5, 5), -- Nhà giả kim - Paulo Coelho
(6, 6), -- Đắc nhân tâm - Dale Carnegie
(7, 7), -- Cha giàu cha nghèo - Robert Kiyosaki
(8, 8); -- Lược sử thời gian - Stephen Hawking

-- Thêm dữ liệu cho bảng NhaCungCap
INSERT INTO NhaCungCap (TenNCC, DiaChi, SoDienThoai) VALUES
(N'Công ty Sách Fahasa', N'60-62 Lê Lợi, Q1, TP.HCM', '02838225798'),
(N'Công ty Nhã Nam', N'59 Đỗ Quang, Cầu Giấy, Hà Nội', '02436269018'),
(N'Công ty Alphabooks', N'14 Phan Đăng Lưu, Phú Nhuận, TP.HCM', '02838454059');

-- Thêm dữ liệu cho bảng NhapSach
INSERT INTO NhapSach (MaNCC, NgayNhap, MaNhanVien, TongTien) VALUES
(1, '2023-01-15', 1, 2500000),
(2, '2023-02-20', 2, 1800000),
(3, '2023-03-10', 1, 3200000);

-- Thêm dữ liệu cho bảng ChiTietNhapSach
INSERT INTO ChiTietNhapSach (MaPhieuNhap, MaSach, SoLuong, DonGia) VALUES
(1, 1, 15, 75000), -- Tôi thấy hoa vàng trên cỏ xanh
(1, 6, 25, 65000), -- Đắc nhân tâm
(2, 2, 20, 55000), -- Dế Mèn phiêu lưu ký
(2, 5, 12, 85000), -- Nhà giả kim
(3, 4, 8, 110000), -- Kafka bên bờ biển
(3, 7, 18, 95000), -- Cha giàu cha nghèo
(3, 8, 6, 120000); -- Lược sử thời gian

-- Thêm dữ liệu cho bảng PhieuMuon
INSERT INTO PhieuMuon (MaDocGia, MaNhanVien, NgayMuon, HanTra, TrangThai) VALUES
(1, 2, '2023-06-01', '2023-06-15', N'Đã trả'),
(2, 1, '2023-06-05', '2023-06-19', N'Đang mượn'),
(3, 2, '2023-06-10', '2023-06-24', N'Đang mượn'),
(4, 1, '2023-06-12', '2023-06-26', N'Quá hạn'),
(1, 2, '2023-06-20', '2023-07-04', N'Đang mượn');

-- Thêm dữ liệu cho bảng ChiTietMuon
INSERT INTO ChiTietMuon (MaPhieuMuon, MaSach, SoLuong) VALUES
(1, 1, 1), -- Phiếu mượn 1: Tôi thấy hoa vàng trên cỏ xanh
(1, 6, 1), -- Phiếu mượn 1: Đắc nhân tâm
(2, 2, 1), -- Phiếu mượn 2: Dế Mèn phiêu lưu ký
(2, 5, 1), -- Phiếu mượn 2: Nhà giả kim
(3, 4, 1), -- Phiếu mượn 3: Kafka bên bờ biển
(4, 7, 1), -- Phiếu mượn 4: Cha giàu cha nghèo
(4, 8, 1), -- Phiếu mượn 4: Lược sử thời gian
(5, 3, 1); -- Phiếu mượn 5: Chí Phèo

-- Thêm dữ liệu cho bảng PhieuTra
INSERT INTO PhieuTra (MaPhieuMuon, NgayTra, TinhTrangSach, TienPhat) VALUES
(1, '2023-06-14', N'Tốt', 0); -- Trả đúng hạn

-- Thêm dữ liệu cho bảng PhieuPhat
INSERT INTO PhieuPhat (MaDocGia, LyDo, SoTien, NgayLap) VALUES
(4, N'Trả sách quá hạn 5 ngày', 50000, '2023-07-01'),
(5, N'Làm hỏng sách', 120000, '2023-06-25');

-- Thêm dữ liệu cho bảng DangNhap
INSERT INTO DangNhap (TenDangNhap, MatKhau, VaiTro, MaDocGia, MaNhanVien) VALUES
('admin', '123456', 'NhanVien', NULL, 1),
('thutkhu1', '123456', 'NhanVien', NULL, 2),
('kythuat1', '123456', 'NhanVien', NULL, 3),
('docgia001', '123456', 'DocGia', 1, NULL),
('docgia002', '123456', 'DocGia', 2, NULL),
('docgia003', '123456', 'DocGia', 3, NULL),
('docgia004', '123456', 'DocGia', 4, NULL),
('docgia005', '123456', 'DocGia', 5, NULL);

-- ===================================================
-- TRIGGER CẬP NHẬT SỐ LƯỢNG SÁCH
-- ===================================================

-- Trigger cập nhật số lượng sách khi nhập
DELIMITER $$
CREATE TRIGGER trg_UpdateSachAfterNhap
AFTER INSERT ON ChiTietNhapSach
FOR EACH ROW
BEGIN
    UPDATE Sach
    SET SoLuongTong = SoLuongTong + NEW.SoLuong,
        SoLuongCon = SoLuongCon + NEW.SoLuong
    WHERE MaSach = NEW.MaSach;
END$$
DELIMITER ;

-- Trigger cập nhật số lượng sách khi mượn
DELIMITER $$
CREATE TRIGGER trg_UpdateSachAfterMuon
AFTER INSERT ON ChiTietMuon
FOR EACH ROW
BEGIN
    UPDATE Sach
    SET SoLuongCon = SoLuongCon - NEW.SoLuong
    WHERE MaSach = NEW.MaSach;
END$$
DELIMITER ;

-- Trigger cập nhật số lượng sách khi trả
DELIMITER $$
CREATE TRIGGER trg_UpdateSachAfterTra
AFTER INSERT ON PhieuTra
FOR EACH ROW
BEGIN
    UPDATE Sach s
    INNER JOIN ChiTietMuon ct ON NEW.MaPhieuMuon = ct.MaPhieuMuon
    SET s.SoLuongCon = s.SoLuongCon + ct.SoLuong
    WHERE s.MaSach = ct.MaSach;
END$$
DELIMITER ;

-- ===================================================
-- STORED PROCEDURES
-- ===================================================

-- Procedure tìm kiếm sách
DELIMITER $$
CREATE PROCEDURE sp_TimKiemSach(
    IN p_TuKhoa VARCHAR(200)
)
BEGIN
    SELECT s.MaSach, s.TieuDe, s.ISBN, s.NamXuatBan, s.GiaSach, 
           s.SoLuongTong, s.SoLuongCon,
           tl.TenTheLoai, nxb.TenNXB,
           GROUP_CONCAT(tg.HoTen SEPARATOR ', ') AS TacGia
    FROM Sach s
    LEFT JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
    LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
    LEFT JOIN Sach_TacGia stg ON s.MaSach = stg.MaSach
    LEFT JOIN TacGia tg ON stg.MaTacGia = tg.MaTacGia
    WHERE s.TieuDe LIKE CONCAT('%', p_TuKhoa, '%')
       OR tg.HoTen LIKE CONCAT('%', p_TuKhoa, '%')
       OR tl.TenTheLoai LIKE CONCAT('%', p_TuKhoa, '%')
    GROUP BY s.MaSach, s.TieuDe, s.ISBN, s.NamXuatBan, s.GiaSach, 
             s.SoLuongTong, s.SoLuongCon, tl.TenTheLoai, nxb.TenNXB
    ORDER BY s.TieuDe;
END$$
DELIMITER ;

-- Procedure báo cáo sách được mượn nhiều nhất
DELIMITER $$
CREATE PROCEDURE sp_BaoCaoSachPhoBien(
    IN p_NgayBatDau DATE,
    IN p_NgayKetThuc DATE,
    IN p_Top INT
)
BEGIN
    IF p_Top IS NULL THEN
        SET p_Top = 10;
    END IF;
    
    SELECT s.MaSach, s.TieuDe, 
           COUNT(ct.MaSach) AS SoLanMuon,
           SUM(ct.SoLuong) AS TongSoLuongMuon
    FROM Sach s
    INNER JOIN ChiTietMuon ct ON s.MaSach = ct.MaSach
    INNER JOIN PhieuMuon pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
    WHERE pm.NgayMuon BETWEEN p_NgayBatDau AND p_NgayKetThuc
    GROUP BY s.MaSach, s.TieuDe
    ORDER BY COUNT(ct.MaSach) DESC, SUM(ct.SoLuong) DESC
    LIMIT p_Top;
END$$
DELIMITER ;

SELECT 'Script tạo database và dữ liệu mẫu đã hoàn thành!' AS KetQua;
SELECT '- Đã tạo 13 bảng với đầy đủ ràng buộc khóa ngoại' AS ThongTin;
SELECT '- Đã thêm dữ liệu mẫu cho tất cả các bảng' AS ThongTin;
SELECT '- Đã tạo trigger tự động cập nhật số lượng sách' AS ThongTin;
SELECT '- Đã tạo stored procedure hỗ trợ tìm kiếm và báo cáo' AS ThongTin;