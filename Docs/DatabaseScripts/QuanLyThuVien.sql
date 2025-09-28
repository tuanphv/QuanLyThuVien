-- ===================================================
-- SCRIPT TẠO DATABASE HỆ THỐNG QUẢN LÝ THƯ VIỆN (MySQL)
-- ===================================================

DROP DATABASE IF EXISTS QuanLyThuVien;
CREATE DATABASE QuanLyThuVien CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE QuanLyThuVien;

-- ===================================================
-- TẠO CÁC BẢNG
-- ===================================================

CREATE TABLE DocGia (
    MaDocGia INT PRIMARY KEY AUTO_INCREMENT,
    TenDangNhap VARCHAR(50) UNIQUE NOT NULL,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh VARCHAR(10),
    DiaChi VARCHAR(200),
    Email VARCHAR(100),
    SoDienThoai VARCHAR(20),
    NgayDangKy DATE DEFAULT (CURRENT_DATE)
);

CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY AUTO_INCREMENT,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh VARCHAR(10),
    DiaChi VARCHAR(200),
    SoDienThoai VARCHAR(20),
    ChucVu VARCHAR(50),
    NgayVaoLam DATE DEFAULT (CURRENT_DATE)
);

CREATE TABLE TheThuVien (
    MaThe INT PRIMARY KEY AUTO_INCREMENT,
    MaDocGia INT,
    NgayTao DATE DEFAULT (CURRENT_DATE),
    TrangThai VARCHAR(20) DEFAULT 'Hoạt động', -- Hoạt động / Bị khóa
    QRCode VARCHAR(255),
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia)
);

CREATE TABLE TheLoai (
    MaTheLoai INT PRIMARY KEY AUTO_INCREMENT,
    TenTheLoai VARCHAR(100) NOT NULL,
    MoTa TEXT
);

CREATE TABLE NhaXuatBan (
    MaNXB INT PRIMARY KEY AUTO_INCREMENT,
    TenNXB VARCHAR(100) NOT NULL,
    DiaChi VARCHAR(200),
    SoDienThoai VARCHAR(20)
);

CREATE TABLE TacGia (
    MaTacGia INT PRIMARY KEY AUTO_INCREMENT,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    QuocTich VARCHAR(50)
);

CREATE TABLE Sach (
    MaSach INT PRIMARY KEY AUTO_INCREMENT,
    TieuDe VARCHAR(200) NOT NULL,
    ISBN VARCHAR(20),
    NamXuatBan INT,
    GiaSach DECIMAL(10,2),
    SoLuongTong INT DEFAULT 0,
    SoLuongCon INT DEFAULT 0,
    MaNXB INT,
    MaTheLoai INT,
    FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB),
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai)
);

CREATE TABLE Sach_TacGia (
    MaSach INT,
    MaTacGia INT,
    PRIMARY KEY (MaSach, MaTacGia),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach),
    FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia)
);

CREATE TABLE NhaCungCap (
    MaNCC INT PRIMARY KEY AUTO_INCREMENT,
    TenNCC VARCHAR(100) NOT NULL,
    DiaChi VARCHAR(200),
    SoDienThoai VARCHAR(20)
);

CREATE TABLE NhapSach (
    MaPhieuNhap INT PRIMARY KEY AUTO_INCREMENT,
    MaNCC INT,
    NgayNhap DATE DEFAULT (CURRENT_DATE),
    MaNhanVien INT,
    TongTien DECIMAL(10,2),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChiTietNhapSach (
    MaPhieuNhap INT,
    MaSach INT,
    SoLuong INT,
    DonGia DECIMAL(10,2),
    PRIMARY KEY (MaPhieuNhap, MaSach),
    FOREIGN KEY (MaPhieuNhap) REFERENCES NhapSach(MaPhieuNhap),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

CREATE TABLE PhieuMuon (
    MaPhieuMuon INT PRIMARY KEY AUTO_INCREMENT,
    MaDocGia INT,
    MaNhanVien INT,
    NgayMuon DATE DEFAULT (CURRENT_DATE),
    HanTra DATE,
    TrangThai VARCHAR(20) DEFAULT 'Đang mượn',
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChiTietMuon (
    MaPhieuMuon INT,
    MaSach INT,
    SoLuong INT,
    PRIMARY KEY (MaPhieuMuon, MaSach),
    FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

CREATE TABLE PhieuTra (
    MaPhieuTra INT PRIMARY KEY AUTO_INCREMENT,
    MaPhieuMuon INT,
    NgayTra DATE DEFAULT (CURRENT_DATE),
    TinhTrangSach VARCHAR(100),
    TienPhat DECIMAL(10,2) DEFAULT 0,
    FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon)
);

CREATE TABLE PhieuPhat (
    MaPhieuPhat INT PRIMARY KEY AUTO_INCREMENT,
    MaDocGia INT,
    LyDo VARCHAR(200),
    SoTien DECIMAL(10,2),
    NgayLap DATE DEFAULT (CURRENT_DATE),
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia)
);

CREATE TABLE DangNhap (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(255) NOT NULL,
    MaNhanVien INT NULL,
    MaDocGia INT NULL,
    VaiTro VARCHAR(20) NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia)
);

-- ===================================================
-- TRIGGER (MySQL)
-- ===================================================

DELIMITER $$

-- Sau khi nhập sách
CREATE TRIGGER trg_UpdateSachAfterNhap
AFTER INSERT ON ChiTietNhapSach
FOR EACH ROW
BEGIN
    UPDATE Sach
    SET SoLuongTong = SoLuongTong + NEW.SoLuong,
        SoLuongCon = SoLuongCon + NEW.SoLuong
    WHERE MaSach = NEW.MaSach;
END$$

-- Sau khi mượn sách
CREATE TRIGGER trg_UpdateSachAfterMuon
AFTER INSERT ON ChiTietMuon
FOR EACH ROW
BEGIN
    UPDATE Sach
    SET SoLuongCon = SoLuongCon - NEW.SoLuong
    WHERE MaSach = NEW.MaSach;
END$$

-- Sau khi trả sách
CREATE TRIGGER trg_UpdateSachAfterTra
AFTER INSERT ON PhieuTra
FOR EACH ROW
BEGIN
    UPDATE Sach s
    JOIN ChiTietMuon ct ON NEW.MaPhieuMuon = ct.MaPhieuMuon
    SET s.SoLuongCon = s.SoLuongCon + ct.SoLuong
    WHERE s.MaSach = ct.MaSach;
END$$

DELIMITER ;

-- ===================================================
-- STORED PROCEDURES (MySQL)
-- ===================================================

DELIMITER $$

CREATE PROCEDURE sp_TimKiemSach(IN TuKhoa VARCHAR(200))
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
    WHERE s.TieuDe LIKE CONCAT('%', TuKhoa, '%')
       OR tg.HoTen LIKE CONCAT('%', TuKhoa, '%')
       OR tl.TenTheLoai LIKE CONCAT('%', TuKhoa, '%')
    GROUP BY s.MaSach, s.TieuDe, s.ISBN, s.NamXuatBan, s.GiaSach,
             s.SoLuongTong, s.SoLuongCon, tl.TenTheLoai, nxb.TenNXB
    ORDER BY s.TieuDe;
END$$

CREATE PROCEDURE sp_BaoCaoSachPhoBien(IN NgayBatDau DATE, IN NgayKetThuc DATE, IN SoTop INT)
BEGIN
    SELECT s.MaSach, s.TieuDe,
           COUNT(ct.MaSach) AS SoLanMuon,
           SUM(ct.SoLuong) AS TongSoLuongMuon
    FROM Sach s
    INNER JOIN ChiTietMuon ct ON s.MaSach = ct.MaSach
    INNER JOIN PhieuMuon pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
    WHERE pm.NgayMuon BETWEEN NgayBatDau AND NgayKetThuc
    GROUP BY s.MaSach, s.TieuDe
    ORDER BY SoLanMuon DESC, TongSoLuongMuon DESC
    LIMIT SoTop;
END$$

DELIMITER ;

