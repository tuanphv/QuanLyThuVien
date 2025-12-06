using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class ThamSoPhatBUS
    {
        public static IEnumerable<ThamSoPhatDTO> LayTatCa()
        {
            return ThamSoPhatDAO.LayTatCa();
        }

        public static IEnumerable<ThamSoPhatDTO> LayTheoLoai(string loaiTinhTrang)
        {
            return ThamSoPhatDAO.LayTheoLoai(loaiTinhTrang);
        }

        public static ThamSoPhatDTO? Them(ThamSoPhatDTO thamSo)
        {
            return ThamSoPhatDAO.Them(thamSo);
        }

        public static bool CapNhat(ThamSoPhatDTO thamSo)
        {
            return ThamSoPhatDAO.CapNhat(thamSo);
        }

        public static bool Xoa(int id)
        {
            return ThamSoPhatDAO.Xoa(id);
        }
    }
}
