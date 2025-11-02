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
        public static BindingList<NhomNguoiDungDTO> GetAllNhomNguoiDung()
        {
            return DAO.NhomNguoiDungDAO.GetAllNhomNguoiDung();
        }
    }
}
