USE QuanLyThuVien;

-- ===================================================
-- THÊM DỮ LIỆU MẪU
-- ===================================================

-- Thêm dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChucVu, NgayVaoLam) VALUES
(N'Nguyễn Văn An', '1985-06-15', N'Nam', N'123 Trần Hưng Đạo, Q1, TP.HCM', '0901234567', N'Thủ thư trưởng', '2020-01-15'),
(N'Trần Thị Bình', '1990-03-22', N'Nữ', N'456 Lê Lợi, Q3, TP.HCM', '0912345678', N'Thủ thư', '2021-05-10'),
(N'Lê Minh Cường', '1988-11-08', N'Nam', N'789 Nguyễn Huệ, Q1, TP.HCM', '0923456789', N'Nhân viên kỹ thuật', '2022-02-20');

-- Thêm dữ liệu cho bảng DocGia
INSERT INTO DocGia (TenDangNhap, HoTen, NgaySinh, GioiTinh, DiaChi, Email, SoDienThoai, NgayDangKy) VALUES
('docgia001', N'Phạm Văn Đức', '1995-07-12', N'Nam', N'12 Võ Văn Tần, Q3, TP.HCM', 'ducpv@gmail.com', '0934567890', '2023-01-10'),
('docgia002', N'Nguyễn Thị Esen', '1992-09-25', N'Nữ', N'34 Hai Bà Trưng, Q1, TP.HCM', 'esenngt@gmail.com', '0945678901', '2023-02-15'),
('docgia003', N'Trần Minh Phúc', '1998-04-03', N'Nam', N'56 Điện Biên Phủ, Q3, TP.HCM', 'phuctm@gmail.com', '0956789012', '2023-03-20'),
('docgia004', N'Lê Thị Giang', '1996-12-18', N'Nữ', N'78 Cách Mạng Tháng Tám, Q10, TP.HCM', 'gianglt@gmail.com', '0967890123', '2023-04-05'),
('docgia005', N'Hoàng Văn Hùng', '1994-02-28', N'Nam', N'90 Nam Kỳ Khởi Nghĩa, Q1, TP.HCM', 'hunghv@gmail.com', '0978901234', '2023-05-12');

-- Thêm dữ liệu cho bảng TheThuVien
INSERT INTO TheThuVien (MaDocGia, NgayTao, TrangThai, QRCode) VALUES
(1, '2023-01-10', 'Hoạt động', CONCAT('QR001_', UUID())),
(2, '2023-02-15', 'Hoạt động', CONCAT('QR002_', UUID())),
(3, '2023-03-20', 'Hoạt động', CONCAT('QR003_', UUID())),
(4, '2023-04-05', 'Hoạt động', CONCAT('QR004_', UUID())),
(5, '2023-05-12', 'Bị khóa',   CONCAT('QR005_', UUID()));

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
INSERT INTO DangNhap (TenDangNhap, MatKhau, MaNhanVien, MaDocGia, VaiTro) VALUES
('admin', '123456', 1, NULL, N'Admin'),
('thutkhu1', '123456', 2, NULL, N'Nhân viên'),
('kythuat1', '123456', 3, NULL, N'Nhân viên'),
('docgia001', '123456', NULL, 1, N'Độc giả'),
('docgia002', '123456', NULL, 2, N'Độc giả'),
('docgia003', '123456', NULL, 3, N'Độc giả'),
('docgia004', '123456', NULL, 4, N'Độc giả'),
('docgia005', '123456', NULL, 5, N'Độc giả');