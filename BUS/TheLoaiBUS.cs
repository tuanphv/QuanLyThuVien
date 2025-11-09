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
            // TODO: (Nâng cao) Có thể kiểm tra xem Thể loại này
            // có đang được sử dụng trong bảng CT_THELOAI không trước khi xóa.
            // Nếu có thì nên ném ra Exception "Không thể xóa thể loại đang được sử dụng"
            // Hiện tại, Database của bạn đang để ON DELETE CASCADE (tự động xóa liên kết)
            // nên việc xóa này là an toàn.
            return TheLoaiDAO.Delete(maTheLoai);
        }
    }
}
