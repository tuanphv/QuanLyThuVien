using ClosedXML.Excel;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace BUS
{
    public class MuonTraBUS
    {
        public static BindingList<PhieuMuonDTO> LayTatCaPhieuMuon()
        {
            return MuonTraDAO.LayTatCaPhieuMuon();
        }

        public static BindingList<ChiTietPhieuMuonDTO> LayChiTietPhieuMuon(int idPhieuMuon)
        {
            return MuonTraDAO.LayChiTietPhieuMuon(idPhieuMuon);
        }

        public static PhieuMuonDTO LapPhieuMuon(string maDocGia, List<string> danhSachMaCuon, DateTime? ngayTraDuKien = null)
        {
            if (string.IsNullOrWhiteSpace(maDocGia))
                throw new Exception("Mã độc giả không được trống.");
            if (danhSachMaCuon == null || danhSachMaCuon.Count == 0)
                throw new Exception("Cần nhập ít nhất một cuốn sách để mượn.");

            var docGia = MuonTraDAO.LayThongTinDocGia(maDocGia.Trim());
            if (docGia == null)
                throw new Exception("Không tìm thấy độc giả.");

            var thamSo = MuonTraDAO.LayThamSoMuonTra();
            int tuoi = DateTime.Today.Year - docGia.NgaySinh.Year;
            if (docGia.NgaySinh.Date > DateTime.Today.AddYears(-tuoi))
                tuoi--;

            if (thamSo.TuoiToiThieu > 0 && tuoi < thamSo.TuoiToiThieu)
                throw new Exception($"Độc giả chưa đủ tuổi tối thiểu ({thamSo.TuoiToiThieu}).");
            if (thamSo.TuoiToiDa > 0 && tuoi > thamSo.TuoiToiDa)
                throw new Exception($"Độc giả đã vượt quá tuổi tối đa ({thamSo.TuoiToiDa}).");
            if (docGia.NgayHetHan.Date < DateTime.Today)
                throw new Exception("Thẻ độc giả đã hết hạn.");

            int soDangMuon = MuonTraDAO.DemSoSachDangMuon(docGia.ID);
            if (thamSo.SoSachMuonToiDa > 0 && soDangMuon + danhSachMaCuon.Count > thamSo.SoSachMuonToiDa)
                throw new Exception($"Độc giả chỉ được mượn tối đa {thamSo.SoSachMuonToiDa} sách. Hiện đang giữ {soDangMuon} sách.");

            List<int> danhSachIdCuon = new();
            foreach (var maCuon in danhSachMaCuon.Select(m => m.Trim()).Where(m => !string.IsNullOrWhiteSpace(m)))
            {
                int? idCuon = MuonTraDAO.LayIDCuonSach(maCuon);
                if (idCuon == null)
                    throw new Exception($"Không tìm thấy cuốn sách {maCuon}.");
                if (!MuonTraDAO.CuonSachSanSang(idCuon.Value))
                    throw new Exception($"Cuốn sách {maCuon} không sẵn sàng cho mượn.");
                danhSachIdCuon.Add(idCuon.Value);
            }

            DateTime ngayMuon = DateTime.Today;
            DateTime hanTraToiDa = TinhHanTraMacDinh(ngayMuon, thamSo.SoNgayMuonToiDa);

            DateTime ngayTra = ngayTraDuKien?.Date ?? hanTraToiDa.Date;
            if (ngayTra.Date < ngayMuon.Date)
                throw new Exception("Ngày trả dự kiến không được trước ngày mượn.");
            if (thamSo.SoNgayMuonToiDa > 0 && ngayTra.Date > hanTraToiDa.Date)
                throw new Exception($"Hạn trả tối đa là {hanTraToiDa:dd/MM/yyyy} theo quy định.");
            if (ngayTra.Date > docGia.NgayHetHan.Date)
                throw new Exception("Ngày trả dự kiến không được vượt quá ngày hết hạn thẻ độc giả.");

            return MuonTraDAO.TaoPhieuMuonVaChiTiet(docGia, danhSachIdCuon, ngayMuon, ngayTra);
        }

        public static DateTime TinhHanTraMacDinh(DateTime ngayMuon)
        {
            var thamSo = MuonTraDAO.LayThamSoMuonTra();
            return TinhHanTraMacDinh(ngayMuon, thamSo.SoNgayMuonToiDa);
        }

        private static DateTime TinhHanTraMacDinh(DateTime ngayMuon, int soNgayMuonToiDa)
        {
            return soNgayMuonToiDa > 0
                ? ngayMuon.AddDays(soNgayMuonToiDa)
                : ngayMuon;
        }

        public static PhieuMuonDTO? GiaHanPhieuMuon(int idPhieuMuon, int soNgayGiaHan)
        {
            if (soNgayGiaHan <= 0)
                throw new Exception("Số ngày gia hạn phải lớn hơn 0.");
            var phieu = MuonTraDAO.LayPhieuMuonTheoID(idPhieuMuon);
            if (phieu == null)
                throw new Exception("Không tìm thấy phiếu mượn.");
            if (phieu.SoSachChuaTra <= 0)
                throw new Exception("Tất cả sách đã được trả. Không thể gia hạn.");

            DateTime hanTraMoi = phieu.NgayTraDuKien.AddDays(soNgayGiaHan);
            if (MuonTraDAO.GiaHanPhieuMuon(idPhieuMuon, hanTraMoi))
            {
                phieu.NgayTraDuKien = hanTraMoi;
                return phieu;
            }
            return null;
        }

        public static PhieuMuonDTO TraPhieuMuon(int idPhieuMuon, out int tongTienPhat)
        {
            var phieu = MuonTraDAO.LayPhieuMuonTheoID(idPhieuMuon)
                ?? throw new Exception("Không tìm thấy phiếu mượn.");
            var thamSo = MuonTraDAO.LayThamSoMuonTra();

            if (!MuonTraDAO.TraPhieuMuon(idPhieuMuon, DateTime.Today, thamSo.DonGiaPhatMoiNgay, out tongTienPhat))
            {
                throw new Exception("Không thể cập nhật trả sách.");
            }

            var capNhat = MuonTraDAO.LayPhieuMuonTheoID(idPhieuMuon);
            return capNhat ?? phieu;
        }

        public static PhieuMuonDTO? LayPhieuMuonTheoID(int idPhieuMuon)
        {
            return MuonTraDAO.LayPhieuMuonTheoID(idPhieuMuon);
        }
        
        public static PhieuMuonDTO? LayPhieuMuonTheoMa(string maPhieuMuon)
        {
            if (string.IsNullOrWhiteSpace(maPhieuMuon)) return null;
            return MuonTraDAO.LayPhieuMuonTheoMa(maPhieuMuon.Trim());
        }

        public static bool XoaPhieuMuon(int idPhieuMuon)
        {
            return MuonTraDAO.XoaPhieuMuon(idPhieuMuon);
        }

        public static BindingList<PhieuTraDTO> LayTatCaPhieuTra()
        {
            return MuonTraDAO.LayTatCaPhieuTra();
        }

        public static BindingList<ChiTietPhieuTraDTO> LayChiTietPhieuTra(int idPhieuMuon)
        {
            return MuonTraDAO.LayChiTietPhieuTra(idPhieuMuon);
        }

        public static bool XoaPhieuTra(int idPhieuMuon)
        {
            return MuonTraDAO.XoaPhieuTra(idPhieuMuon);
        }

        public static PhieuTraDTO LapPhieuTra(string maPhieuMuon, out int tongTienPhat)
        {
            if (string.IsNullOrWhiteSpace(maPhieuMuon))
                throw new Exception("Cần nhập mã phiếu mượn.");

            var phieu = LayPhieuMuonTheoMa(maPhieuMuon)
                ?? throw new Exception("Không tìm thấy phiếu mượn.");

            if (phieu.SoSachChuaTra <= 0)
                throw new Exception("Phiếu này đã trả hết sách.");

            TraPhieuMuon(phieu.ID, out tongTienPhat);
            return new PhieuTraDTO
            {
                IDPhieuMuon = phieu.ID,
                MaPhieuMuon = phieu.MaPhieuMuon,
                MaDocGia = phieu.MaDocGia,
                HoTenDocGia = phieu.HoTenDocGia,
                NgayTra = DateTime.Today,
                TongSachTra = phieu.SoSachChuaTra,
                TongTienPhat = tongTienPhat
            };
        }

        public static bool CapNhatTinhTrangCuonSach(int idPhieuMuon, int idCuonSach, string tinhTrangMuon, string? tinhTrangTra, bool daTra)
        {
            if (string.IsNullOrWhiteSpace(tinhTrangMuon))
                throw new Exception("Tình trạng mượn không được để trống.");

            return MuonTraDAO.CapNhatTinhTrangCuonSach(idPhieuMuon, idCuonSach, tinhTrangMuon.Trim(), tinhTrangTra?.Trim(), daTra);
        }

        public static byte[] ExportPhieuMuonToExcel()
        {
            var danhSachPhieuMuon = MuonTraDAO.LayTatCaPhieuMuon();
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("PhieuMuon");

            worksheet.Cell(1, 1).Value = "Mã phiếu";
            worksheet.Cell(1, 2).Value = "Mã độc giả";
            worksheet.Cell(1, 3).Value = "Họ tên độc giả";
            worksheet.Cell(1, 4).Value = "Ngày mượn";
            worksheet.Cell(1, 5).Value = "Hạn trả";
            worksheet.Cell(1, 6).Value = "Sách chưa trả";
            worksheet.Cell(1, 7).Value = "Tình trạng";

            int row = 2;
            foreach (var pm in danhSachPhieuMuon)
            {
                worksheet.Cell(row, 1).Value = pm.MaPhieuMuon;
                worksheet.Cell(row, 2).Value = pm.MaDocGia;
                worksheet.Cell(row, 3).Value = pm.HoTenDocGia;
                worksheet.Cell(row, 4).Value = pm.NgayMuon;
                worksheet.Cell(row, 5).Value = pm.NgayTraDuKien;
                worksheet.Cell(row, 6).Value = pm.SoSachChuaTra;
                worksheet.Cell(row, 7).Value = pm.TinhTrang;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public static byte[] ExportPhieuTraToExcel()
        {
            var danhSachPhieuTra = MuonTraDAO.LayTatCaPhieuTra();
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("PhieuTra");

            worksheet.Cell(1, 1).Value = "Mã phiếu mượn";
            worksheet.Cell(1, 2).Value = "Mã độc giả";
            worksheet.Cell(1, 3).Value = "Họ tên độc giả";
            worksheet.Cell(1, 4).Value = "Ngày trả";
            worksheet.Cell(1, 5).Value = "Sách đã trả";
            worksheet.Cell(1, 6).Value = "Tiền phạt";

            int row = 2;
            foreach (var pt in danhSachPhieuTra)
            {
                worksheet.Cell(row, 1).Value = pt.MaPhieuMuon;
                worksheet.Cell(row, 2).Value = pt.MaDocGia;
                worksheet.Cell(row, 3).Value = pt.HoTenDocGia;
                worksheet.Cell(row, 4).Value = pt.NgayTra;
                worksheet.Cell(row, 5).Value = pt.TongSachTra;
                worksheet.Cell(row, 6).Value = pt.TongTienPhat;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public static (List<PhieuMuonDTO> importedList, int fail) ImportPhieuMuonFromExcel(string filePath)
        {
            List<PhieuMuonDTO> importedList = new();
            int fail = 0;

            using var workbook = new XLWorkbook(filePath);
            var ws = workbook.Worksheet(1);
            var rows = ws.RangeUsed()?.RowsUsed();
            if (rows == null) return (importedList, fail);

            foreach (var row in rows.Skip(1))
            {
                try
                {
                    string maDocGia = row.Cell(1).GetValue<string>().Trim();
                    string danhSachMaCuon = row.Cell(2).GetValue<string>();
                    DateTime? ngayTraDuKien = null;
                    string ngayTraStr = row.Cell(3).GetValue<string>();
                    if (!string.IsNullOrWhiteSpace(ngayTraStr) && DateTime.TryParse(ngayTraStr, out DateTime parsed))
                    {
                        ngayTraDuKien = parsed;
                    }

                    var danhSachMaCuonList = danhSachMaCuon
                        .Split(new[] { ',', ';', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(m => m.Trim())
                        .Where(m => !string.IsNullOrWhiteSpace(m))
                        .ToList();

                    var phieu = LapPhieuMuon(maDocGia, danhSachMaCuonList, ngayTraDuKien);
                    importedList.Add(phieu);
                }
                catch
                {
                    fail++;
                }
            }

            return (importedList, fail);
        }

        public static (List<PhieuTraDTO> importedList, int fail) ImportPhieuTraFromExcel(string filePath)
        {
            List<PhieuTraDTO> importedList = new();
            int fail = 0;

            using var workbook = new XLWorkbook(filePath);
            var ws = workbook.Worksheet(1);
            var rows = ws.RangeUsed()?.RowsUsed();
            if (rows == null) return (importedList, fail);

            foreach (var row in rows.Skip(1))
            {
                try
                {
                    string maPhieuMuon = row.Cell(1).GetValue<string>().Trim();
                    if (string.IsNullOrWhiteSpace(maPhieuMuon))
                    {
                        fail++;
                        continue;
                    }

                    var phieuTra = LapPhieuTra(maPhieuMuon, out _);
                    importedList.Add(phieuTra);
                }
                catch
                {
                    fail++;
                }
            }

            return (importedList, fail);
        }
    }
}
