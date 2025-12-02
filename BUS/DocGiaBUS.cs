using DAO;
using DTO;
using System;
using System.ComponentModel;

namespace BUS
{
    public class DocGiaBUS
    {
        public static BindingList<DocGiaDTO> GetAll()
        {
            return DocGiaDAO.GetAll();
        }

        public static string Add(DocGiaDTO docGia)
        {
            // Validate d? li?u
            if (string.IsNullOrWhiteSpace(docGia.HoTen))
            {
                throw new Exception("Họ tên không được để trống.");
            }

            if (docGia.NgaySinh == DateTime.MinValue)
            {
                throw new Exception("Ngày sinh không hợp lệ.");
            }

          
            int tuoi = DateTime.Now.Year - docGia.NgaySinh.Year;
            if (docGia.NgaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--;

           
            if (tuoi < 18 || tuoi > 55)
            {
                throw new Exception("Tuổi tham gia phải từ 18 đến 55");
            }

            if (docGia.NgayLapThe == DateTime.MinValue)
            {
                throw new Exception("Ngày lập thể không hợp lệ.");
            }

            if (docGia.NgayHetHan == DateTime.MinValue)
            {
                throw new Exception("Ngày hết hạn không hợp lệ.");
            }

            if (docGia.NgayHetHan <= docGia.NgayLapThe)
            {
                throw new Exception("Ngày hết hạn phải sau ngày lập thể.");
            }

            return DocGiaDAO.Add(docGia);
        }

        public static bool Update(DocGiaDTO docGia)
        {
            // Validate d? li?u
            if (string.IsNullOrWhiteSpace(docGia.HoTen))
            {
                throw new Exception("Họ tên không được để trống.");
            }

            if (docGia.NgaySinh == DateTime.MinValue)
            {
                throw new Exception("Ngày sinh không hợp lệ.");
            }

       
            int tuoi = DateTime.Now.Year - docGia.NgaySinh.Year;
            if (docGia.NgaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 18 || tuoi > 55)
            {
                throw new Exception("tuổi them gia phải từ 18 đến 55.");
            }

            if (docGia.NgayLapThe == DateTime.MinValue)
            {
                throw new Exception("Ngày lập thể không hợp lệ.");
            }

            if (docGia.NgayHetHan == DateTime.MinValue)
            {
                throw new Exception("Ngày hết hạn không hợp lệ.");
            }

            if (docGia.NgayHetHan <= docGia.NgayLapThe)
            {
                throw new Exception("Ngày hết hạn phải sau ngày lập thể.");
            }

            return DocGiaDAO.Update(docGia);
        }

        public static bool Delete(string maDocGia)
        {
            // Ki?m tra xem ??c gi? có ?ang m??n sách không
            if (DocGiaDAO.IsInUse(maDocGia))
            {
                throw new Exception("Không thể xóa độc giả này.\nđộc giả đang có lịch sử mượn n/trả sách.");
            }

            return DocGiaDAO.Delete(maDocGia);
        }

        public static string GetNewMaDocGia()
        {
            return DocGiaDAO.TaoMaMoi();
        }

        public static BindingList<NguoiDungDTO> GetNguoiDungChuaLaDocGia()
        {
            return DocGiaDAO.GetNguoiDungChuaLaDocGia();
        }

        public static bool UpdateTongNo(string maDocGia, int soTien)
        {
            if (soTien == 0)
            {
                throw new Exception("Số tiền phải khác 0.");
            }

            return DocGiaDAO.UpdateTongNo(maDocGia, soTien);
        }
    }
}
