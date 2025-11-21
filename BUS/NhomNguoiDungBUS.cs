using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhomNguoiDungBUS
    {
        public static BindingList<NhomNguoiDungDTO> GetAll()
        {
            return DAO.NhomNguoiDungDAO.GetAllNhomNguoiDung();
        }

        public static BindingList<NhomNguoiDungDTO> GetAllNhomNguoiDung()
        {
            return DAO.NhomNguoiDungDAO.GetAllNhomNguoiDung();
        }

        // Returns generated MaNhom (e.g., NND001) or null on failure
        public static string? AddNhomNguoiDung(string tenNhom)
        {
            return DAO.NhomNguoiDungDAO.AddNhomNguoiDung(tenNhom);
        }

        public static NhomNguoiDungDTO? GetNhomByMaNhom(string maNhom)
        {
            return DAO.NhomNguoiDungDAO.GetNhomByMaNhom(maNhom);
        }

        public static bool DeleteNhomNguoiDung(int groupId)
        {
            return DAO.NhomNguoiDungDAO.DeleteNhomNguoiDung(groupId);
        }
    }
}
