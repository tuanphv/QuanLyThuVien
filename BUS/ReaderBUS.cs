using DTO;
using System.ComponentModel;

namespace BUS
{
    public class ReaderBUS
    {
        public static BindingList<DTO.ReaderDTO> GetAllReaders()
        {
            return DAO.ReaderDAO.GetAllReaders();
        }

        public static int AddReader(DTO.ReaderDTO reader)
        {
            return DAO.ReaderDAO.AddReader(reader);
        }

        public static bool UpdateReader(DTO.ReaderDTO reader)
        {
            return ValidateReader(reader) && DAO.ReaderDAO.UpdateReader(reader);
        }

        public static bool DeleteReader(int readerId)
        {
            return DAO.ReaderDAO.DeleteReader(readerId);
        }

        public static BindingList<DTO.ReaderDTO> SearchReaders(BindingList<ReaderDTO> list, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return GetAllReaders();

            BindingList<ReaderDTO> result = new BindingList<ReaderDTO>();
                
            // duyệt từng reader, cho vào result những kết quả phù hợp
            foreach (ReaderDTO reader in list)
            {
                if (reader.MaDocGia.ToString().Contains(text) ||
                    DataProcessing.RemoveDiacritics(reader.HoTen).ToLower().Contains(text.ToLower()) ||
                    DataProcessing.RemoveDiacritics(reader.DiaChi).ToLower().Contains(text.ToLower()) ||
                    reader.Email.ToLower().Contains(text.ToLower()) ||
                    reader.SoDienThoai.Contains(text))
                {
                    result.Add(reader);
                }
            }

            return result;
        } 

        private static bool ValidateReader(DTO.ReaderDTO reader)
        {
            if (string.IsNullOrWhiteSpace(reader.HoTen))
                return false;
            if (reader.NgaySinh == DateTime.MinValue || reader.NgaySinh > DateTime.Now)
                return false;
            if (string.IsNullOrWhiteSpace(reader.GioiTinh))
                return false;
            if (string.IsNullOrWhiteSpace(reader.DiaChi))
                return false;
            if (string.IsNullOrWhiteSpace(reader.Email) || !reader.Email.Contains("@"))
                return false;
            if (string.IsNullOrWhiteSpace(reader.SoDienThoai) || reader.SoDienThoai.Length < 10)
                return false;
            if (reader.NgayDangKy == DateTime.MinValue || reader.NgayDangKy > DateTime.Now)
                return false;
            return true;
        }
    }
}
