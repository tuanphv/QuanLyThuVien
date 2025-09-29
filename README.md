# 📚 Ứng dụng Quản Lý Thư Viện

## 📝 Giới thiệu
Ứng dụng **Quản Lý Thư Viện** được phát triển bằng **C# WinForms** và **.NET** nhằm hỗ trợ các thư viện trong việc quản lý sách, độc giả và mượn/trả tài liệu.  
Phần mềm giúp **tự động hóa quy trình** và cung cấp giao diện trực quan, dễ sử dụng cho nhân viên thư viện.

---

## ⚙️ Công nghệ sử dụng
- **Ngôn ngữ:** C#  
- **Nền tảng:** .NET 6/8 (WinForms)  
- **CSDL:** MySQL  
- **ORM/DAO:** Data Access Object (ADO.NET)  
- **Quản lý cấu hình:** `.env` (dotenv.net)  

---

## 🚀 Chức năng chính
- 👤 **Quản lý độc giả**: thêm, sửa, xóa thông tin độc giả, cấp thẻ thư viện.  
- 📖 **Quản lý sách**: thêm mới, cập nhật, phân loại sách, quản lý nhà xuất bản và tác giả.  
- 📑 **Mượn – Trả sách**: lập phiếu mượn, theo dõi hạn trả, xử lý quá hạn.  
- 📊 **Báo cáo – Thống kê**: thống kê số lượng sách, độc giả, tình trạng mượn trả.    

---

## 🖼️ Giao diện (demo)
> (Thêm hình ảnh giao diện nếu có: màn hình đăng nhập, quản lý sách, phiếu mượn…)

---

## 🔧 Cài đặt & chạy thử
1. Clone project:
   ```bash
   git clone https://github.com/tuanphv/QuanLyThuVien.git
	```

2. Tạo database MySQL và import script trong Docs/DatabaseScrips.

3. Cập nhật file .env:
	```bash
	DB_SERVER=localhost
	DB_PORT=3306
	DB_NAME=QuanLyThuVien
	DB_USER=root
	DB_PASSWORD=
	```

4. Mở solution trong Visual Studio (chọn file QuanLyThuVien.sln) và cài đặt thư viện.
- MySql.Data
- DotNetEnv
- QRCoder

5. Build và chạy ứng dụng.

## 👥 Nhóm phát triển
- Thành viên 1
- Thành viên 2
- Thành viên 3