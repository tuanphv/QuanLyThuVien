# H??ng d?n s? d?ng ch?c n?ng Nh?p Sách

## Mô t? ch?c n?ng
Ch?c n?ng Nh?p Sách cho phép th? th? t?o phi?u nh?p sách m?i t? nhà cung c?p, t? ??ng qu?n lý lô sách và t?o cu?n sách v?t lý trong h? th?ng.

## Các tính n?ng chính

### 1. Xem danh sách phi?u nh?p (UCNhapSach)
- Hi?n th? t?t c? các phi?u nh?p sách ?ã t?o
- Thông tin hi?n th?:
  - Mã phi?u nh?p
  - Nhà cung c?p
  - Ngày nh?p
  - T?ng ti?n
- Nút "Xem chi ti?t" ?? xem thông tin chi ti?t phi?u nh?p

### 2. L?p phi?u nh?p m?i (FrmAddPhieuNhap)

#### B??c 1: Ch?n thông tin phi?u nh?p
- Ch?n nhà cung c?p t? danh sách
- Ch?n ngày nh?p (m?c ??nh là ngày hi?n t?i)

#### B??c 2: Thêm sách vào phi?u nh?p
Nh?p các thông tin sau:
- **T?a sách**: Ch?n t? danh sách t?a sách có s?n
- **Nhà xu?t b?n**: Ch?n nhà xu?t b?n c?a sách
- **N?m xu?t b?n**: Nh?p n?m xu?t b?n (1900-2100)
- **??n giá**: Nh?p giá nh?p vào (VN?)
- **S? l??ng**: Nh?p s? l??ng sách c?n nh?p

Nh?n nút **"Thêm"** ?? thêm sách vào danh sách nh?p.

#### B??c 3: Qu?n lý danh sách sách nh?p
- Xem danh sách các sách ?ã thêm v?i ??y ?? thông tin
- T?ng ti?n ???c t? ??ng tính
- Nh?n nút **"Xóa"** ?? xóa sách ?ã ch?n kh?i danh sách

#### B??c 4: L?u phi?u nh?p
Nh?n nút **"L?u"** ?? hoàn t?t phi?u nh?p. H? th?ng s?:
1. T?o phi?u nh?p sách m?i
2. Tìm ho?c t?o m?i lô sách (SACH) v?i:
   - T?a sách, NXB, n?m XB gi?ng nhau ? s? d?ng lô c?
   - Khác nhau ? t?o lô m?i
3. Thêm chi ti?t phi?u nh?p (CT_PHIEUNHAP)
4. **Trigger database t? ??ng**:
   - T?ng SoLuongTong và SoLuongConLai c?a lô sách
   - T?o cu?n sách v?t lý (CUONSACH) t??ng ?ng
   - C?p nh?t TongTien cho phi?u nh?p

### 3. Xem chi ti?t phi?u nh?p (FrmChiTietPhieuNhap)
- Hi?n th? thông tin phi?u nh?p:
  - Mã phi?u nh?p
  - Nhà cung c?p
  - Ngày nh?p
  - T?ng ti?n
- Hi?n th? danh sách sách ?ã nh?p v?i:
  - Mã sách
  - Tên t?a sách
  - S? l??ng
  - ??n giá
  - Thành ti?n

## Phân quy?n
Ch?c n?ng ???c qu?n lý b?i quy?n **PhieuNhapSach (ID = 8)**:
- **Xem (View)**: Xem danh sách phi?u nh?p và chi ti?t
- **Thêm (Add)**: L?p phi?u nh?p m?i
- Các quy?n S?a/Xóa: Ch?a tri?n khai (theo quy trình nghi?p v? th?c t?)

## C? s? d? li?u

### Các b?ng liên quan
1. **PHIEUNHAPSACH**: Thông tin t?ng quát v? phi?u nh?p
2. **CT_PHIEUNHAP**: Chi ti?t các sách trong phi?u nh?p
3. **SACH**: Lô sách (nhóm các cu?n sách có cùng t?a sách, NXB, n?m XB)
4. **CUONSACH**: Cu?n sách v?t lý (???c t?o t? ??ng b?i trigger)
5. **TUASACH**: Thông tin t?a sách
6. **NHAXUATBAN**: Thông tin nhà xu?t b?n
7. **NHACUNGCAP**: Thông tin nhà cung c?p

### Trigger t? ??ng
Khi thêm dòng vào **CT_PHIEUNHAP**, trigger `after_insert_CT_PHIEUNHAP` s?:
1. C?p nh?t `TongTien` c?a phi?u nh?p
2. T?ng `SoLuongTong` và `SoLuongConLai` c?a lô sách
3. T? ??ng t?o các **CUONSACH** t??ng ?ng v?i s? l??ng nh?p

## L?u ý khi s? d?ng
1. **Lô sách**: H? th?ng t? ??ng g?p các l?n nh?p sách có cùng t?a sách, NXB và n?m XB vào m?t lô
2. **Cu?n sách v?t lý**: ???c t?o t? ??ng, m?i cu?n có mã riêng (CS0001, CS0002, ...)
3. **??n giá**: M?i l?n nh?p có th? có ??n giá khác nhau, ??n giá c?a lô sách s? ???c c?p nh?t theo l?n nh?p cu?i
4. **Validation**: 
   - Ph?i ch?n nhà cung c?p
   - Ph?i thêm ít nh?t m?t sách vào phi?u nh?p
   - Không ???c trùng sách (cùng t?a sách, NXB, n?m XB) trong cùng phi?u nh?p

## Các file code ?ã t?o

### DTO Layer
- `DTO\PhieuNhapSachDTO.cs`: DTO cho phi?u nh?p sách
- `DTO\SachDTO.cs`: DTO cho lô sách
- `DTO\CT_PhieuNhapDTO.cs`: DTO cho chi ti?t phi?u nh?p

### DAO Layer
- `DAO\PhieuNhapSachDAO.cs`: Truy v?n database cho phi?u nh?p
- `DAO\SachDAO.cs`: Truy v?n database cho lô sách
- `DAO\CT_PhieuNhapDAO.cs`: Truy v?n database cho chi ti?t phi?u nh?p

### BUS Layer
- `BUS\PhieuNhapSachBUS.cs`: Business logic cho phi?u nh?p
- `BUS\SachBUS.cs`: Business logic cho lô sách

### GUI Layer
- `GUI\NhapSach\UCNhapSach.cs/.Designer.cs`: UserControl danh sách phi?u nh?p
- `GUI\NhapSach\FrmAddPhieuNhap.cs/.Designer.cs`: Form l?p phi?u nh?p m?i
- `GUI\NhapSach\FrmChiTietPhieuNhap.cs/.Designer.cs`: Form xem chi ti?t phi?u nh?p

## Ki?m tra ch?c n?ng
1. ??ng nh?p v?i tài kho?n có quy?n PhieuNhapSach
2. Truy c?p menu "Nh?p Sách M?i"
3. Th? t?o phi?u nh?p m?i v?i các sách khác nhau
4. Ki?m tra database:
   - B?ng PHIEUNHAPSACH có b?n ghi m?i
   - B?ng CT_PHIEUNHAP có chi ti?t
   - B?ng SACH có lô sách m?i ho?c c?p nh?t s? l??ng
   - B?ng CUONSACH có các cu?n sách v?t lý m?i
5. Xem chi ti?t phi?u nh?p v?a t?o
