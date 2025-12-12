-- =========================================================================
-- KHỞI TẠO DATABASE QUẢN LÝ THƯ VIỆN (FULL DATA & LOGIC)
-- =========================================================================
DROP DATABASE IF EXISTS QLTV;
CREATE DATABASE QLTV CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE QLTV;

-- =========================================================================
-- I. CẤU TRÚC BẢNG (SCHEMA)
-- =========================================================================

-- 1. HỆ THỐNG PHÂN QUYỀN (ID CỐ ĐỊNH ĐỂ KHỚP CODE C#)
CREATE TABLE NHOMNGUOIDUNG (
    ID INT PRIMARY KEY,
    MaNhomNguoiDung CHAR(6),
    TenNhomNguoiDung VARCHAR(255) NOT NULL
);

CREATE TABLE CHUCNANG (
    ID INT PRIMARY KEY, -- ID 1-15 khớp code
    MaChucNang CHAR(10),
    TenChucNang VARCHAR(255) NOT NULL,
    TenManHinh VARCHAR(255) NOT NULL
);

CREATE TABLE PHANQUYEN (
    IDNhomNguoiDung INT,
    IDChucNang INT,
    HanhDong ENUM('THEM', 'SUA', 'XOA', 'XEM'),
    PRIMARY KEY (IDNhomNguoiDung, IDChucNang, HanhDong),
    FOREIGN KEY (IDNhomNguoiDung) REFERENCES NHOMNGUOIDUNG(ID) ON DELETE CASCADE,
    FOREIGN KEY (IDChucNang) REFERENCES CHUCNANG(ID) ON DELETE CASCADE
);

CREATE TABLE NGUOIDUNG (
    ID INT PRIMARY KEY, -- ID CỨNG
    MaNguoiDung CHAR(6),
    TenNguoiDung VARCHAR(255) NOT NULL,
    NgaySinh DATETIME,
    ChucVu VARCHAR(255),
    TenDangNhap VARCHAR(256) UNIQUE NOT NULL,
    MatKhau VARCHAR(255) NOT NULL,
    IDNhomNguoiDung INT NOT NULL,
    FOREIGN KEY (IDNhomNguoiDung) REFERENCES NHOMNGUOIDUNG(ID) ON DELETE CASCADE
);

-- 2. DANH MỤC
CREATE TABLE THELOAI (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaTheLoai CHAR(6),
    TenTheLoai VARCHAR(255) NOT NULL
);

CREATE TABLE TACGIA (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MATACGIA CHAR(6),
    TenTacGia VARCHAR(255) NOT NULL,
    NamSinh INT DEFAULT NULL
);

CREATE TABLE NHAXUATBAN (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    TenNXB VARCHAR(255) NOT NULL,
    DiaChi VARCHAR(255)
);

CREATE TABLE NHACUNGCAP (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    TenNCC VARCHAR(255) NOT NULL, 
    DiaChi VARCHAR(255)
);

-- 3. SÁCH (LOGIC MÃ SỐ & GIÁ)
CREATE TABLE TUASACH (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaTuaSach CHAR(6), -- User nhập (VD: CS01)
    TenTuaSach VARCHAR(255) NOT NULL,
    AnhBia MEDIUMBLOB,
    DaAn INT DEFAULT 0
);

CREATE TABLE CT_THELOAI (
    IDTuaSach INT, IDTheLoai INT, PRIMARY KEY (IDTuaSach, IDTheLoai),
    FOREIGN KEY (IDTuaSach) REFERENCES TUASACH(ID) ON DELETE CASCADE,
    FOREIGN KEY (IDTheLoai) REFERENCES THELOAI(ID) ON DELETE CASCADE
);
CREATE TABLE CT_TACGIA (
    IDTacGia INT, IDTuaSach INT, PRIMARY KEY (IDTacGia, IDTuaSach),
    FOREIGN KEY (IDTacGia) REFERENCES TACGIA(ID) ON DELETE CASCADE,
    FOREIGN KEY (IDTuaSach) REFERENCES TUASACH(ID) ON DELETE CASCADE
);

CREATE TABLE SACH (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaSach CHAR(12), -- Tự sinh: S + CS + 01 (SCS01)
    IDTuaSach INT NOT NULL,
    SoLuongTong INT NOT NULL DEFAULT 0,
    SoLuongConLai INT NOT NULL DEFAULT 0,
    DonGia DECIMAL(15,2) NOT NULL DEFAULT 0, -- Giá để tính phạt %
    NamXB INT NOT NULL,
    IDNhaXuatBan INT NOT NULL,
    DaAn INT NOT NULL DEFAULT 0,
    FOREIGN KEY (IDTuaSach) REFERENCES TUASACH(ID),
    FOREIGN KEY (IDNhaXuatBan) REFERENCES NHAXUATBAN(ID)
);

CREATE TABLE CUONSACH (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaCuonSach CHAR(18), -- Tự sinh: C + SCS01 + 001 (CSCS01001)
    IDSach INT NOT NULL,
    TrangThai INT NOT NULL DEFAULT 1, -- 1: Sẵn sàng, 0: Đang mượn, 2: Hỏng/Mất
    DaAn INT NOT NULL DEFAULT 0,
    FOREIGN KEY (IDSach) REFERENCES SACH(ID)
);

-- 4. QUY ĐỊNH PHẠT (CẤU TRÚC ĐỘNG + NHÓM)
CREATE TABLE THAMSO (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    TuoiToiThieu INT DEFAULT 18, TuoiToiDa INT DEFAULT 55, ThoiHanThe INT DEFAULT 6,
    KhoangCachXuatBan INT DEFAULT 8, SoSachMuonToiDa INT DEFAULT 5, SoNgayMuonToiDa INT DEFAULT 4,
    DonGiaPhatMoiNgay INT DEFAULT 1000
);

CREATE TABLE THAMSOPHAT (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaQuyDinh CHAR(6),
    TenTinhTrang VARCHAR(255) NOT NULL, 
    MucPhatPhanTram INT NOT NULL DEFAULT 0, -- Phạt theo % Giá sách
    GhiChu VARCHAR(255),
    
    -- Cờ cấu hình Logic
    CoLaDuyNhat BIT DEFAULT 0, -- 1: Độc quyền (Mới, Mất)
    CoLaMacDinh BIT DEFAULT 0, -- 1: Tự động gán (Mới)
    CoLaHuHong BIT DEFAULT 0,  -- 1: Loại khỏi lưu thông (Mất)
    
    -- Nhóm để loại trừ lẫn nhau (VD: Nhóm Rách)
    NhomTinhTrang VARCHAR(50) NULL 
);

CREATE TABLE CUONSACH_TINHTRANG (
    IDCuonSach INT,
    IDThamSoPhat INT,
    PRIMARY KEY (IDCuonSach, IDThamSoPhat),
    FOREIGN KEY (IDCuonSach) REFERENCES CUONSACH(ID) ON DELETE CASCADE,
    FOREIGN KEY (IDThamSoPhat) REFERENCES THAMSOPHAT(ID)
);

-- 5. NGHIỆP VỤ
CREATE TABLE DOCGIA (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaDocGia CHAR(6),
    HoTen VARCHAR(255) NOT NULL,
    NgaySinh DATETIME NOT NULL,
    DiaChi VARCHAR(255),
    NgayLapThe DATETIME NOT NULL,
    NgayHetHan DATETIME NOT NULL,
    TongNoHienTai DECIMAL(15,2) NOT NULL DEFAULT 0,
    IDNguoiDung INT UNIQUE,
    FOREIGN KEY (IDNguoiDung) REFERENCES NGUOIDUNG(ID) ON DELETE SET NULL
);

CREATE TABLE PHIEUNHAPSACH (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaPhieuNhap CHAR(8),
    IDNhaCungCap INT NOT NULL,
    NgayNhap Datetime NOT NULL,
    TongTien DECIMAL(15,2) NOT NULL DEFAULT 0,
    FOREIGN KEY (IDNhaCungCap) REFERENCES NHACUNGCAP(ID)
);

CREATE TABLE CT_PHIEUNHAP (
    IDPhieuNhap INT, IDSach INT,
    SoLuongNhap INT NOT NULL, DonGiaNhap DECIMAL(15,2) NOT NULL,
    ThanhTien DECIMAL(15,2) AS (SoLuongNhap * DonGiaNhap) STORED,
    PRIMARY KEY (IDPhieuNhap, IDSach),
    FOREIGN KEY (IDPhieuNhap) REFERENCES PHIEUNHAPSACH(ID),
    FOREIGN KEY (IDSach) REFERENCES SACH(ID) ON DELETE CASCADE
);

CREATE TABLE PHIEUMUON (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaPhieuMuon CHAR(8),
    IDDocGia INT NOT NULL,
    NgayMuon Datetime NOT NULL,
    NgayTraDuKien Datetime NOT NULL,
    TrangThai INT NOT NULL DEFAULT 1,
    TongPhat DECIMAL(15,2) DEFAULT 0,
    FOREIGN KEY (IDDocGia) REFERENCES DOCGIA(ID)
);

CREATE TABLE CT_PHIEUMUON (
    IDPhieuMuon INT, IDCuonSach INT,
    NgayTraThucTe DATETIME,
    PRIMARY KEY (IDPhieuMuon, IDCuonSach),
    FOREIGN KEY (IDPhieuMuon) REFERENCES PHIEUMUON(ID),
    FOREIGN KEY (IDCuonSach) REFERENCES CUONSACH(ID)
);

-- Snapshot tình trạng lúc mượn
CREATE TABLE CT_PHIEUMUON_TINHTRANG (
    IDPhieuMuon INT, IDCuonSach INT, IDThamSoPhat INT,
    PRIMARY KEY (IDPhieuMuon, IDCuonSach, IDThamSoPhat),
    FOREIGN KEY (IDPhieuMuon, IDCuonSach) REFERENCES CT_PHIEUMUON(IDPhieuMuon, IDCuonSach) ON DELETE CASCADE,
    FOREIGN KEY (IDThamSoPhat) REFERENCES THAMSOPHAT(ID)
);

CREATE TABLE PHIEUTRA (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaPhieuTra CHAR(8),
    IDPhieuMuon INT NOT NULL,
    NgayTra DATETIME NOT NULL,
    TongTienPhat DECIMAL(15,2) DEFAULT 0,
    FOREIGN KEY (IDPhieuMuon) REFERENCES PHIEUMUON(ID) ON DELETE CASCADE
);

CREATE TABLE CT_PHIEUTRA (
    IDPhieuTra INT, IDCuonSach INT,
    TienPhat DECIMAL(15,2) DEFAULT 0,
    PRIMARY KEY (IDPhieuTra, IDCuonSach),
    FOREIGN KEY (IDPhieuTra) REFERENCES PHIEUTRA(ID) ON DELETE CASCADE,
    FOREIGN KEY (IDCuonSach) REFERENCES CUONSACH(ID) ON DELETE CASCADE
);

-- Tình trạng lúc trả
CREATE TABLE CT_PHIEUTRA_TINHTRANG (
    IDPhieuTra INT, IDCuonSach INT, IDThamSoPhat INT,
    PRIMARY KEY (IDPhieuTra, IDCuonSach, IDThamSoPhat),
    FOREIGN KEY (IDPhieuTra, IDCuonSach) REFERENCES CT_PHIEUTRA(IDPhieuTra, IDCuonSach) ON DELETE CASCADE,
    FOREIGN KEY (IDThamSoPhat) REFERENCES THAMSOPHAT(ID)
);

CREATE TABLE PHIEUTHU (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    MaPhieuThu CHAR(8),
    IDDocGia INT NOT NULL,
    SoTienThu DECIMAL(15,2) NOT NULL DEFAULT 0,
    NgayLap DATETIME NOT NULL,
    FOREIGN KEY (IDDocGia) REFERENCES DOCGIA(ID)
);

-- =========================================================================
-- II. LOGIC TỰ ĐỘNG (TRIGGERS & PROCEDURES)
-- =========================================================================
DELIMITER //

-- 1. Sinh Mã Tự Động
CREATE TRIGGER bi_NHOMNGUOIDUNG BEFORE INSERT ON NHOMNGUOIDUNG FOR EACH ROW SET NEW.MaNhomNguoiDung = CONCAT('NND', LPAD(NEW.ID, 3, '0'));
CREATE TRIGGER bi_NGUOIDUNG BEFORE INSERT ON NGUOIDUNG FOR EACH ROW SET NEW.MaNguoiDung = CONCAT('ND', LPAD(NEW.ID, 4, '0'));
CREATE TRIGGER bi_DOCGIA BEFORE INSERT ON DOCGIA FOR EACH ROW SET NEW.MaDocGia = CONCAT('DG', LPAD((SELECT IFNULL(MAX(ID),0)+1 FROM DOCGIA), 4, '0'));
CREATE TRIGGER bi_PHIEUMUON BEFORE INSERT ON PHIEUMUON FOR EACH ROW SET NEW.MaPhieuMuon = CONCAT('PM', LPAD((SELECT IFNULL(MAX(ID),0)+1 FROM PHIEUMUON), 6, '0'));
CREATE TRIGGER bi_PHIEUTRA BEFORE INSERT ON PHIEUTRA FOR EACH ROW SET NEW.MaPhieuTra = CONCAT('PT', LPAD((SELECT IFNULL(MAX(ID),0)+1 FROM PHIEUTRA), 6, '0'));
CREATE TRIGGER bi_PHIEUTHU BEFORE INSERT ON PHIEUTHU FOR EACH ROW SET NEW.MaPhieuThu = CONCAT('PT', LPAD((SELECT IFNULL(MAX(ID),0)+1 FROM PHIEUTHU), 6, '0'));
CREATE TRIGGER bi_PHIEUNHAP BEFORE INSERT ON PHIEUNHAPSACH FOR EACH ROW SET NEW.MaPhieuNhap = CONCAT('P', LPAD((SELECT IFNULL(MAX(ID),0)+1 FROM PHIEUNHAPSACH), 6, '0'));
CREATE TRIGGER bi_THELOAI BEFORE INSERT ON THELOAI FOR EACH ROW BEGIN IF NEW.MaTheLoai IS NULL THEN SET NEW.MaTheLoai = CONCAT(UPPER(LEFT(REPLACE(NEW.TenTheLoai, ' ', ''), 2)), LPAD((SELECT IFNULL(MAX(ID),0)+1 FROM THELOAI), 2, '0')); END IF; END //
CREATE TRIGGER bi_TACGIA BEFORE INSERT ON TACGIA FOR EACH ROW SET NEW.MATACGIA = CONCAT('TG', LPAD((SELECT IFNULL(MAX(ID),0)+1 FROM TACGIA), 4, '0'));
CREATE TRIGGER bi_CHUCNANG BEFORE INSERT ON CHUCNANG FOR EACH ROW SET NEW.MaChucNang = CONCAT('C', LPAD(NEW.ID, 3, '0'));

CREATE TRIGGER before_insert_SACH BEFORE INSERT ON SACH FOR EACH ROW BEGIN
    DECLARE v_prefix VARCHAR(5);
    DECLARE v_ma_tua VARCHAR(10);
    SELECT MaTuaSach INTO v_ma_tua FROM TUASACH WHERE ID = NEW.IDTuaSach;
    SET v_prefix = CONCAT('S', LEFT(v_ma_tua, 2));
    SET NEW.MaSach = CONCAT(v_prefix, LPAD((SELECT IFNULL(COUNT(*),0)+1 FROM SACH WHERE MaSach LIKE CONCAT(v_prefix, '%')), 2, '0'));
END //

CREATE TRIGGER before_insert_CUONSACH BEFORE INSERT ON CUONSACH FOR EACH ROW BEGIN
    DECLARE v_ma_sach VARCHAR(12);
    DECLARE v_prefix VARCHAR(15);
    SELECT MaSach INTO v_ma_sach FROM SACH WHERE ID = NEW.IDSach;
    SET v_prefix = CONCAT('C', v_ma_sach);
    SET NEW.MaCuonSach = CONCAT(v_prefix, LPAD((SELECT IFNULL(COUNT(*),0)+1 FROM CUONSACH WHERE MaCuonSach LIKE CONCAT(v_prefix, '%')), 3, '0'));
END //

-- 2. Tự động set trạng thái 'MỚI' khi tạo cuốn sách
CREATE TRIGGER ai_CUONSACH AFTER INSERT ON CUONSACH FOR EACH ROW BEGIN
    DECLARE v_id_macdinh INT;
    SELECT ID INTO v_id_macdinh FROM THAMSOPHAT WHERE CoLaMacDinh = 1 LIMIT 1;
    IF v_id_macdinh IS NOT NULL THEN INSERT INTO CUONSACH_TINHTRANG(IDCuonSach, IDThamSoPhat) VALUES (NEW.ID, v_id_macdinh); END IF;
END //

-- 3. Procedure: Thêm Tình Trạng Thông Minh (Dọn dẹp trạng thái cũ)
CREATE PROCEDURE SP_ThemTinhTrang(IN p_IDCuonSach INT, IN p_IDThamSoPhat INT)
BEGIN
    DECLARE v_IsDuyNhat BIT;
    DECLARE v_IsHuHong BIT;
    DECLARE v_Nhom VARCHAR(50);
    
    SELECT CoLaDuyNhat, CoLaHuHong, NhomTinhTrang INTO v_IsDuyNhat, v_IsHuHong, v_Nhom FROM THAMSOPHAT WHERE ID = p_IDThamSoPhat;
    
    IF v_IsDuyNhat = 1 THEN DELETE FROM CUONSACH_TINHTRANG WHERE IDCuonSach = p_IDCuonSach;
    ELSE 
        -- Xóa Mới/Mất cũ
        IF EXISTS (SELECT 1 FROM CUONSACH_TINHTRANG ct JOIN THAMSOPHAT t ON ct.IDThamSoPhat = t.ID WHERE ct.IDCuonSach = p_IDCuonSach AND t.CoLaDuyNhat = 1) THEN 
            DELETE FROM CUONSACH_TINHTRANG WHERE IDCuonSach = p_IDCuonSach; 
        END IF;
        -- Xóa Cùng Nhóm
        IF v_Nhom IS NOT NULL AND v_Nhom != '' THEN
             DELETE FROM CUONSACH_TINHTRANG WHERE IDCuonSach = p_IDCuonSach AND IDThamSoPhat IN (SELECT ID FROM THAMSOPHAT WHERE NhomTinhTrang = v_Nhom);
        END IF;
    END IF;

    INSERT IGNORE INTO CUONSACH_TINHTRANG (IDCuonSach, IDThamSoPhat) VALUES (p_IDCuonSach, p_IDThamSoPhat);
    
    IF v_IsHuHong = 1 THEN UPDATE CUONSACH SET TrangThai = 2 WHERE ID = p_IDCuonSach;
    ELSE UPDATE CUONSACH SET TrangThai = 1 WHERE ID = p_IDCuonSach AND TrangThai != 0; END IF;
END //

-- 4. Procedure: Mượn Sách
CREATE PROCEDURE SP_ThemSachVaoPhieuMuon(IN p_IDPhieuMuon INT, IN p_IDCuonSach INT, IN p_DanhSachLoiMoi VARCHAR(255))
BEGIN
    DECLARE v_Pos INT DEFAULT 0;
    DECLARE v_Val VARCHAR(10);
    DECLARE v_TempList VARCHAR(255);
    DECLARE v_TrangThai INT;
    SELECT TrangThai INTO v_TrangThai FROM CUONSACH WHERE ID = p_IDCuonSach;
    IF v_TrangThai != 1 THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Lỗi: Sách đang bận.'; END IF;

    IF p_DanhSachLoiMoi IS NOT NULL AND p_DanhSachLoiMoi != '' THEN
        DELETE FROM CUONSACH_TINHTRANG WHERE IDCuonSach = p_IDCuonSach;
        SET v_TempList = p_DanhSachLoiMoi;
        WHILE LENGTH(v_TempList) > 0 DO
            SET v_Pos = LOCATE(',', v_TempList);
            IF v_Pos > 0 THEN SET v_Val = LEFT(v_TempList, v_Pos - 1); SET v_TempList = SUBSTRING(v_TempList, v_Pos + 1);
            ELSE SET v_Val = v_TempList; SET v_TempList = ''; END IF;
            -- Insert thủ công vì UI đã check logic rồi
            INSERT IGNORE INTO CUONSACH_TINHTRANG (IDCuonSach, IDThamSoPhat) VALUES (p_IDCuonSach, CAST(v_Val AS UNSIGNED));
        END WHILE;
    END IF;
    INSERT INTO CT_PHIEUMUON (IDPhieuMuon, IDCuonSach) VALUES (p_IDPhieuMuon, p_IDCuonSach);
END //

-- 5. Trigger Mượn
CREATE TRIGGER ai_CT_PHIEUMUON AFTER INSERT ON CT_PHIEUMUON FOR EACH ROW BEGIN
    UPDATE SACH SET SoLuongConLai = SoLuongConLai - 1 WHERE ID = (SELECT IDSach FROM CUONSACH WHERE ID = NEW.IDCuonSach);
    UPDATE CUONSACH SET TrangThai = 0 WHERE ID = NEW.IDCuonSach;
    INSERT INTO CT_PHIEUMUON_TINHTRANG (IDPhieuMuon, IDCuonSach, IDThamSoPhat)
    SELECT NEW.IDPhieuMuon, NEW.IDCuonSach, IDThamSoPhat FROM CUONSACH_TINHTRANG WHERE IDCuonSach = NEW.IDCuonSach;
END //

-- 6. Trigger Trả (Sync & Phạt)
CREATE TRIGGER ai_CT_PHIEUTRA_TINHTRANG AFTER INSERT ON CT_PHIEUTRA_TINHTRANG FOR EACH ROW BEGIN
    DECLARE v_PhanTramPhat INT;
    DECLARE v_GiaSach DECIMAL(15,2);
    DECLARE v_TienPhatCuThe DECIMAL(15,2);
    DECLARE v_IDPhieuMuon INT;
    DECLARE v_IsDuyNhat BIT; 
    DECLARE v_IsHuHong BIT;
    DECLARE v_Nhom VARCHAR(50);

    SELECT CoLaDuyNhat, CoLaHuHong, NhomTinhTrang, MucPhatPhanTram INTO v_IsDuyNhat, v_IsHuHong, v_Nhom, v_PhanTramPhat FROM THAMSOPHAT WHERE ID = NEW.IDThamSoPhat;
    
    -- Sync Sách
    IF v_IsDuyNhat = 1 THEN DELETE FROM CUONSACH_TINHTRANG WHERE IDCuonSach = NEW.IDCuonSach;
    ELSE 
        IF EXISTS (SELECT 1 FROM CUONSACH_TINHTRANG ct JOIN THAMSOPHAT t ON ct.IDThamSoPhat = t.ID WHERE ct.IDCuonSach = NEW.IDCuonSach AND t.CoLaDuyNhat = 1) THEN DELETE FROM CUONSACH_TINHTRANG WHERE IDCuonSach = NEW.IDCuonSach; END IF;
        IF v_Nhom IS NOT NULL AND v_Nhom != '' THEN DELETE FROM CUONSACH_TINHTRANG WHERE IDCuonSach = NEW.IDCuonSach AND IDThamSoPhat IN (SELECT ID FROM THAMSOPHAT WHERE NhomTinhTrang = v_Nhom); END IF;
    END IF;
    INSERT IGNORE INTO CUONSACH_TINHTRANG(IDCuonSach, IDThamSoPhat) VALUES (NEW.IDCuonSach, NEW.IDThamSoPhat);

    IF v_IsHuHong = 1 THEN UPDATE CUONSACH SET TrangThai=2 WHERE ID=NEW.IDCuonSach;
    ELSE UPDATE CUONSACH SET TrangThai=1 WHERE ID=NEW.IDCuonSach; END IF;

    -- Tính tiền
    SELECT IDPhieuMuon INTO v_IDPhieuMuon FROM PHIEUTRA WHERE ID = NEW.IDPhieuTra;
    IF NOT EXISTS (SELECT 1 FROM CT_PHIEUMUON_TINHTRANG WHERE IDPhieuMuon = v_IDPhieuMuon AND IDCuonSach = NEW.IDCuonSach AND IDThamSoPhat = NEW.IDThamSoPhat) THEN
        SELECT s.DonGia INTO v_GiaSach FROM SACH s JOIN CUONSACH cs ON s.ID = cs.IDSach WHERE cs.ID = NEW.IDCuonSach;
        SET v_TienPhatCuThe = (v_GiaSach * v_PhanTramPhat) / 100;
        
        IF v_TienPhatCuThe > 0 THEN
            UPDATE CT_PHIEUTRA SET TienPhat = TienPhat + v_TienPhatCuThe WHERE IDPhieuTra = NEW.IDPhieuTra AND IDCuonSach = NEW.IDCuonSach;
            UPDATE PHIEUTRA SET TongTienPhat = TongTienPhat + v_TienPhatCuThe WHERE ID = NEW.IDPhieuTra;
            UPDATE PHIEUMUON SET TongPhat = TongPhat + v_TienPhatCuThe WHERE ID = v_IDPhieuMuon;
            UPDATE DOCGIA SET TongNoHienTai = TongNoHienTai + v_TienPhatCuThe WHERE ID = (SELECT IDDocGia FROM PHIEUMUON WHERE ID = v_IDPhieuMuon);
        END IF;
    END IF;
END //

CREATE TRIGGER ai_CT_PHIEUTRA AFTER INSERT ON CT_PHIEUTRA FOR EACH ROW BEGIN
    UPDATE SACH SET SoLuongConLai = SoLuongConLai + 1 WHERE ID = (SELECT IDSach FROM CUONSACH WHERE ID = NEW.IDCuonSach);
    UPDATE CT_PHIEUMUON SET NgayTraThucTe = NOW() WHERE IDPhieuMuon = (SELECT IDPhieuMuon FROM PHIEUTRA WHERE ID = NEW.IDPhieuTra) AND IDCuonSach = NEW.IDCuonSach;
END //

CREATE TRIGGER ai_CT_PHIEUNHAP AFTER INSERT ON CT_PHIEUNHAP FOR EACH ROW BEGIN
	UPDATE PHIEUNHAPSACH SET TongTien = TongTien + NEW.ThanhTien WHERE ID = NEW.IDPhieuNhap;
	UPDATE SACH SET SoLuongTong = SoLuongTong + NEW.SoLuongNhap, SoLuongConLai = SoLuongConLai + NEW.SoLuongNhap WHERE ID = NEW.IDSach;
END //
DELIMITER ;

-- =========================================================================
-- III. DỮ LIỆU MẪU (BƠM DỮ LIỆU GIAO DỊCH LỚN)
-- =========================================================================

-- 1. QUY ĐỊNH PHẠT (CÓ NHÓM)
INSERT INTO THAMSO (TuoiToiThieu, TuoiToiDa, DonGiaPhatMoiNgay) VALUES (18, 55, 1000);
INSERT INTO THAMSOPHAT (MaQuyDinh, TenTinhTrang, MucPhatPhanTram, CoLaDuyNhat, CoLaMacDinh, CoLaHuHong, NhomTinhTrang) VALUES 
('QD01', 'Mới nguyên', 0, 1, 1, 0, NULL), -- ID 1
('QD02', 'Bẩn nhẹ', 5, 0, 0, 0, 'BAN'),    -- ID 2
('QD03', 'Ướt nhẹ', 5, 0, 0, 0, 'UOT'),    -- ID 3
('QD04', 'Rách dưới 3 trang', 10, 0, 0, 0, 'RACH'), -- ID 4 (Nhóm Rách)
('QD05', 'Rách dưới 5 trang', 20, 0, 0, 0, 'RACH'), -- ID 5
('QD06', 'Rách trên 5 trang', 40, 0, 0, 0, 'RACH'), -- ID 6
('QD07', 'Mất sách', 100, 1, 0, 1, NULL); -- ID 7

-- 2. NHÓM NGƯỜI DÙNG & CHỨC NĂNG (FULL)
INSERT INTO NHOMNGUOIDUNG (ID, MaNhomNguoiDung, TenNhomNguoiDung) VALUES 
(1, 'NND001', 'Quản Lý'), (2, 'NND002', 'Thủ Thư'), (3, 'NND003', 'Độc Giả');

INSERT INTO CHUCNANG (ID, MaChucNang, TenChucNang, TenManHinh) VALUES 
(1, 'DASH', 'Dashboard', 'Tổng quan'), (2, 'GENR', 'Thể loại', 'Thể loại'), (3, 'AUTH', 'Tác giả', 'Tác giả'),
(4, 'PUBL', 'Nhà xuất bản', 'NXB'), (5, 'SUPP', 'Nhà cung cấp', 'NCC'), (6, 'TITL', 'Tựa sách', 'Tựa sách'),
(7, 'BOOK', 'Sách', 'Kho sách'), (8, 'IMPO', 'Nhập sách', 'Phiếu nhập'), (9, 'BORR', 'Mượn sách', 'Phiếu mượn'),
(10, 'RETU', 'Trả sách', 'Phiếu trả'), (11, 'PAYM', 'Phiếu thu', 'Phiếu thu'), (12, 'REPO', 'Báo cáo', 'Báo cáo'),
(13, 'USER', 'Người dùng', 'Người dùng'), (14, 'READ', 'Độc giả', 'Độc giả'), (15, 'PERM', 'Phân quyền', 'Phân quyền');

INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong) SELECT 1, ID, 'XEM' FROM CHUCNANG;
INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong) SELECT 1, ID, 'THEM' FROM CHUCNANG;
INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong) SELECT 1, ID, 'SUA' FROM CHUCNANG;
INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong) SELECT 1, ID, 'XOA' FROM CHUCNANG;

-- 3. NGƯỜI DÙNG & ĐỘC GIẢ
INSERT INTO NGUOIDUNG (ID, TenNguoiDung, NgaySinh, TenDangNhap, MatKhau, IDNhomNguoiDung) VALUES 
(1, 'Admin Hệ Thống', '2000-01-01', 'admin', '123', 1),
(2, 'Thủ Thư A', '2000-01-01', 'lib', '123', 2),
(3, 'Nguyễn Mai Anh', '2003-06-11', 'docgia1', '123', 3), 
(4, 'Lê Thành Đô', '2003-01-08', 'docgia2', '123', 3),    
(5, 'Huỳnh Hồng Thu Giang', '2003-02-24', 'docgia3', '123', 3), 
(6, 'Trần Nhật Huy', '2003-01-03', 'docgia4', '123', 3); 

INSERT INTO DOCGIA (HoTen, NgaySinh, NgayLapThe, NgayHetHan, IDNguoiDung, TongNoHienTai) VALUES 
('Nguyễn Mai Anh', '2003-06-11', '2025-01-01', '2025-07-01', 3, 0), -- ID 1
('Lê Thành Đô', '2003-01-08', '2024-12-10', '2025-06-10', 4, 5000), -- ID 2
('Huỳnh Hồng Thu Giang', '2003-02-24', '2025-02-05', '2025-08-05', 5, 0), -- ID 3
('Trần Nhật Huy', '2003-01-03', '2025-03-15', '2025-09-15', 6, 0); -- ID 4

-- 4. DỮ LIỆU SÁCH (GỐC + MỞ RỘNG)
INSERT INTO THELOAI (MaTheLoai, TenTheLoai) VALUES ('KH01', 'Khoa học máy tính'), ('TL01', 'Tài liệu tham khảo'), ('TT01', 'Tiểu thuyết'), ('KT01', 'Kinh tế');
INSERT INTO TACGIA (TenTacGia, NamSinh) VALUES ('Nguyễn Văn Trí', 1984), ('Phạm Thị La', 1980), ('Ernest Hemingway', 1975), ('Robert C. Martin', 1960), ('Erich Gamma', 1961);
INSERT INTO NHACUNGCAP (TenNCC) VALUES ('Vinabook'), ('Fahasa');
INSERT INTO NHAXUATBAN (TenNXB) VALUES ('NXB Trẻ'), ('NXB Giáo dục');

-- Tựa Sách
INSERT INTO TUASACH (MaTuaSach, TenTuaSach) VALUES 
('CS01', 'Cơ sở dữ liệu nâng cao'), -- ID 1
('KP01', 'Khai phá dữ liệu (Data Mining)'), -- ID 2
('OG01', 'Ông Già Và Biển Cả'), -- ID 3
('CC01', 'Clean Code'), -- ID 4
('DP01', 'Design Patterns'); -- ID 5

INSERT INTO CT_THELOAI VALUES (1, 1), (2, 1), (3, 3), (4, 1), (5, 1);
INSERT INTO CT_TACGIA VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5);

-- Lô Sách
INSERT INTO SACH (IDTuaSach, DonGia, NamXB, IDNhaXuatBan) VALUES 
(1, 80000, 2020, 1),  -- CSDL (ID 1)
(2, 120000, 2023, 1), -- KP (ID 2)
(3, 65000, 2024, 2),  -- OG (ID 3)
(4, 300000, 2018, 1), -- Clean Code (ID 4)
(5, 250000, 2019, 1); -- Design Patterns (ID 5)

-- Nhập kho
INSERT INTO PHIEUNHAPSACH (IDNhaCungCap, NgayNhap) VALUES (1, '2025-01-10');
INSERT INTO CT_PHIEUNHAP (IDPhieuNhap, IDSach, SoLuongNhap, DonGiaNhap) VALUES 
(1, 1, 10, 70000), 
(1, 2, 5, 100000), 
(1, 3, 15, 60000),
(1, 4, 10, 250000),
(1, 5, 10, 200000);

-- Tạo cuốn sách vật lý (Trigger tự gán MOI)
INSERT INTO CUONSACH (IDSach) VALUES (1),(1),(1),(1),(1),(1),(1),(1),(1),(1); -- 1-10
INSERT INTO CUONSACH (IDSach) VALUES (2),(2),(2),(2),(2); -- 11-15
INSERT INTO CUONSACH (IDSach) VALUES (3),(3),(3),(3),(3),(3),(3),(3),(3),(3),(3),(3),(3),(3),(3); -- 16-30
INSERT INTO CUONSACH (IDSach) VALUES (4),(4),(4),(4),(4),(4),(4),(4),(4),(4); -- 31-40
INSERT INTO CUONSACH (IDSach) VALUES (5),(5),(5),(5),(5),(5),(5),(5),(5),(5); -- 41-50

-- Cập nhật tình trạng xấu ban đầu (Để test mượn sách không mới)
CALL SP_ThemTinhTrang(1, 2);  -- Cuốn 1 Bẩn
CALL SP_ThemTinhTrang(11, 4); -- Cuốn 11 Rách < 3
CALL SP_ThemTinhTrang(16, 7); -- Cuốn 16 Mất (Loại khỏi kho)

-- 5. MASSIVE TRANSACTION DATA (DỮ LIỆU LỊCH SỬ)

-- Tháng 1: Mượn trả tốt
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien) VALUES (1, '2025-01-05', '2025-01-10'); -- PM1
SET @PM = LAST_INSERT_ID();
CALL SP_ThemSachVaoPhieuMuon(@PM, 2, NULL);
CALL SP_ThemSachVaoPhieuMuon(@PM, 31, NULL);
INSERT INTO PHIEUTRA (IDPhieuMuon, NgayTra) VALUES (@PM, '2025-01-09');
SET @PT = LAST_INSERT_ID();
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 2);
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 31);
INSERT INTO CT_PHIEUTRA_TINHTRANG VALUES (@PT, 2, 1), (@PT, 31, 1);

-- Tháng 1: Mượn trả tốt
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien) VALUES (2, '2025-01-10', '2025-01-15'); -- PM2
SET @PM = LAST_INSERT_ID();
CALL SP_ThemSachVaoPhieuMuon(@PM, 41, NULL);
INSERT INTO PHIEUTRA (IDPhieuMuon, NgayTra) VALUES (@PM, '2025-01-14');
SET @PT = LAST_INSERT_ID();
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 41);
INSERT INTO CT_PHIEUTRA_TINHTRANG VALUES (@PT, 41, 1);

-- Tháng 2: Bắt đầu có phạt (Rách)
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien) VALUES (3, '2025-02-05', '2025-02-10'); -- PM3
SET @PM = LAST_INSERT_ID();
CALL SP_ThemSachVaoPhieuMuon(@PM, 12, NULL); -- KP (Mới)
INSERT INTO PHIEUTRA (IDPhieuMuon, NgayTra) VALUES (@PM, '2025-02-12'); -- Trễ 2 ngày (2000đ)
SET @PT = LAST_INSERT_ID();
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 12);
INSERT INTO CT_PHIEUTRA_TINHTRANG VALUES (@PT, 12, 4); -- Bị Rách < 3 (Phạt 10% = 12k) -> Tổng 14k

-- Tháng 2: Mượn nhiều, Trả lắt nhắt
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien) VALUES (4, '2025-02-15', '2025-02-20'); -- PM4
SET @PM = LAST_INSERT_ID();
CALL SP_ThemSachVaoPhieuMuon(@PM, 3, NULL);
CALL SP_ThemSachVaoPhieuMuon(@PM, 4, NULL);
CALL SP_ThemSachVaoPhieuMuon(@PM, 5, NULL);
-- Trả cuốn 3 (Sớm)
INSERT INTO PHIEUTRA (IDPhieuMuon, NgayTra) VALUES (@PM, '2025-02-18');
SET @PT = LAST_INSERT_ID();
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 3);
INSERT INTO CT_PHIEUTRA_TINHTRANG VALUES (@PT, 3, 1);
-- Trả cuốn 4, 5 (Trễ)
INSERT INTO PHIEUTRA (IDPhieuMuon, NgayTra) VALUES (@PM, '2025-02-22');
SET @PT = LAST_INSERT_ID();
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 4);
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 5);
INSERT INTO CT_PHIEUTRA_TINHTRANG VALUES (@PT, 4, 1), (@PT, 5, 2); -- 5 bị bẩn

-- Tháng 3: Mượn sách Bẩn -> Trả Bẩn (Ko phạt)
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien) VALUES (1, '2025-03-01', '2025-03-05'); -- PM5
SET @PM = LAST_INSERT_ID();
CALL SP_ThemSachVaoPhieuMuon(@PM, 1, NULL); -- Mượn sách Bẩn (ID 1)
CALL SP_ThemSachVaoPhieuMuon(@PM, 32, NULL); 
INSERT INTO PHIEUTRA (IDPhieuMuon, NgayTra) VALUES (@PM, '2025-03-05');
SET @PT = LAST_INSERT_ID();
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 1);
INSERT INTO CT_PHIEUTRA_TINHTRANG VALUES (@PT, 1, 2); -- Trả Bẩn (Ko phạt)
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 32);
INSERT INTO CT_PHIEUTRA_TINHTRANG VALUES (@PT, 32, 1);

-- Tháng 3: Mất sách
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien) VALUES (2, '2025-03-10', '2025-03-15'); -- PM6
SET @PM = LAST_INSERT_ID();
CALL SP_ThemSachVaoPhieuMuon(@PM, 42, NULL);
INSERT INTO PHIEUTRA (IDPhieuMuon, NgayTra) VALUES (@PM, '2025-03-15');
SET @PT = LAST_INSERT_ID();
INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach) VALUES (@PT, 42);
INSERT INTO CT_PHIEUTRA_TINHTRANG VALUES (@PT, 42, 7); -- Mất (Phạt 100%)

-- HIỆN TẠI: Đang mượn (Chưa trả)
-- DG3 mượn Clean Code & Design Patterns
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien) VALUES (3, NOW(), DATE_ADD(NOW(), INTERVAL 5 DAY));
SET @PM = LAST_INSERT_ID();
CALL SP_ThemSachVaoPhieuMuon(@PM, 33, NULL);
CALL SP_ThemSachVaoPhieuMuon(@PM, 43, NULL);

-- DG4 mượn Ông Già (Quá hạn 10 ngày)
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien) VALUES (4, DATE_SUB(NOW(), INTERVAL 15 DAY), DATE_SUB(NOW(), INTERVAL 10 DAY));
SET @PM = LAST_INSERT_ID();
CALL SP_ThemSachVaoPhieuMuon(@PM, 18, NULL);
CALL SP_ThemSachVaoPhieuMuon(@PM, 19, NULL);

-- DG1 mượn CSDL (Quá hạn 3 ngày)
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien) VALUES (1, DATE_SUB(NOW(), INTERVAL 8 DAY), DATE_SUB(NOW(), INTERVAL 3 DAY));
SET @PM = LAST_INSERT_ID();
CALL SP_ThemSachVaoPhieuMuon(@PM, 6, NULL);
