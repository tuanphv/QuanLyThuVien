-- =========================================================================
-- KHỞI TẠO CƠ SỞ DỮ LIỆU
-- =========================================================================
DROP DATABASE IF EXISTS QLTV;
CREATE DATABASE QLTV;
USE QLTV;

-- =========================================================================
-- 1. ĐỊNH NGHĨA CÁC BẢNG (TABLES)
-- =========================================================================

-- Bảng NHOMNGUOIDUNG
CREATE TABLE NHOMNGUOIDUNG
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaNhomNguoiDung CHAR(6),
	TenNhomNguoiDung VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL
);

-- Bảng CHUCNANG
CREATE TABLE CHUCNANG
(
	ID INT PRIMARY KEY AUTO_INCREMENT,
	MaChucNang CHAR(5),
	TenChucNang VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL, -- Tên ngắn gọn của chức năng
	TenManHinh VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL -- Tên chức năng hiển thị trên màn hình phân quyền
);

-- Bảng PHANQUYEN
CREATE TABLE PHANQUYEN
(
	IDNhomNguoiDung INT,
	IDChucNang INT,
    HanhDong ENUM('THEM', 'SUA', 'XOA', 'XEM'),
	PRIMARY KEY (IDNhomNguoiDung, IDChucNang, HanhDong),
	FOREIGN KEY (IDNhomNguoiDung) REFERENCES NHOMNGUOIDUNG(ID) ON DELETE CASCADE,
	FOREIGN KEY (IDChucNang) REFERENCES CHUCNANG(ID) ON DELETE CASCADE
);

-- Bảng NGUOIDUNG
CREATE TABLE NGUOIDUNG
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaNguoiDung CHAR(6),
	TenNguoiDung VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL,
	NgaySinh DATETIME,
	ChucVu VARCHAR(255) CHARACTER SET UTF8MB4,
	TenDangNhap VARCHAR(256) UNIQUE NOT NULL,
	MatKhau VARCHAR(255) NOT NULL,
	IDNhomNguoiDung INT NOT NULL,
	FOREIGN KEY (IDNhomNguoiDung) REFERENCES NHOMNGUOIDUNG(ID) ON DELETE CASCADE
);

-- Bảng THAMSO
CREATE TABLE THAMSO
(
        ID INT AUTO_INCREMENT PRIMARY KEY,
        TuoiToiThieu INT NOT NULL,
        TuoiToiDa INT NOT NULL,
        ThoiHanThe INT NOT NULL,
        KhoangCachXuatBan INT NOT NULL,
        SoSachMuonToiDa INT NOT NULL,
        SoNgayMuonToiDa INT NOT NULL,
        DonGiaPhatMoiNgay INT NOT NULL
);

-- Bảng QUYDINHPHAT (quy định xử phạt theo tình trạng sách)
CREATE TABLE QUYDINHPHAT
(
        ID INT AUTO_INCREMENT PRIMARY KEY,
        MaQuyDinh CHAR(6),
        LoaiTinhTrang ENUM('MOI', 'BAN', 'UOT', 'RACH', 'MAT') NOT NULL,
        MucDo VARCHAR(50),
        TienPhat INT NOT NULL,
        GhiChu VARCHAR(255)
);

-- Bảng TUASACH
CREATE TABLE TUASACH
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaTuaSach CHAR(6),
	TenTuaSach VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL,
	AnhBia MEDIUMBLOB,
	DaAn INT DEFAULT 0
);

-- Bảng THELOAI
CREATE TABLE THELOAI
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaTheLoai CHAR(6),
	TenTheLoai VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL
);

-- Bảng CT_THELOAI (Bảng trung gian N:N: Tựa sách - Thể loại)
CREATE TABLE CT_THELOAI
(
	IDTuaSach INT,
	IDTheLoai INT,
	PRIMARY KEY (IDTuaSach, IDTheLoai),
	FOREIGN KEY (IDTuaSach) REFERENCES TUASACH(ID) ON DELETE CASCADE,
	FOREIGN KEY (IDTheLoai) REFERENCES THELOAI(ID) ON DELETE CASCADE
);

-- Bảng TACGIA
CREATE TABLE TACGIA
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MATACGIA CHAR(6),
	TenTacGia VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL,
	NamSinh INT DEFAULT NULL
);

-- Bảng CT_TACGIA (Bảng trung gian N:N: Tác giả - Tựa sách)
CREATE TABLE CT_TACGIA
(
	IDTacGia INT,
	IDTuaSach INT,
	primary key (IDTacGia, IDTuaSach),
	FOREIGN KEY (IDTacGia) REFERENCES TACGIA(ID) ON DELETE CASCADE,
	FOREIGN KEY (IDTuaSach) REFERENCES TUASACH(ID) ON DELETE CASCADE
);

-- Bảng DOCGIA
CREATE TABLE DOCGIA
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaDocGia CHAR(6),
	HoTen VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL,
	NgaySinh DATETIME NOT NULL,
	DiaChi VARCHAR(255) CHARACTER SET UTF8MB4,
	NgayLapThe DATETIME NOT NULL,
	NgayHetHan DATETIME NOT NULL,
	TongNoHienTai INT NOT NULL DEFAULT 0,
	IDNguoiDung INT UNIQUE,
	FOREIGN KEY (IDNguoiDung) REFERENCES NGUOIDUNG(ID) ON DELETE SET NULL
);

-- Bảng NHAXUATBAN (Nhà xuất bản sách)
CREATE TABLE NHAXUATBAN
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
    TenNXB VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL,
	DiaChi VARCHAR(255) CHARACTER SET UTF8MB4
);

-- Bảng SACH (Phiên bản sách/Ấn phẩm)
CREATE TABLE SACH
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaSach CHAR(5),
	IDTuaSach INT NOT NULL,
	SoLuongTong INT NOT NULL,
	SoLuongConLai INT NOT NULL,
	DonGia INT,
	NamXB INT NOT NULL,
	IDNhaXuatBan INT NOT NULL,
	DaAn INT NOT NULL DEFAULT 0,
	FOREIGN KEY (IDTuaSach) REFERENCES TUASACH(ID),
    FOREIGN KEY (IDNhaXuatBan) REFERENCES NHAXUATBAN(ID)
);

-- Bảng CUONSACH (Cuốn sách vật lý)
CREATE TABLE CUONSACH
(
        ID INT AUTO_INCREMENT PRIMARY KEY,
        MaCuonSach CHAR(10),
        IDSach INT NOT NULL,
        TinhTrang INT NOT NULL DEFAULT 1, -- (0: Đang mượn, 1: Sẵn sàng, 2: Không khả dụng)
        ChiTietTinhTrang VARCHAR(255) CHARACTER SET UTF8MB4 NULL,
        DaAn INT NOT NULL DEFAULT 0,
        FOREIGN KEY (IDSach) REFERENCES SACH(ID)
);

-- Bảng PHIEUMUON (Phiếu tổng)
CREATE TABLE PHIEUMUON
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaPhieuMuon CHAR(8),
	IDDocGia INT NOT NULL,
	NgayMuon Datetime NOT NULL,
	NgayTraDuKien Datetime NOT NULL,
	TrangThai INT NOT NULL DEFAULT 1, -- (0: Đã hoàn tất, 1: Đang hoạt động)
	FOREIGN KEY (IDDocGia) REFERENCES DOCGIA(ID)
);

-- Bảng CT_PHIEUMUON (Chi tiết cuốn sách mượn/trả)
CREATE TABLE CT_PHIEUMUON
(
        IDPhieuMuon INT,
        IDCuonSach INT,
        TinhTrangMuon VARCHAR(255),
        PRIMARY KEY (IDPhieuMuon, IDCuonSach),
        FOREIGN KEY (IDPhieuMuon) REFERENCES PHIEUMUON(ID) ON DELETE CASCADE,
        FOREIGN KEY (IDCuonSach) REFERENCES CUONSACH(ID) ON DELETE CASCADE
);

-- Bảng PHIEUTRA
CREATE TABLE PHIEUTRA
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
    MaPhieuTra CHAR(8),
    IDPhieuMuon INT NOT NULL,
    NgayTra DATETIME NOT NULL,
    TongTienPhat INT DEFAULT 0,
    FOREIGN KEY (IDPhieuMuon) REFERENCES PHIEUMUON(ID)
);

-- Bảng CT_PHIEUTRA
CREATE TABLE CT_PHIEUTRA
(
	IDPhieuTra INT,
    IDCuonSach INT,
    IDQuyDinhPhat INT,
	SoNgayTre INT DEFAULT 0,
	TinhTrangTra VARCHAR(255),
    TienPhat INT DEFAULT 0,
    PRIMARY KEY (IDPhieuTra, IDCuonSach),
    FOREIGN KEY (IDPhieuTra) REFERENCES PHIEUTRA(ID) ON DELETE CASCADE,
    FOREIGN KEY (IDCuonSach) REFERENCES CUONSACH(ID) ON DELETE CASCADE,
    FOREIGN KEY (IDQuyDinhPhat) REFERENCES QUYDINHPHAT(ID)
);

-- Bảng PHIEUTHU
CREATE TABLE PHIEUTHU
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaPhieuThu CHAR(8),
	IDDocGia INT NOT NULL,
	SoTienThu INT NOT NULL DEFAULT 0,
	NgayLap DATETIME NOT NULL,
	FOREIGN KEY (IDDocGia) REFERENCES DOCGIA(ID)
);

-- Bảng NHACUNGCAP
CREATE TABLE NHACUNGCAP
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	TenNCC VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL,
	DiaChi VARCHAR(255) CHARACTER SET UTF8MB4
);

-- Bảng PHIEUNHAPSACH
CREATE TABLE PHIEUNHAPSACH
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaPhieuNhap CHAR(8),
	IDNhaCungCap INT NOT NULL,
	NgayNhap Datetime NOT NULL,
	TongTien INT NOT NULL DEFAULT 0,
	FOREIGN KEY (IDNhaCungCap) REFERENCES NHACUNGCAP(ID)
);

-- Bảng CT_PHIEUNHAP
CREATE TABLE CT_PHIEUNHAP
(
	IDPhieuNhap INT,
	IDSach INT,
	SoLuongNhap INT NOT NULL,
	DonGiaNhap INT NOT NULL,
	ThanhTien INT AS (SoLuongNhap * DonGiaNhap) STORED,
	PRIMARY KEY (IDPhieuNhap, IDSach),
	FOREIGN KEY (IDPhieuNhap) REFERENCES PHIEUNHAPSACH(ID) ON DELETE CASCADE,
	FOREIGN KEY (IDSach) REFERENCES SACH(ID) ON DELETE CASCADE
);

-- =========================================================================
-- 2. TRIGGERS - PHÙ HỢP VỚI BẢNG ĐÃ TẠO
-- =========================================================================

DELIMITER //

-- Triggers tạo mã tự động
CREATE TRIGGER before_insert_NHOMNGUOIDUNG BEFORE INSERT ON NHOMNGUOIDUNG
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM NHOMNGUOIDUNG);
    SET NEW.MaNhomNguoiDung = CONCAT('NND', LPAD(@next_ID, 3, '0'));
END //

CREATE TRIGGER before_insert_CHUCNANG BEFORE INSERT ON CHUCNANG
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM CHUCNANG);
    SET NEW.MaChucNang = CONCAT('CN', LPAD(@next_ID, 3, '0'));
END //

CREATE TRIGGER before_insert_NGUOIDUNG BEFORE INSERT ON NGUOIDUNG
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM NGUOIDUNG);
    SET NEW.MaNguoiDung = CONCAT('ND', LPAD(@next_ID, 4, '0'));
END //

CREATE TRIGGER before_insert_THELOAI BEFORE INSERT ON THELOAI
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM THELOAI);
    SET NEW.MaTheLoai = CONCAT('TL', LPAD(@next_ID, 4, '0'));
END //

CREATE TRIGGER before_insert_TUASACH BEFORE INSERT ON TUASACH
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM TUASACH);
    SET NEW.MaTuaSach = CONCAT('TS', LPAD(@next_ID, 4, '0'));
END //

CREATE TRIGGER before_insert_TACGIA BEFORE INSERT ON TACGIA
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM TACGIA);
    SET NEW.MATACGIA = CONCAT('TG', LPAD(@next_ID, 4, '0'));
END //

CREATE TRIGGER before_insert_DOCGIA BEFORE INSERT ON DOCGIA
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM DOCGIA);
    SET NEW.MaDocGia = CONCAT('DG', LPAD(@next_ID, 4, '0'));
END //

CREATE TRIGGER before_insert_SACH BEFORE INSERT ON SACH
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM SACH);
    SET NEW.MaSach = CONCAT('S', LPAD(@next_ID, 4, '0'));
END //

CREATE TRIGGER before_insert_CUONSACH
BEFORE INSERT ON CUONSACH
FOR EACH ROW
BEGIN
    DECLARE next_num INT;
    DECLARE maSachVal VARCHAR(50);

    -- Lấy MaSach từ bảng Sach dựa trên IDSach
    SELECT MaSach INTO maSachVal
    FROM Sach
    WHERE ID = NEW.IDSach;

    -- Lấy số lượng cuốn sách hiện có của MaSach này
    SET next_num = (SELECT COUNT(*) FROM CUONSACH WHERE IDSach = NEW.IDSach) + 1;

    -- Nếu MaCuonSach rỗng thì sinh tự động
    IF NEW.MaCuonSach IS NULL OR NEW.MaCuonSach = '' THEN
        SET NEW.MaCuonSach = CONCAT(maSachVal, '-', LPAD(next_num, 4, '0'));
    END IF;
END //

CREATE TRIGGER before_insert_PHIEUMUON BEFORE INSERT ON PHIEUMUON
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM PHIEUMUON);
    SET NEW.MaPhieuMuon = CONCAT('PM', LPAD(@next_ID, 6, '0'));
END //

CREATE TRIGGER before_insert_PHIEUTRA BEFORE INSERT ON PHIEUTRA
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM PHIEUTRA);
    SET NEW.MaPhieuTra = CONCAT('PTR', LPAD(@next_ID, 5, '0'));
END //

CREATE TRIGGER before_insert_PHIEUTHU BEFORE INSERT ON PHIEUTHU
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM PHIEUTHU);
    SET NEW.MaPhieuThu = CONCAT('PTH', LPAD(@next_ID, 5, '0'));
END //

CREATE TRIGGER before_insert_PHIEUNHAPSACH BEFORE INSERT ON PHIEUNHAPSACH
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM PHIEUNHAPSACH);
    SET NEW.MaPhieuNhap = CONCAT('PN', LPAD(@next_ID, 6, '0'));
END //

CREATE TRIGGER before_insert_QUYDINHPHAT BEFORE INSERT ON QUYDINHPHAT
FOR EACH ROW BEGIN
    SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM QUYDINHPHAT);
    SET NEW.MaQuyDinh = CONCAT('QD', LPAD(@next_ID, 4, '0'));
END //

-- =========================================================================
-- TRIGGER QUAN TRỌNG: KHI THÊM CHI TIẾT PHIẾU MƯỢN
-- =========================================================================

CREATE TRIGGER after_insert_CT_PHIEUMUON
AFTER INSERT ON CT_PHIEUMUON
FOR EACH ROW
BEGIN
    -- 1. Cập nhật trạng thái cuốn sách thành "Đang mượn" (0)
    UPDATE CUONSACH
    SET TinhTrang = 0
    WHERE ID = NEW.IDCuonSach;
    
    -- 2. Giảm số lượng sách còn lại
    UPDATE SACH s
    JOIN CUONSACH cs ON s.ID = cs.IDSach
    SET s.SoLuongConLai = s.SoLuongConLai - 1
    WHERE cs.ID = NEW.IDCuonSach;
END //

-- =========================================================================
-- TRIGGER KHI THÊM CHI TIẾT PHIẾU NHẬP
-- =========================================================================

CREATE TRIGGER after_insert_CT_PHIEUNHAP
AFTER INSERT ON CT_PHIEUNHAP
FOR EACH ROW
BEGIN
    -- 1. Cập nhật tổng tiền phiếu nhập
    UPDATE PHIEUNHAPSACH
    SET TongTien = TongTien + NEW.ThanhTien
    WHERE ID = NEW.IDPhieuNhap;
    
    -- 2. Tăng số lượng tổng và số lượng còn lại của sách
    UPDATE SACH
    SET SoLuongTong = SoLuongTong + NEW.SoLuongNhap,
        SoLuongConLai = SoLuongConLai + NEW.SoLuongNhap
    WHERE ID = NEW.IDSach;
END //

-- =========================================================================
-- TRIGGER KHI LẬP PHIẾU THU
-- =========================================================================

CREATE TRIGGER after_insert_PHIEUTHU
AFTER INSERT ON PHIEUTHU
FOR EACH ROW
BEGIN
    -- Giảm nợ của độc giả
    UPDATE DOCGIA
    SET TongNoHienTai = TongNoHienTai - NEW.SoTienThu
    WHERE ID = NEW.IDDocGia;
END //

-- =========================================================================
-- TRIGGER KHI THÊM CHI TIẾT PHIẾU TRẢ
-- =========================================================================

CREATE TRIGGER after_insert_CT_PHIEUTRA
AFTER INSERT ON CT_PHIEUTRA
FOR EACH ROW
BEGIN
    DECLARE id_sach INT;
    DECLARE id_docgia INT;
    DECLARE id_phieumuon INT;
    
    -- 1. Tìm ID sách từ cuốn sách
    SELECT IDSach INTO id_sach FROM CUONSACH WHERE ID = NEW.IDCuonSach;
    
    -- 2. Tìm phiếu mượn và độc giả
    SELECT IDDocGia INTO id_docgia 
    FROM PHIEUMUON 
    WHERE ID = (SELECT IDPhieuMuon FROM PHIEUTRA WHERE ID = NEW.IDPhieuTra);
    
    -- 3. Cập nhật trạng thái cuốn sách thành "Sẵn sàng" (1)
    UPDATE CUONSACH
    SET TinhTrang = 1
    WHERE ID = NEW.IDCuonSach;
    
    -- 4. Tăng số lượng sách còn lại
    UPDATE SACH
    SET SoLuongConLai = SoLuongConLai + 1
    WHERE ID = id_sach;
    
    -- 5. Cập nhật tổng nợ độc giả nếu có tiền phạt
    IF NEW.TienPhat > 0 THEN
        UPDATE DOCGIA
        SET TongNoHienTai = TongNoHienTai + NEW.TienPhat
        WHERE ID = id_docgia;
    END IF;
    
    -- 6. Cập nhật tổng tiền phạt của phiếu trả
    UPDATE PHIEUTRA
    SET TongTienPhat = TongTienPhat + NEW.TienPhat
    WHERE ID = NEW.IDPhieuTra;
    
    -- 7. Kiểm tra nếu tất cả sách đã trả thì đổi trạng thái phiếu mượn
    SET id_phieumuon = (SELECT IDPhieuMuon FROM PHIEUTRA WHERE ID = NEW.IDPhieuTra);
    
    IF NOT EXISTS (
        SELECT 1 FROM CT_PHIEUMUON cpm
        WHERE cpm.IDPhieuMuon = id_phieumuon
        AND NOT EXISTS (
            SELECT 1 FROM CT_PHIEUTRA cpt
            JOIN PHIEUTRA pt ON cpt.IDPhieuTra = pt.ID
            WHERE pt.IDPhieuMuon = id_phieumuon
            AND cpt.IDCuonSach = cpm.IDCuonSach
        )
    ) THEN
        UPDATE PHIEUMUON
        SET TrangThai = 0 -- Đã hoàn tất
        WHERE ID = id_phieumuon;
    END IF;
END //

DELIMITER ;

-- =========================================================================
-- 3. INSERT DỮ LIỆU MẪU - PHÙ HỢP VỚI BẢNG ĐÃ TẠO
-- =========================================================================

-- 1. THAM SỐ HỆ THỐNG
INSERT INTO THAMSO (TuoiToiThieu, TuoiToiDa, ThoiHanThe, KhoangCachXuatBan, SoSachMuonToiDa, SoNgayMuonToiDa, DonGiaPhatMoiNgay)
VALUES (18, 55, 6, 8, 5, 4, 1000);

-- 2. QUY ĐỊNH PHẠT
INSERT INTO QUYDINHPHAT (LoaiTinhTrang, MucDo, TienPhat, GhiChu) VALUES
('MOI', NULL, 0, 'Sách mới, không phạt'),
('BAN', 'NHẸ', 5000, 'Lau sạch được'),
('UOT', 'NHẸ', 8000, 'Ẩm nhẹ, chưa rách'),
('RACH', 'DUOI3', 10000, 'Rách dưới 3 trang'),
('RACH', 'DUOI5', 20000, 'Rách dưới 5 trang'),
('RACH', 'TREN5', 40000, 'Rách trên 5 trang'),
('MAT', NULL, 100000, 'Mất sách, yêu cầu đền bù');

-- 3. NHÓM NGƯỜI DÙNG
INSERT INTO NHOMNGUOIDUNG (TenNhomNguoiDung) VALUES 
('Quản Lý'), 
('Thủ Thư'), 
('Độc Giả');

-- 4. CHỨC NĂNG
INSERT INTO CHUCNANG (TenChucNang, TenManHinh) VALUES
('TQUAN', 'Tổng quan/Báo cáo nhanh'),
('TL', 'Thể loại'),
('TG', 'Tác giả'),
('NXB', 'Nhà xuất bản'),
('NCC', 'Nhà cung cấp'),
('TS', 'Tựa sách'),
('SACH', 'Lô sách & Cuốn sách'),
('PN', 'Phiếu nhập sách'),
('PMS', 'Phiếu mượn sách'),
('PTS', 'Phiếu trả sách'),
('PT', 'Phiếu thu'),
('BCQH', 'Báo cáo quá hạn/phạt'),
('ND', 'Người dùng (Tài khoản)'),
('DG', 'Độc giả'),
('PQ', 'Phân quyền');

-- 5. PHÂN QUYỀN ĐƠN GIẢN
-- Quản lý có tất cả quyền
INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong)
SELECT 1, ID, 'THEM' FROM CHUCNANG
UNION ALL SELECT 1, ID, 'SUA' FROM CHUCNANG
UNION ALL SELECT 1, ID, 'XOA' FROM CHUCNANG
UNION ALL SELECT 1, ID, 'XEM' FROM CHUCNANG;

-- Thủ thư
INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong) VALUES
(2, 1, 'XEM'),
(2, 2, 'XEM'), (2, 2, 'THEM'), (2, 2, 'SUA'),
(2, 3, 'XEM'), (2, 3, 'THEM'), (2, 3, 'SUA'),
(2, 4, 'XEM'), (2, 4, 'THEM'), (2, 4, 'SUA'),
(2, 5, 'XEM'), (2, 5, 'THEM'), (2, 5, 'SUA'),
(2, 6, 'XEM'), (2, 6, 'THEM'), (2, 6, 'SUA'),
(2, 7, 'XEM'), (2, 7, 'THEM'), (2, 7, 'SUA'),
(2, 8, 'XEM'), (2, 8, 'THEM'),
(2, 9, 'XEM'), (2, 9, 'THEM'),
(2, 10, 'XEM'), (2, 10, 'THEM'),
(2, 11, 'XEM'), (2, 11, 'THEM'),
(2, 13, 'XEM'), (2, 13, 'THEM'), (2, 13, 'SUA'),
(2, 14, 'XEM'), (2, 14, 'THEM'), (2, 14, 'SUA');

-- Độc giả
INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong) VALUES
(3, 1, 'XEM'),
(3, 2, 'XEM'),
(3, 3, 'XEM'),
(3, 6, 'XEM'),
(3, 7, 'XEM'),
(3, 9, 'XEM'), (3, 9, 'THEM');

-- 6. NGƯỜI DÙNG
INSERT INTO NGUOIDUNG (TenNguoiDung, NgaySinh, TenDangNhap, MatKhau, IDNhomNguoiDung) VALUES
('Admin Hệ Thống', '2000-01-01', 'admin', '123', 1),
('Thủ Thư Nguyễn Văn A', '1995-05-15', 'thuthu', '123', 2),
('Nguyễn Mai Anh', '2003-06-11', 'maianh', '123', 3),
('Lê Thành Đô', '2003-01-08', 'thanhdo', '123', 3);

-- 7. ĐỘC GIẢ
INSERT INTO DOCGIA (HoTen, NgaySinh, DiaChi, NgayLapThe, NgayHetHan, IDNguoiDung) VALUES
('Nguyễn Mai Anh', '2003-06-11', '123 Đường ABC, Quận 1', '2025-01-01', '2025-07-01', 3),
('Lê Thành Đô', '2003-01-08', '456 Đường XYZ, Quận 2', '2024-12-10', '2025-06-10', 4);

-- 8. DANH MỤC CƠ BẢN
INSERT INTO NHAXUATBAN (TenNXB, DiaChi) VALUES
('NXB Trẻ', 'HCM'),
('NXB Giáo dục', 'Hà Nội');

INSERT INTO NHACUNGCAP (TenNCC, DiaChi) VALUES
('Vinabook', 'HCM'),
('Fahasa', 'Hà Nội');

INSERT INTO THELOAI (TenTheLoai) VALUES
('Khoa học máy tính'),
('Tài liệu tham khảo'),
('Tiểu thuyết');

INSERT INTO TACGIA (TenTacGia, NamSinh) VALUES
('Nguyễn Văn Trí', 1984),
('Phạm Thị La', 1980),
('Ernest Hemingway', 1975);

INSERT INTO TUASACH (TenTuaSach) VALUES
('Cơ sở dữ liệu nâng cao'),
('Khai phá dữ liệu'),
('Ông Già Và Biển Cả');

-- 9. LIÊN KẾT THỂ LOẠI VÀ TÁC GIẢ
INSERT INTO CT_THELOAI VALUES 
(1, 1), (1, 2),
(2, 1), (2, 2),
(3, 3);

INSERT INTO CT_TACGIA VALUES 
(1, 1),
(2, 2),
(3, 3);

-- 10. SÁCH
INSERT INTO SACH (IDTuaSach, SoLuongTong, SoLuongConLai, DonGia, NamXB, IDNhaXuatBan) VALUES
(1, 0, 0, 80000, 2020, 1),
(2, 0, 0, 120000, 2023, 1),
(3, 0, 0, 65000, 2024, 2);

-- 11. PHIẾU NHẬP
INSERT INTO PHIEUNHAPSACH (IDNhaCungCap, NgayNhap) VALUES
(1, '2025-01-10'),
(2, '2025-01-15');

-- 12. CHI TIẾT PHIẾU NHẬP (Trigger sẽ cập nhật số lượng sách)
INSERT INTO CT_PHIEUNHAP (IDPhieuNhap, IDSach, SoLuongNhap, DonGiaNhap) VALUES
(1, 1, 10, 70000),  -- Nhập 10 cuốn sách 1
(1, 2, 5, 100000),  -- Nhập 5 cuốn sách 2
(2, 3, 15, 60000);  -- Nhập 15 cuốn sách 3

-- 13. CUỐN SÁCH
-- Sách 1: 10 cuốn (CS0001 - CS0010)
INSERT INTO CUONSACH (IDSach) VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1);
-- Sách 2: 5 cuốn (CS0011 - CS0015)
INSERT INTO CUONSACH (IDSach) VALUES (2), (2), (2), (2), (2);
-- Sách 3: 15 cuốn (CS0016 - CS0030)
INSERT INTO CUONSACH (IDSach) VALUES (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3);

-- 14. PHIẾU MƯỢN
-- Phiếu mượn 1: Độc giả 1, không trễ
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien, TrangThai) VALUES
(1, '2025-03-01', '2025-03-05', 1);

-- Chi tiết phiếu mượn 1: Mượn 2 cuốn
INSERT INTO CT_PHIEUMUON (IDPhieuMuon, IDCuonSach, TinhTrangMuon) VALUES
(1, 1, 'Mới'),
(1, 16, 'Mới');

-- Phiếu mượn 2: Độc giả 2, sẽ trễ
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien, TrangThai) VALUES
(2, '2025-03-10', '2025-03-14', 1);

-- Chi tiết phiếu mượn 2: Mượn 2 cuốn
INSERT INTO CT_PHIEUMUON (IDPhieuMuon, IDCuonSach, TinhTrangMuon) VALUES
(2, 2, 'Mới'),
(2, 17, 'Mới');

-- 15. PHIẾU TRẢ
-- Phiếu trả 1: Trả phiếu mượn 1 đúng hạn
INSERT INTO PHIEUTRA (IDPhieuMuon, NgayTra) VALUES
(1, '2025-03-05');

-- Chi tiết phiếu trả 1: Trả 2 cuốn, không phạt
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach, IDQuyDinhPhat, SoNgayTre, TinhTrangTra, TienPhat) VALUES
(1, 1, 1, 0, 'Mới', 0),  -- Quy định 1: Sách mới, không phạt
(1, 16, 1, 0, 'Mới', 0);

-- Phiếu trả 2: Trả phiếu mượn 2 trễ 2 ngày
INSERT INTO PHIEUTRA (IDPhieuMuon, NgayTra) VALUES
(2, '2025-03-16');  -- Trễ 2 ngày

-- Chi tiết phiếu trả 2: Trả 2 cuốn, phạt trễ hạn
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach, IDQuyDinhPhat, SoNgayTre, TinhTrangTra, TienPhat) VALUES
(2, 2, 1, 2, 'Mới', 2000),  -- Trễ 2 ngày x 1000 = 2000
(2, 17, 1, 2, 'Mới', 2000); -- Trễ 2 ngày x 1000 = 2000

-- 16. PHIẾU THU: Độc giả 2 trả 3000 tiền phạt
INSERT INTO PHIEUTHU (IDDocGia, SoTienThu, NgayLap) VALUES
(2, 3000, '2025-03-17');

-- 17. PHIẾU MƯỢN 3: Đang mượn (để test)
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien, TrangThai) VALUES
(1, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 4 DAY), 1);

INSERT INTO CT_PHIEUMUON (IDPhieuMuon, IDCuonSach, TinhTrangMuon) VALUES
(3, 3, 'Mới');

-- =========================================================================
-- 4. KIỂM TRA DỮ LIỆU
-- =========================================================================

SELECT '=== KIỂM TRA DỮ LIỆU ===' AS ThongTin;

SELECT '1. Thông số hệ thống:' AS Muc;
SELECT * FROM THAMSO;

SELECT '2. Quy định phạt:' AS Muc;
SELECT * FROM QUYDINHPHAT;

SELECT '3. Tổng số sách:' AS Muc, COUNT(*) AS SoLuong FROM SACH
UNION ALL
SELECT 'Tổng số cuốn sách:', COUNT(*) FROM CUONSACH
UNION ALL
SELECT 'Số sách đang mượn:', COUNT(*) FROM CUONSACH WHERE TinhTrang = 0;

SELECT '4. Thông tin độc giả và nợ:' AS Muc;
SELECT 
    dg.MaDocGia,
    dg.HoTen,
    dg.TongNoHienTai as NoHienTai,
    COUNT(pm.ID) as SoPhieuMuon
FROM DOCGIA dg
LEFT JOIN PHIEUMUON pm ON dg.ID = pm.IDDocGia
GROUP BY dg.ID, dg.MaDocGia, dg.HoTen, dg.TongNoHienTai;

SELECT '5. Tồn kho sách:' AS Muc;
SELECT 
    s.MaSach,
    ts.TenTuaSach,
    s.SoLuongTong,
    s.SoLuongConLai,
    s.SoLuongTong - s.SoLuongConLai as SoLuongDangMuon
FROM SACH s
JOIN TUASACH ts ON s.IDTuaSach = ts.ID;

SELECT '6. Phiếu mượn đang hoạt động:' AS Muc;
SELECT 
    pm.MaPhieuMuon,
    dg.HoTen as TenDocGia,
    pm.NgayMuon,
    pm.NgayTraDuKien,
    pm.TrangThai,
    COUNT(cpm.IDCuonSach) as SoSachDangMuon
FROM PHIEUMUON pm
JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
JOIN CT_PHIEUMUON cpm ON pm.ID = cpm.IDPhieuMuon
WHERE pm.TrangThai = 1
GROUP BY pm.ID, pm.MaPhieuMuon, dg.HoTen, pm.NgayMuon, pm.NgayTraDuKien, pm.TrangThai;

SELECT '7. Tổng tiền phạt các phiếu trả:' AS Muc;
SELECT 
    pt.MaPhieuTra,
    pm.MaPhieuMuon,
    dg.HoTen as TenDocGia,
    pt.NgayTra,
    pt.TongTienPhat
FROM PHIEUTRA pt
JOIN PHIEUMUON pm ON pt.IDPhieuMuon = pm.ID
JOIN DOCGIA dg ON pm.IDDocGia = dg.ID;