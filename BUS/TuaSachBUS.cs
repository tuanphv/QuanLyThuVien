using ClosedXML.Excel;
using DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace BUS
{
    public class TuaSachBUS
    {
        public static List<DTO.TuaSachDTO> GetAll()
        {
            return DAO.TuaSachDAO.GetAll();
        }

        public static string AddBookTitle(DTO.TuaSachDTO tuaSach)
        {
            if (DAO.TuaSachDAO.IsNameExist(tuaSach.TenTuaSach))
            {
                throw new Exception("Tựa sách với tên này đã tồn tại.");
            }
            tuaSach.MaTuaSach = TaoVietTat(tuaSach.TenTuaSach);
            return DAO.TuaSachDAO.AddBookTitle(tuaSach);
        }

        public static bool UpdateBookTitle(DTO.TuaSachDTO tuaSach)
        {
            if (DAO.TuaSachDAO.IsNameExist(tuaSach.TenTuaSach, tuaSach.MaTuaSach))
            {
                throw new Exception("Tựa sách với tên này đã tồn tại.");
            }

            bool updated = DAO.TuaSachDAO.UpdateBookTitle(tuaSach);
            if (!updated)
                throw new Exception("Cập nhật tựa sách thất bại.");

            return true;
        }

        public static bool DeleteBookTitle(int id)
        {
            return DAO.TuaSachDAO.DeleteBookTitle(id);
        }

        // Search with optional keyword, genreId and authorId
        public static BindingList<TuaSachDTO> Search(string keyword, int genreId = 0, int authorId = 0)
        {
            return DAO.TuaSachDAO.Search(keyword, genreId, authorId);
        }

        //Trí thêm hàm lấy tựa sách theo mã thể loại
        public static List<TuaSachDTO> GetByMaTheLoai(string maTheLoai)
        {
            return DAO.TuaSachDAO.GetByMaTheLoai(maTheLoai);
        }

        //Trí thêm hàm lấy tựa sách theo mã tác giả
        public static List<DTO.TuaSachDTO> GetByMaTacGia(string maTacGia)
        {
            return DAO.TuaSachDAO.GetByMaTacGia(maTacGia);
        }

        public static byte[] ExportToExcel()
        {
            List<TuaSachDTO> tuaSachs = DAO.TuaSachDAO.GetAll(); using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("TuaSach"); // Thêm header
                worksheet.Cell(1, 1).Value = "Mã Tựa Sách";
                worksheet.Cell(1, 2).Value = "Tên tựa sách";
                worksheet.Cell(1, 3).Value = "Thể loại";
                worksheet.Cell(1, 4).Value = "Tác giả";
                int row = 2;
                foreach (var ts in tuaSachs)
                {
                    worksheet.Cell(row, 1).Value = ts.MaTuaSach;
                    worksheet.Cell(row, 2).Value = ts.TenTuaSach;
                    worksheet.Cell(row, 3).Value = ts.TheLoai;
                    worksheet.Cell(row, 4).Value = ts.TacGia;
                    row++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        public static (List<TuaSachDTO> importedList, int fail) ImportFromExcel(string filePath)
        {
            List<TuaSachDTO> importedList = new List<TuaSachDTO>();
            int fail = 0;

            using (var workbook = new XLWorkbook(filePath))
            {
                var ws = workbook.Worksheet(1); // sheet đầu tiên
                var rows = ws.RangeUsed().RowsUsed();

                foreach (var row in rows.Skip(1)) // bỏ header
                {
                    try
                    {
                        var tuaSach = new TuaSachDTO
                        {
                            TenTuaSach = row.Cell(1).GetValue<string>(),
                            TheLoai = row.Cell(2).GetValue<string>(),
                            TacGia = row.Cell(3).GetValue<string>()
                        };

                        if (ValidateTuaSach(tuaSach))
                        {
                            // Chèn vào DB
                            tuaSach.MaTuaSach = TaoVietTat(tuaSach.TenTuaSach);
                            string maTS = AddBookTitle(tuaSach);
                            if (maTS != string.Empty)
                            {
                                importedList.Add(tuaSach);
                            }
                        }
                    }
                    catch
                    {
                        fail++;
                    }
                }
            }

            return (importedList, fail);
        }

        private static bool ValidateTuaSach(TuaSachDTO tuaSach)
        {
            if (string.IsNullOrWhiteSpace(tuaSach.TenTuaSach))
                throw new Exception("Tên tựa sách không được để trống.");
            if (string.IsNullOrWhiteSpace(tuaSach.TheLoai))
                throw new Exception("Thể loại không được để trống.");
            if (string.IsNullOrWhiteSpace(tuaSach.TacGia))
                throw new Exception("Tác giả không được để trống.");
            return true;
        }

        public static string TaoVietTat(string tenSach)
        {
            if (string.IsNullOrWhiteSpace(tenSach))
                return string.Empty;

            // Tách tên sách thành các từ
            string[] tu = tenSach.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Nếu ít hơn 2 từ thì chỉ lấy chữ cái đầu của từ đầu tiên
            if (tu.Length == 0) return string.Empty;
            if (tu.Length == 1) return tu[0][0].ToString().ToUpper();

            // Lấy chữ cái đầu của 2 từ đầu tiên
            char c1 = char.ToUpper(tu[0][0]);
            char c2 = char.ToUpper(tu[1][0]);

            return $"{c1}{c2}";
        }
    }
}
