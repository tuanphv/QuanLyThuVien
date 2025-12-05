using DAO;
using DTO;
using System; 
using System.ComponentModel;

namespace BUS
{
    public class TacGiaBUS
    {
        // 1. Lấy tất cả
        public static BindingList<TacGiaDTO> GetAll()
        {
            return TacGiaDAO.GetAll();
        }

        // 2. Thêm mới
        public static string Add(TacGiaDTO tacGia)
        {
            // Kiểm tra tên rỗng
            if (string.IsNullOrWhiteSpace(tacGia.TenTacGia))
            {
                throw new Exception("Tên tác giả không được để trống.");
            }
                        
            ValidateNamSinh(tacGia.NamSinh);

            // Kiểm tra trùng tên
            if (TacGiaDAO.IsNameExist(tacGia.TenTacGia, tacGia.NamSinh))
            {
                throw new Exception("Tác giả với tên này đã tồn tại.");
            }

            return TacGiaDAO.Add(tacGia);
        }

        // 3. Cập nhật
        public static bool Update(TacGiaDTO tacGia)
        {
            // Kiểm tra tên rỗng
            if (string.IsNullOrWhiteSpace(tacGia.TenTacGia))
            {
                throw new Exception("Tên tác giả không được để trống.");
            }

            ValidateNamSinh(tacGia.NamSinh);

            // Kiểm tra trùng tên (trừ chính nó ra)
            if (TacGiaDAO.IsNameExist(tacGia.TenTacGia, tacGia.NamSinh, tacGia.MaTacGia))
            {
                throw new Exception("Tác giả với tên này đã tồn tại.");
            }

            return TacGiaDAO.Update(tacGia);
        }

        // 4. Xóa
        public static bool Delete(string maTacGia)
        {
            // Logic nghiệp vụ: Không cho xóa nếu Tác giả đang được sử dụng
            if (TacGiaDAO.IsInUse(maTacGia))
            {
                throw new Exception("Không thể xóa tác giả này.\nTác giả đang được gán cho các tựa sách hiện có.");
            }

            return TacGiaDAO.Delete(maTacGia);
        }

        // 5. [Hàm Phụ] Logic kiểm tra năm sinh 
        private static void ValidateNamSinh(int namSinh)
        {
            // Nếu năm sinh = 0 (người dùng không nhập) thì cho qua (chấp nhận null/0)
            if (namSinh == 0) return;

            int namHienTai = DateTime.Now.Year;

            // Kiểm tra logic cơ bản: Không được lớn hơn năm nay
            if (namSinh > namHienTai)
            {
                throw new Exception($"Năm sinh không hợp lệ (Phải nhỏ hơn hoặc bằng {namHienTai}).");
            }

            // Kiểm tra logic: Không được quá nhỏ (VD: nhỏ hơn 1000)
            if (namSinh < 1000)
            {
                throw new Exception("Năm sinh không hợp lệ (Vui lòng nhập đầy đủ 4 chữ số).");
            }
        }

        // 6. Lấy mã mới để hiển thị lên Form (nếu cần)
        public static string GetNewMaTacGia()
        {
            return TacGiaDAO.TaoMaMoi();
        }
    }
}