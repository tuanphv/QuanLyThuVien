using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class TheLoaiBUS
    {        
        private static TheLoaiBUS instance;

        public static TheLoaiBUS Instance
        {
            get { if (instance == null) instance = new TheLoaiBUS(); return instance; }
            private set { instance = value; }
        }

        private TheLoaiBUS() { }
                
        public List<TheLoaiDTO> GetAllTheLoai()
        {            
            return TheLoaiDAO.Instance.GetAllTheLoai();
        }

        // THÊM thể loại mới
        public string InsertTheLoai(string tenTheLoai)
        {
            // 1. Tên thể loại không được để trống
            if (string.IsNullOrWhiteSpace(tenTheLoai))
            {
                return "Tên thể loại không được để trống!";
            }

            // Kiểm tra xem tên đã tồn tại chưa
            // (Hiện tại bỏ qua để đơn giản hóa)
            if (TheLoaiDAO.Instance.InsertTheLoai(tenTheLoai))
            {
                return string.Empty; 
            }
            else
            {
                return "Đã xảy ra lỗi khi thêm. Vui lòng thử lại.";
            }
        }

        // CẬP NHẬT thể loại
        public string UpdateTheLoai(int id, string tenTheLoai)
        {
            if (string.IsNullOrWhiteSpace(tenTheLoai))
            {
                return "Tên thể loại không được để trống!";
            }
            if (TheLoaiDAO.Instance.UpdateTheLoai(id, tenTheLoai))
            {
                return string.Empty;
            }
            else
            {
                return "Đã xảy ra lỗi khi cập nhật. Vui lòng thử lại.";
            }
        }

        //  XÓA thể loại
        public bool DeleteTheLoai(int id)
        {
            // (Nếu có quy tắc, ví dụ: "Không được xóa thể loại nếu đang có sách sử dụng"
            // thì sẽ kiểm tra ở đây. Hiện tại ta cho phép xóa.)

            // Gọi xuống DAO để xóa
            return TheLoaiDAO.Instance.DeleteTheLoai(id);
        }

        //TÌM KIẾM
        public List<TheLoaiDTO> SearchTheLoai(string keyword)
        {
            return TheLoaiDAO.Instance.SearchTheLoai(keyword);
        }
    }
}
