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

-- Bảng THELOAI
CREATE TABLE THELOAI
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaTheLoai CHAR(6),
	TenTheLoai VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL
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
	TenTacGia VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL
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

-- Bảng SACH (Lô sách)
CREATE TABLE SACH
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaSach CHAR(6),
	IDTuaSach INT NOT NULL,
	SoLuongTong INT NOT NULL,
	SoLuongConLai INT NOT NULL,
	DonGia INT,
	NamXB INT NOT NULL,
	IDNhaXuatBan INT NOT NULL,
	DaAn INT NOT NULL DEFAULT 0,
	FOREIGN KEY (IDTuaSach) REFERENCES TUASACH(ID)
);

-- Bảng CUONSACH (Cuốn sách vật lý)
CREATE TABLE CUONSACH
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
	MaCuonSach CHAR(6),
	IDSach INT NOT NULL,
	TinhTrang INT NOT NULL DEFAULT 1, -- (0: Đang mượn, 1: Sẵn sàng, 2: Không khả dụng, bị ẩn)
	DaAn INT NOT NULL DEFAULT 0,
	FOREIGN KEY (IDSach) REFERENCES SACH(ID)
);

-- Bảng NHAXUATBAN (Nhà xuất bản sách)
CREATE TABLE NHAXUATBAN
(
	ID INT AUTO_INCREMENT PRIMARY KEY,
    TenNXB VARCHAR(255) CHARACTER SET UTF8MB4 NOT NULL,
	DiaChi VARCHAR(255) CHARACTER SET UTF8MB4
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
	TongPhat INT DEFAULT 0,
	FOREIGN KEY (IDDocGia) REFERENCES DOCGIA(ID)
);

-- Bảng CT_PHIEUMUON (Chi tiết cuốn sách mượn/trả)
CREATE TABLE CT_PHIEUMUON
(
	IDPhieuMuon INT,
	IDCuonSach INT,
	NgayTraThucTe DATETIME,
	SoNgayTre INT DEFAULT 0,
	TienPhat INT DEFAULT 0,
	PRIMARY KEY (IDPhieuMuon, IDCuonSach),
	FOREIGN KEY (IDPhieuMuon) REFERENCES PHIEUMUON(ID) ON DELETE CASCADE,
	FOREIGN KEY (IDCuonSach) REFERENCES CUONSACH(ID) ON DELETE CASCADE
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

-- =========================================================================
-- 2. ĐỊNH NGHĨA TRIGGERS (Tự động tạo mã và Cập nhật Tồn kho/Trạng thái)
-- =========================================================================

DELIMITER //

-- Triggers tạo mã nghiệp vụ (Ma...)
CREATE TRIGGER before_insert_NHOMNGUOIDUNG BEFORE INSERT ON NHOMNGUOIDUNG
FOR EACH ROW BEGIN
	SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM NHOMNGUOIDUNG);
	SET NEW.MaNhomNguoiDung = CONCAT('NND', LPAD(@next_ID, 3, '0'));
END //

CREATE TRIGGER before_insert_CHUCNANG BEFORE INSERT ON CHUCNANG
FOR EACH ROW BEGIN
	SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM CHUCNANG);
	SET NEW.MaChucNang = CONCAT('C', LPAD(@next_ID, 3, '0'));
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
	SET NEW.MaSach = CONCAT('S', LPAD(@next_ID, 5, '0'));
END //

CREATE TRIGGER before_insert_CUONSACH BEFORE INSERT ON CUONSACH
FOR EACH ROW BEGIN
	SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM CUONSACH);
	SET NEW.MaCuonSach = CONCAT('CS', LPAD(@next_ID, 4, '0'));
END //

CREATE TRIGGER before_insert_PHIEUMUON BEFORE INSERT ON PHIEUMUON
FOR EACH ROW BEGIN
	SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM PHIEUMUON);
	SET NEW.MaPhieuMuon = CONCAT('PM', LPAD(@next_ID, 6, '0'));
END //

CREATE TRIGGER before_insert_PHIEUTHU BEFORE INSERT ON PHIEUTHU
FOR EACH ROW BEGIN
	SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM PHIEUTHU);
	SET NEW.MaPhieuThu = CONCAT('PT', LPAD(@next_ID, 6, '0'));
END //

CREATE TRIGGER before_insert_PHIEUNHAPSACH BEFORE INSERT ON PHIEUNHAPSACH
FOR EACH ROW BEGIN
	SET @next_ID = (SELECT IFNULL(MAX(ID), 0) + 1 FROM PHIEUNHAPSACH);
	SET NEW.MaPhieuNhap = CONCAT('P', LPAD(@next_ID, 6, '0'));
END //

-- Triggers xử lý nghiệp vụ Mượn, Trả, Nhập

-- TRIGGER khi MƯỢN SÁCH (INSERT vào CT_PHIEUMUON)
CREATE TRIGGER after_insert_CT_PHIEUMUON
AFTER INSERT ON CT_PHIEUMUON
FOR EACH ROW
BEGIN
	-- 1. Giảm SoLuongConLai của Lô sách (SACH)
	UPDATE SACH
	SET SoLuongConLai = SoLuongConLai - 1
	WHERE ID = (SELECT IDSach FROM CUONSACH WHERE ID = NEW.IDCuonSach);

	-- 2. Đặt TinhTrang của Cuốn sách về 'Đang mượn' (0)
	UPDATE CUONSACH
	SET TinhTrang = 0
	WHERE ID = NEW.IDCuonSach;
END //

-- TRIGGER khi TRẢ SÁCH (UPDATE NgayTraThucTe trên CT_PHIEUMUON)
CREATE TRIGGER after_update_CT_PHIEUMUON
AFTER UPDATE ON CT_PHIEUMUON
FOR EACH ROW
BEGIN
	DECLARE v_ID_sach INT;
	DECLARE v_ID_docgia INT;

	-- Chỉ xử lý khi NgayTraThucTe được cập nhật từ NULL sang giá trị thực
	IF NEW.NgayTraThucTe IS NOT NULL AND OLD.NgayTraThucTe IS NULL THEN

		-- 1. Tăng SoLuongConLai của Lô sách (SACH)
		SELECT IDSach INTO v_ID_sach FROM CUONSACH WHERE ID = NEW.IDCuonSach;
		UPDATE SACH
		SET SoLuongConLai = SoLuongConLai + 1
		WHERE ID = v_ID_sach;

		-- 2. Đặt TinhTrang của Cuốn sách về 'Sẵn sàng' (1)
		UPDATE CUONSACH
		SET TinhTrang = 1
		WHERE ID = NEW.IDCuonSach;

		-- 3. Cập nhật Tổng nợ (TongNoHienTai) của Độc giả
		IF NEW.TienPhat > 0 THEN
			 SELECT IDDocGia INTO v_ID_docgia FROM PHIEUMUON WHERE ID = NEW.IDPhieuMuon;
			 UPDATE DOCGIA
			 SET TongNoHienTai = TongNoHienTai + NEW.TienPhat
			 WHERE ID = v_ID_docgia;
		END IF;

	END IF;
END //


-- TRIGGER khi INSERT PHIEUTHU (Giảm nợ độc giả)
CREATE TRIGGER after_insert_PHIEUTHU
AFTER INSERT ON PHIEUTHU
FOR EACH ROW
BEGIN
	UPDATE DOCGIA
	SET TongNoHienTai = TongNoHienTai - NEW.SoTienThu
	WHERE ID = NEW.IDDocGia;
END //

-- TRIGGER khi NHẬP SÁCH (INSERT vào CT_PHIEUNHAP)
CREATE TRIGGER after_insert_CT_PHIEUNHAP
AFTER INSERT ON CT_PHIEUNHAP
FOR EACH ROW
BEGIN
	-- 1. Cập nhật TongTien của Phiếu nhập
	UPDATE PHIEUNHAPSACH
	SET TongTien = TongTien + NEW.ThanhTien
	WHERE ID = NEW.IDPhieuNhap;

	-- 2. Cập nhật SoLuongTong và SoLuongConLai của Lô sách (SACH)
	UPDATE SACH
	SET SoLuongTong = SoLuongTong + NEW.SoLuongNhap,
		SoLuongConLai = SoLuongConLai + NEW.SoLuongNhap
	WHERE ID = NEW.IDSach;
END //


-- Khôi phục DELIMITER
DELIMITER ;

-- =========================================================================
-- 3: CHÈN DỮ LIỆU MẪU (INSERT INTO ... VALUES)
-- =========================================================================

-- 1. THAM SỐ (THAMSO)
INSERT INTO THAMSO (TuoiToiThieu, TuoiToiDa, ThoiHanThe, KhoangCachXuatBan, SoSachMuonToiDa, SoNgayMuonToiDa, DonGiaPhatMoiNgay)
VALUES(18, 55, 6, 8, 5, 4, 1000);


-- 2. DỮ LIỆU CƠ BẢN: NHÓM NGƯỜI DÙNG & CHỨC NĂNG
-- Triggers sẽ tự động sinh MaNhomNguoiDung và MaChucNang
INSERT INTO NHOMNGUOIDUNG (TenNhomNguoiDung)
VALUES ('Quản Lý'), ('Thủ Thư'), ('Độc Giả');

INSERT INTO CHUCNANG (TenChucNang, TenManHinh)
VALUES ('TQUAN', 'Tổng quan/Báo cáo nhanh'),	-- ID = 1
       ('TL', 'Thể loại'),                     	-- ID = 2
       ('TG', 'Tác giả'),                      	-- ID = 3
       ('NCC', 'Nhà cung cấp'),                	-- ID = 4
       ('TS', 'Tựa sách'),                     	-- ID = 5
       ('SACH', 'Lô sách & Cuốn sách'),        	-- ID = 6
       ('PN', 'Phiếu nhập sách'),        		-- ID = 7
       ('PM', 'Phiếu mượn/Trả sách'),          	-- ID = 8
       ('PT', 'Phiếu thu'),                    	-- ID = 9
       ('BCQH', 'Báo cáo quá hạn/phạt'),       	-- ID = 10
       ('ND', 'Người dùng (Tài khoản)'),      	-- ID = 11
       ('DG', 'Độc giả'),        				-- ID = 12
       ('PQ', 'Phân quyền'),                   	-- ID = 13
       ('GDG', 'Giao diện độc giả');			-- ID = 14


-- 3. PHÂN QUYỀN (PHANQUYEN)
-- Gán quyền cho Admin (ID=1) - Toàn quyền trên mọi module (1-13)
INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong)
SELECT IDNhom, IDChucNang, HanhDong FROM (
    SELECT 1 AS IDNhom, ID AS IDChucNang, 'THEM' AS HanhDong FROM CHUCNANG
    UNION ALL SELECT 1, ID, 'SUA' FROM CHUCNANG
    UNION ALL SELECT 1, ID, 'XOA' FROM CHUCNANG
    UNION ALL SELECT 1, ID, 'XEM' FROM CHUCNANG
) AS T;

-- Gán quyền cho Thủ thư (ID=2)
INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong)
VALUES
-- Module Độc giả, Danh mục (2, 3, 4, 5, 6, 12): Thêm, Sửa, Xem
(2, 2, 'THEM'), (2, 2, 'SUA'), (2, 2, 'XEM'), -- Thể loại
(2, 3, 'THEM'), (2, 3, 'SUA'), (2, 3, 'XEM'), -- Tác giả
(2, 4, 'THEM'), (2, 4, 'SUA'), (2, 4, 'XEM'), -- NCC
(2, 5, 'THEM'), (2, 5, 'SUA'), (2, 5, 'XEM'), -- Tựa sách
(2, 6, 'THEM'), (2, 6, 'SUA'), (2, 6, 'XEM'), -- Lô sách/CS
(2, 12, 'THEM'), (2, 12, 'SUA'), (2, 12, 'XEM'), -- Hồ sơ Độc giả

-- Module Phiếu Nhập (7): Nhập sách (THEM)
(2, 7, 'THEM'), (2, 7, 'XEM'),

-- Module Phiếu Mượn/Trả (8): Mượn (THEM), Trả (SUA)
(2, 8, 'THEM'), (2, 8, 'SUA'), (2, 8, 'XEM'),

-- Module Phiếu Thu (9): Lập phiếu thu (THEM)
(2, 9, 'THEM'), (2, 9, 'XEM'),

-- Module Báo cáo (1, 10): Xem
(2, 1, 'XEM'),
(2, 10, 'XEM');


-- Gán quyền cho Độc giả (ID=3) - Quyền xem thông tin cá nhân/lịch sử
INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong)
VALUES
(3, 14, 'XEM');   -- Xem giao diện của độc giả

-- 4. NGƯỜI DÙNG (NGUOIDUNG) & ĐỘC GIẢ (DOCGIA)
-- Tài khoản hệ thống
INSERT INTO NGUOIDUNG(TenNguoiDung, NgaySinh, TenDangNhap, MatKhau, IDNhomNguoiDung)
VALUES ('Admin Hệ Thống', '2000-01-01 00:00:00', 'admin', '123', 1), -- ID = 1
       ('Thủ Thư Nguyễn Văn A', '2000-01-01 00:00:00', 'lib', '123', 2); -- ID = 2

-- Tài khoản Độc giả (ID = 3 đến 6)
INSERT INTO NGUOIDUNG(TenNguoiDung, NgaySinh, TenDangNhap, MatKhau, IDNhomNguoiDung)
VALUES ('Nguyễn Mai Anh', '2003-06-11 00:00:00', 'docgia1', '123', 3), -- ID = 3
       ('Lê Thành Đô', '2003-01-08 00:00:00', 'docgia2', '123', 3), -- ID = 4
       ('Huỳnh Hồng Thu Giang', '2003-02-24 00:00:00', 'docgia3', '123', 3), -- ID = 5
       ('Trần Nhật Huy', '2003-01-03 00:00:00', 'docgia4', '123', 3); -- ID = 6

-- Hồ sơ Độc giả (DOCGIA)
INSERT INTO DOCGIA (HoTen, NgaySinh, NgayLapThe, NgayHetHan, IDNguoiDung, TongNoHienTai)
VALUES ('Nguyễn Mai Anh', '2003-06-11 00:00:00', '2025-01-01 00:00:00', '2025-07-01 00:00:00', 3, 0), -- ID = 1
       ('Lê Thành Đô', '2003-01-08 00:00:00', '2024-12-10 00:00:00', '2025-06-10 00:00:00', 4, 5000), -- ID = 2, Đang nợ 5000
       ('Huỳnh Hồng Thu Giang', '2003-02-24 00:00:00', '2025-02-05 00:00:00', '2025-08-05 00:00:00', 5, 0), -- ID = 3
       ('Trần Nhật Huy', '2003-01-03 00:00:00', '2025-03-15 00:00:00', '2025-09-15 00:00:00', 6, 0); -- ID = 4


-- 5. DANH MỤC: THỂ LOẠI, TÁC GIẢ, TỰA SÁCH
INSERT INTO THELOAI (TenTheLoai)
VALUES ('Khoa học máy tính'), ('Tài liệu tham khảo'), ('Tiểu thuyết'), ('Kinh tế học'), ('Văn học thiếu nhi');

INSERT INTO TACGIA (TenTacGia)
VALUES ('Nguyễn Văn Trí'), ('Phạm Thị La'), ('Ernest Hemingway'), ('Hector Malot');

-- Cột AnhBia (MEDIUMBLOB) để NULL
INSERT INTO TUASACH (TenTuaSach)
VALUES ('Cơ sở dữ liệu nâng cao'), ('Khai phá dữ liệu (Data Mining)'), ('Ông Già Và Biển Cả'), ('Không Gia Đình');

-- Liên kết Thể loại (CT_THELOAI)
INSERT INTO CT_THELOAI VALUES (1, 1), (1, 2); -- Tựa sách 1: Khoa học MT, TL tham khảo
INSERT INTO CT_THELOAI VALUES (2, 1), (2, 2); -- Tựa sách 2: Khoa học MT, TL tham khảo
INSERT INTO CT_THELOAI VALUES (3, 3);         -- Tựa sách 3: Tiểu thuyết
INSERT INTO CT_THELOAI VALUES (4, 3), (4, 5); -- Tựa sách 4: Tiểu thuyết, Văn học thiếu nhi

-- Liên kết Tác giả (CT_TACGIA)
INSERT INTO CT_TACGIA VALUES (1, 1), (1, 2);
INSERT INTO CT_TACGIA VALUES (2, 2);
INSERT INTO CT_TACGIA VALUES (3, 3);
INSERT INTO CT_TACGIA VALUES (4, 4);


-- 6. NHẬP SÁCH & TỒN KHO
INSERT INTO NHACUNGCAP (TenNCC, DiaChi)
VALUES ('Vinabook', 'HCM'), ('Fahasa', 'Hà Nội');

INSERT INTO PHIEUNHAPSACH (IDNhaCungCap, NgayNhap)
VALUES (1, '2025-01-10 09:00:00'), -- ID = 1
       (2, '2025-01-15 14:30:00'); -- ID = 2
       
INSERT INTO NHAXUATBAN (TenNXB, DiaChi)
VALUES ('NXB Trẻ', 'HCM'), ('NXB Giáo dục Việt Nam', 'Hà Nội');

-- Lô sách (SACH) - SoLuongTong/ConLai ban đầu bằng 0, được cập nhật bởi Trigger CT_PHIEUNHAP
INSERT INTO SACH (IDTuaSach, SoLuongTong, SoLuongConLai, DonGia, NamXB, IDNhaXuatBan)
VALUES (1, 0, 0, 80000, 2020, 1), -- ID = 1 (CSDL Nâng cao)
       (2, 0, 0, 120000, 2023, 1), -- ID = 2 (Data Mining)
       (3, 0, 0, 65000, 2024, 2); -- ID = 3 (Ông Già Và Biển Cả)

-- Chi tiết Phiếu Nhập (Trigger cập nhật SACH và TongTien PHIEUNHAPSACH)
INSERT INTO CT_PHIEUNHAP (IDPhieuNhap, IDSach, SoLuongNhap, DonGiaNhap)
VALUES (1, 1, 10, 70000), -- Nhập 10 cuốn S1
       (1, 2, 5, 100000),  -- Nhập 5 cuốn S2
       (2, 3, 15, 60000);  -- Nhập 15 cuốn S3

-- Cuốn Sách Vật Lý (CUONSACH)
INSERT INTO CUONSACH (IDSach)
VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1), -- S1: CSDL Nâng cao (10 cuốn: CS0001 - CS0010)
       (2), (2), (2), (2), (2), -- S2: Data Mining (5 cuốn: CS0011 - CS0015)
       (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3), (3); -- S3: Ông Già Và Biển Cả (15 cuốn: CS0016 - CS0030)


-- 7. MƯỢN TRẢ & PHẠT

-- 7.1. Phiếu Mượn 1: DG1 (Nguyễn Mai Anh) - Không trễ
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien)
VALUES (1, '2025-03-01 10:00:00', '2025-03-05 10:00:00'); -- ID = 1

-- Chi tiết Mượn (Trigger cập nhật CUONSACH và SACH)
INSERT INTO CT_PHIEUMUON (IDPhieuMuon, IDCuonSach) VALUES (1, 1), (1, 16);

-- Trả sách (Ngày 05/03/2025 - Đúng hạn)
UPDATE CT_PHIEUMUON
SET NgayTraThucTe = '2025-03-05 09:30:00', SoNgayTre = 0, TienPhat = 0
WHERE IDPhieuMuon = 1 AND IDCuonSach IN (1, 16);


-- 7.2. Phiếu Mượn 2: DG2 (Lê Thành Đô) - Trễ 2 ngày
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien)
VALUES (2, '2025-03-10 14:00:00', '2025-03-14 14:00:00'); -- ID = 2

-- Chi tiết Mượn
INSERT INTO CT_PHIEUMUON (IDPhieuMuon, IDCuonSach) VALUES (2, 2), (2, 17);

-- Trả sách (Ngày 16/03/2025 - Trễ 2 ngày, Phạt 2000/cuốn)
UPDATE CT_PHIEUMUON
SET NgayTraThucTe = '2025-03-16 10:00:00', SoNgayTre = 2, TienPhat = 2000
WHERE IDPhieuMuon = 2 AND IDCuonSach = 2; -- Nợ DG2: 5000 + 2000 = 7000

UPDATE CT_PHIEUMUON
SET NgayTraThucTe = '2025-03-16 10:00:00', SoNgayTre = 2, TienPhat = 2000
WHERE IDPhieuMuon = 2 AND IDCuonSach = 17; -- Nợ DG2: 7000 + 2000 = 9000


-- 7.3. Phiếu Thu (DG2 thanh toán 5000 VND)
INSERT INTO PHIEUTHU (IDDocGia, SoTienThu, NgayLap)
VALUES (2, 5000, '2025-03-20 09:00:00');
-- Trigger cập nhật TongNoHienTai cho DG2: 9000 - 5000 = 4000 VND


-- 7.4. Phiếu Mượn 3: DG3 (Huỳnh Hồng Thu Giang) - Đang mượn (để kiểm tra tồn kho)
INSERT INTO PHIEUMUON (IDDocGia, NgayMuon, NgayTraDuKien)
VALUES (3, NOW(), DATE_ADD(NOW(), INTERVAL 4 DAY)); -- ID = 3

-- Chi tiết Mượn
INSERT INTO CT_PHIEUMUON (IDPhieuMuon, IDCuonSach) VALUES (3, 3);
-- Cuốn sách 3 (CS0003) đang ở trạng thái 0 (Đang mượn). SoLuongConLai của S1 (CSDL Nâng cao) giảm 1.