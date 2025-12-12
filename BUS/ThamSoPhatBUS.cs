using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class ThamSoPhatBUS
    {
        // Lấy tất cả quy định phạt để đổ vào Combobox/Checklist
        public static List<ThamSoPhatDTO> LayTatCa()
        {
            return ThamSoPhatDAO.LayDanhSach();
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