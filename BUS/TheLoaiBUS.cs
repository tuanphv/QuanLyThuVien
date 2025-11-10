using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TheLoaiBUS
    {
        public static BindingList<TheLoaiDTO> GetAll()
        {
            return TheLoaiDAO.GetAll();
        }

        public static string Add(TheLoaiDTO theLoai)
        {
            if (string.IsNullOrWhiteSpace(theLoai.TenTheLoai))
            {
                throw new Exception("Tên thể loại không được để trống.");
            }

            if (TheLoaiDAO.IsNameExist(theLoai.TenTheLoai))
            {
                throw new Exception("Thể loại với tên này đã tồn tại.");
            }
            return TheLoaiDAO.Add(theLoai);
        }

        public static bool Update(TheLoaiDTO theLoai)
        {
            if (string.IsNullOrWhiteSpace(theLoai.TenTheLoai))
            {
                throw new Exception("Tên thể loại không được để trống.");
            }

            if (TheLoaiDAO.IsNameExist(theLoai.TenTheLoai, theLoai.MaTheLoai))
            {
                throw new Exception("Thể loại với tên này đã tồn tại.");
            }
            return TheLoaiDAO.Update(theLoai);
        }

        public static bool Delete(string maTheLoai)
        {
            if (TheLoaiDAO.IsInUse(maTheLoai))
            {
                // Nếu có, ném ra lỗi nghiệp vụ, không cho xóa
                throw new Exception("Không thể xóa thể loại này.\nThể loại đang được gán cho các tựa sách hiện có.");
            }
            return TheLoaiDAO.Delete(maTheLoai);
        }
    }
}
