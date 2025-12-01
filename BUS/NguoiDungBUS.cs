using DAO;
using DTO;
using System;
using System.ComponentModel;

namespace BUS
{
    public class NguoiDungBUS
    {
        public static BindingList<NguoiDungDTO> GetAll()
        {
            return NguoiDungDAO.GetAll();
        }

        public static string Add(NguoiDungDTO nguoiDung)
        {
            // Validate d? li?u
            if (string.IsNullOrWhiteSpace(nguoiDung.TenNguoiDung))
            {
                throw new Exception("Tên ng??i dùng không ???c ?? tr?ng.");
            }

            if (string.IsNullOrWhiteSpace(nguoiDung.TenDangNhap))
            {
                throw new Exception("Tên ??ng nh?p không ???c ?? tr?ng.");
            }

            if (string.IsNullOrWhiteSpace(nguoiDung.MatKhau))
            {
                throw new Exception("M?t kh?u không ???c ?? tr?ng.");
            }

            if (nguoiDung.MatKhau.Length < 3)
            {
                throw new Exception("M?t kh?u ph?i có ít nh?t 3 ký t?.");
            }

            if (nguoiDung.IDNhomNguoiDung <= 0)
            {
                throw new Exception("Vui lòng ch?n nhóm ng??i dùng.");
            }

            // Ki?m tra trùng tên ??ng nh?p
            if (NguoiDungDAO.IsTenDangNhapExist(nguoiDung.TenDangNhap))
            {
                throw new Exception("Tên ??ng nh?p này ?ã t?n t?i.");
            }

            return NguoiDungDAO.Add(nguoiDung);
        }

        public static bool Update(NguoiDungDTO nguoiDung)
        {
            // Validate d? li?u
            if (string.IsNullOrWhiteSpace(nguoiDung.TenNguoiDung))
            {
                throw new Exception("Tên ng??i dùng không ???c ?? tr?ng.");
            }

            if (string.IsNullOrWhiteSpace(nguoiDung.TenDangNhap))
            {
                throw new Exception("Tên ??ng nh?p không ???c ?? tr?ng.");
            }

            if (string.IsNullOrWhiteSpace(nguoiDung.MatKhau))
            {
                throw new Exception("M?t kh?u không ???c ?? tr?ng.");
            }

            if (nguoiDung.MatKhau.Length < 3)
            {
                throw new Exception("M?t kh?u ph?i có ít nh?t 3 ký t?.");
            }

            if (nguoiDung.IDNhomNguoiDung <= 0)
            {
                throw new Exception("Vui lòng ch?n nhóm ng??i dùng.");
            }

            // Ki?m tra trùng tên ??ng nh?p
            if (NguoiDungDAO.IsTenDangNhapExist(nguoiDung.TenDangNhap, nguoiDung.MaNguoiDung))
            {
                throw new Exception("Tên ??ng nh?p này ?ã t?n t?i.");
            }

            return NguoiDungDAO.Update(nguoiDung);
        }

        public static bool Delete(string maNguoiDung)
        {
            // Ki?m tra xem ng??i dùng có ?ang ???c s? d?ng không
            if (NguoiDungDAO.IsInUse(maNguoiDung))
            {
                throw new Exception("Không th? xóa ng??i dùng này.\nNg??i dùng ?ang ???c liên k?t v?i h? s? ??c gi?.");
            }

            return NguoiDungDAO.Delete(maNguoiDung);
        }

        public static string GetNewMaNguoiDung()
        {
            return NguoiDungDAO.TaoMaMoi();
        }

        public static NguoiDungDTO? Login(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                throw new Exception("Tên đăng nhập không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                throw new Exception("Mật khẩu không được để trống.");
            }

            NguoiDungDTO? nguoiDung = NguoiDungDAO.Login(tenDangNhap, matKhau);
            
            if (nguoiDung == null)
            {
                throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }

            return nguoiDung;
        }
    }
}
