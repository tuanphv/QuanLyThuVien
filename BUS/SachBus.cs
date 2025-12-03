// File: SachBUS.cs
using DAO;
using DTO;
using System;
using System.ComponentModel;

namespace BUS
{
    public class SachBUS
    {
        public static BindingList<SachDTO> GetAll()
        {
            return SachDAO.GetAll();
        }

        public static string Add(SachDTO sach)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(sach.TieuDe))
            {
                throw new Exception("Tiêu đề không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(sach.ISBN))
            {
                throw new Exception("ISBN không được để trống.");
            }

            if (sach.NamXuatBan < 1900 || sach.NamXuatBan > DateTime.Now.Year)
            {
                throw new Exception("Năm xuất bản phải hợp lệ (từ 1900 đến hiện tại).");
            }

            if (sach.GiaSach < 0)
            {
                throw new Exception("Giá sách không được âm.");
            }

            if (sach.SoLuongTong < 0 || sach.SoLuongCon < 0)
            {
                throw new Exception("Số lượng không được âm.");
            }

            if (sach.SoLuongCon > sach.SoLuongTong)
            {
                throw new Exception("Số lượng còn lại không được vượt quá tổng số lượng.");
            }

            if (sach.MaNXB <= 0)
            {
                throw new Exception("Mã nhà xuất bản không hợp lệ.");
            }

            if (sach.MaTheLoai <= 0)
            {
                throw new Exception("Mã thể loại không hợp lệ.");
            }

            // Kiểm tra ISBN tồn tại
            if (SachDAO.IsISBNExists(sach.ISBN))
            {
                throw new Exception("ISBN đã tồn tại.");
            }

            return SachDAO.Add(sach);
        }

        public static bool Update(SachDTO sach)
        {
            // Validate dữ liệu tương tự Add
            if (string.IsNullOrWhiteSpace(sach.TieuDe))
            {
                throw new Exception("Tiêu đề không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(sach.ISBN))
            {
                throw new Exception("ISBN không được để trống.");
            }

            if (sach.NamXuatBan < 1900 || sach.NamXuatBan > DateTime.Now.Year)
            {
                throw new Exception("Năm xuất bản phải hợp lệ (từ 1900 đến hiện tại).");
            }

            if (sach.GiaSach < 0)
            {
                throw new Exception("Giá sách không được âm.");
            }

            if (sach.SoLuongTong < 0 || sach.SoLuongCon < 0)
            {
                throw new Exception("Số lượng không được âm.");
            }

            if (sach.SoLuongCon > sach.SoLuongTong)
            {
                throw new Exception("Số lượng còn lại không được vượt quá tổng số lượng.");
            }

            if (sach.MaNXB <= 0)
            {
                throw new Exception("Mã nhà xuất bản không hợp lệ.");
            }

            if (sach.MaTheLoai <= 0)
            {
                throw new Exception("Mã thể loại không hợp lệ.");
            }

            // Kiểm tra ISBN tồn tại với sách khác
            if (SachDAO.IsISBNExists(sach.ISBN) && !SachDAO.IsISBNBelongsToSach(sach.ISBN, sach.MaSach))
            {
                throw new Exception("ISBN đã tồn tại với sách khác.");
            }

            return SachDAO.Update(sach);
        }

        public static bool Delete(int maSach)
        {
            // Kiểm tra xem sách có đang được mượn không
            if (SachDAO.IsInUse(maSach))
            {
                throw new Exception("Không thể xóa sách này.\nSách đang có lịch sử mượn/trả hoặc nhập.");
            }

            return SachDAO.Delete(maSach);
        }

        public static string GetNewMaSach()
        {
            return SachDAO.TaoMaMoi();
        }

        public static BindingList<SachDTO> SearchByTieuDe(string tieuDe)
        {
            return SachDAO.SearchByTieuDe(tieuDe);
        }
    }
}