### ?? H??ng d?n s? d?ng H? th?ng ??ng nh?p

## ?? **T�i kho?n demo c� s?n:**

### ?? **Nh�n vi�n (Qu?n tr? vi�n):**
- **Username:** `admin`
- **Password:** `123456`
- **Quy?n:** To�n quy?n truy c?p h? th?ng

- **Username:** `thutkhu1` 
- **Password:** `123456`
- **Quy?n:** Nh�n vi�n th? kho

- **Username:** `kythuat1`
- **Password:** `123456`
- **Quy?n:** Nh�n vi�n k? thu?t

### ?? **??c gi?:**
- **Username:** `docgia001`
- **Password:** `123456`
- **Quy?n:** Xem s�ch, l?ch s? m??n/tr?

- **Username:** `docgia002`
- **Password:** `123456`
- **Quy?n:** Xem s�ch, l?ch s? m??n/tr?

## ?? **T�nh n?ng ?� implement:**

### ? **Authentication (X�c th?c):**
- ? Ki?m tra t�n ??ng nh?p v� m?t kh?u
- ? Validation input (kh�ng ?? tr?ng)
- ? Th�ng b�o l?i th�n thi?n
- ? Loading state khi ??ng nh?p
- ? H? tr? nh?n Enter ?? ??ng nh?p

### ? **Authorization (Ph�n quy?n):**
- ? **Nh�n vi�n:** To�n quy?n truy c?p
- ? **??c gi?:** Ch? xem ???c s�ch v� l?ch s? c� nh�n
- ? Session management (qu?n l� phi�n ??ng nh?p)
- ? Auto logout khi ?�ng ?ng d?ng

### ? **Security Features:**
- ? M?t kh?u ???c mask (*????*)
- ? Clear password khi ??ng nh?p th?t b?i
- ? Ki?m tra k?t n?i database tr??c khi login
- ? X? l� exception v� th�ng b�o l?i

## ?? **C�ch test:**

1. **Ch?y ?ng d?ng**
2. **Th? ??ng nh?p v?i t�i kho?n admin:**
   - Username: `admin`
   - Password: `123456` 
3. **Ki?m tra quy?n:** T?t c? menu ??u accessible
4. **??ng xu?t v� th? v?i ??c gi?:**
   - Username: `docgia001`
   - Password: `123456`
5. **Ki?m tra h?n ch?:** M?t s? menu b? disable

## ?? **Next Steps:**
- Implement c�c form con (Books, Readers, etc.)
- Th�m change password functionality
- Password hashing (hi?n t?i l?u plain text)
- Remember me feature
- Audit log (l?ch s? ??ng nh?p)