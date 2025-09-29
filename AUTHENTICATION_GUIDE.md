### ?? H??ng d?n s? d?ng H? th?ng ??ng nh?p

## ?? **Tài kho?n demo có s?n:**

### ?? **Nhân viên (Qu?n tr? viên):**
- **Username:** `admin`
- **Password:** `123456`
- **Quy?n:** Toàn quy?n truy c?p h? th?ng

- **Username:** `thutkhu1` 
- **Password:** `123456`
- **Quy?n:** Nhân viên th? kho

- **Username:** `kythuat1`
- **Password:** `123456`
- **Quy?n:** Nhân viên k? thu?t

### ?? **??c gi?:**
- **Username:** `docgia001`
- **Password:** `123456`
- **Quy?n:** Xem sách, l?ch s? m??n/tr?

- **Username:** `docgia002`
- **Password:** `123456`
- **Quy?n:** Xem sách, l?ch s? m??n/tr?

## ?? **Tính n?ng ?ã implement:**

### ? **Authentication (Xác th?c):**
- ? Ki?m tra tên ??ng nh?p và m?t kh?u
- ? Validation input (không ?? tr?ng)
- ? Thông báo l?i thân thi?n
- ? Loading state khi ??ng nh?p
- ? H? tr? nh?n Enter ?? ??ng nh?p

### ? **Authorization (Phân quy?n):**
- ? **Nhân viên:** Toàn quy?n truy c?p
- ? **??c gi?:** Ch? xem ???c sách và l?ch s? cá nhân
- ? Session management (qu?n lý phiên ??ng nh?p)
- ? Auto logout khi ?óng ?ng d?ng

### ? **Security Features:**
- ? M?t kh?u ???c mask (*????*)
- ? Clear password khi ??ng nh?p th?t b?i
- ? Ki?m tra k?t n?i database tr??c khi login
- ? X? lý exception và thông báo l?i

## ?? **Cách test:**

1. **Ch?y ?ng d?ng**
2. **Th? ??ng nh?p v?i tài kho?n admin:**
   - Username: `admin`
   - Password: `123456` 
3. **Ki?m tra quy?n:** T?t c? menu ??u accessible
4. **??ng xu?t và th? v?i ??c gi?:**
   - Username: `docgia001`
   - Password: `123456`
5. **Ki?m tra h?n ch?:** M?t s? menu b? disable

## ?? **Next Steps:**
- Implement các form con (Books, Readers, etc.)
- Thêm change password functionality
- Password hashing (hi?n t?i l?u plain text)
- Remember me feature
- Audit log (l?ch s? ??ng nh?p)