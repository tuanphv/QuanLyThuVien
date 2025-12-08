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

        public static BindingList<SachMuonLuaChonDTO> TimCuonSachSanSang(string keyword, IEnumerable<string> maLoaiTru)
        {
            return MuonTraDAO.TimCuonSachSanSang(keyword, maLoaiTru?.ToList() ?? new List<string>());
        }

        public static SachMuonLuaChonDTO? LayCuonSachSanSang(string maCuonSach)
        {
            if (string.IsNullOrWhiteSpace(maCuonSach)) return null;
            return MuonTraDAO.LayCuonSachSanSang(maCuonSach.Trim());
        }

        public static BindingList<ChiTietPhieuMuonDTO> LayChiTietPhieuMuon(int idPhieuMuon)
        {
            return MuonTraDAO.LayChiTietPhieuMuon(idPhieuMuon);
        }

        public static ThamSoMuonTraDTO LayThamSoMuonTra()
        {
            return MuonTraDAO.LayThamSoMuonTra();
        }

        public static PhieuMuonDTO LapPhieuMuon(string maDocGia, List<SachMuonLuaChonDTO> danhSachCuon, DateTime? ngayTraDuKien = null)
        {
            if (string.IsNullOrWhiteSpace(maDocGia))
                throw new Exception("Mã độc giả không được trống.");
            if (danhSachCuon == null || danhSachCuon.Count == 0)
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

            var danhSachHopLe = danhSachCuon
                .Where(s => !string.IsNullOrWhiteSpace(s.MaCuonSach))
                .GroupBy(s => s.MaCuonSach.Trim(), StringComparer.OrdinalIgnoreCase)
                .Select(g => g.First())
                .ToList();

            int soDangMuon = MuonTraDAO.DemSoSachDangMuon(docGia.ID);
            if (thamSo.SoSachMuonToiDa > 0 && soDangMuon + danhSachHopLe.Count > thamSo.SoSachMuonToiDa)
                throw new Exception($"Độc giả chỉ được mượn tối đa {thamSo.SoSachMuonToiDa} sách. Hiện đang giữ {soDangMuon} sách.");

            List<(int idCuon, string tinhTrangMuon, int? idThamSoPhat)> danhSachIdCuon = new();
            foreach (var cuon in danhSachHopLe)
            {
                var thongTin = MuonTraDAO.LayCuonSachSanSang(cuon.MaCuonSach);
                if (thongTin == null)
                    throw new Exception($"Không tìm thấy cuốn sách {cuon.MaCuonSach}.");
                if (!MuonTraDAO.CuonSachSanSang(thongTin.IDCuonSach))
                    throw new Exception($"Cuốn sách {cuon.MaCuonSach} không sẵn sàng cho mượn.");

                string tinhTrangMuon = string.IsNullOrWhiteSpace(cuon.TinhTrangMuon)
                    ? thongTin.TinhTrangHienTai ?? "Bình thường"
                    : cuon.TinhTrangMuon.Trim();

                danhSachIdCuon.Add((thongTin.IDCuonSach, tinhTrangMuon, cuon.IDThamSoPhatMuon));
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

        public static PhieuMuonDTO LapPhieuMuon(string maDocGia, List<string> danhSachMaCuon, DateTime? ngayTraDuKien = null)
        {
            var danhSach = danhSachMaCuon
                .Where(m => !string.IsNullOrWhiteSpace(m))
                .Select(m => new SachMuonLuaChonDTO { MaCuonSach = m.Trim(), TinhTrangMuon = "Bình thường" })
                .ToList();

            return LapPhieuMuon(maDocGia, danhSach, ngayTraDuKien);
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
            var chiTiet = MuonTraDAO.LayChiTietPhieuMuon(idPhieuMuon)
                .Where(c => !c.NgayTraThucTe.HasValue)
                .ToList();

            foreach (var ct in chiTiet)
            {
                CapNhatTienPhatChiTiet(ct, thamSo);
            }

            if (!MuonTraDAO.TraPhieuMuon(idPhieuMuon, DateTime.Today, chiTiet, out tongTienPhat, out _))
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

        public static BindingList<ChiTietPhieuTraDTO> LayChiTietPhieuTra(int idPhieuTra)
        {
            return MuonTraDAO.LayChiTietPhieuTra(idPhieuTra);
        }

        public static bool XoaPhieuTra(int idPhieuTra)
        {
            return MuonTraDAO.XoaPhieuTra(idPhieuTra);
        }

        public static PhieuTraDTO LapPhieuTra(string maPhieuMuon, out int tongTienPhat)
        {
            if (string.IsNullOrWhiteSpace(maPhieuMuon))
                throw new Exception("Cần nhập mã phiếu mượn.");

            var phieu = LayPhieuMuonTheoMa(maPhieuMuon)
                ?? throw new Exception("Không tìm thấy phiếu mượn.");

            var chiTiet = MuonTraDAO.LayChiTietPhieuMuon(phieu.ID);
            foreach (var ct in chiTiet)
            {
                ct.ChonTra = !ct.DaTra;
            }

            return LapPhieuTra(phieu.ID, chiTiet, out tongTienPhat);
        }

        public static PhieuTraDTO LapPhieuTra(int idPhieuMuon, IEnumerable<ChiTietPhieuMuonDTO> danhSachTra, out int tongTienPhat)
        {
            var phieu = LayPhieuMuonTheoID(idPhieuMuon)
                ?? throw new Exception("Không tìm thấy phiếu mượn.");

            var danhSach = danhSachTra
                .Where(c => !c.NgayTraThucTe.HasValue && c.ChonTra)
                .ToList();

            if (danhSach.Count == 0)
                throw new Exception("Vui lòng chọn ít nhất một cuốn sách để trả.");

            var thamSo = MuonTraDAO.LayThamSoMuonTra();
            foreach (var ct in danhSach)
            {
                CapNhatTienPhatChiTiet(ct, thamSo);
            }

            if (!MuonTraDAO.TraPhieuMuon(idPhieuMuon, DateTime.Today, danhSach, out tongTienPhat, out int idPhieuTra))
            {
                throw new Exception("Không thể cập nhật trả sách.");
            }

            var phieuTra = MuonTraDAO.LayPhieuTraTheoID(idPhieuTra);
            if (phieuTra == null)
            {
                throw new Exception("Không thể tải thông tin phiếu trả vừa tạo.");
            }

            return phieuTra;
        }

        private static void CapNhatTienPhatChiTiet(ChiTietPhieuMuonDTO chiTiet, ThamSoMuonTraDTO thamSo)
        {
            int soNgayTre = Math.Max(0, (DateTime.Today.Date - chiTiet.NgayTraDuKien.Date).Days);
            chiTiet.SoNgayTre = soNgayTre;

            int phatTreHen = soNgayTre * thamSo.DonGiaPhatMoiNgay;
            int mucPhat = chiTiet.MucPhatTra ?? chiTiet.MucPhatMuon ?? 0;
            int phatHuHong = (chiTiet.DonGia * mucPhat) / 100;

            chiTiet.TienPhat = phatTreHen + phatHuHong;
        }

        public static bool CapNhatTinhTrangCuonSach(int idPhieuMuon, int idCuonSach, string tinhTrangMuon, string? tinhTrangTra, bool daTra, int? idThamSoPhatMuon = null, int? idThamSoPhatTra = null)
        {
            if (string.IsNullOrWhiteSpace(tinhTrangMuon))
                throw new Exception("Tình trạng mượn không được để trống.");

            return MuonTraDAO.CapNhatTinhTrangCuonSach(idPhieuMuon, idCuonSach, tinhTrangMuon.Trim(), tinhTrangTra?.Trim(), daTra, idThamSoPhatMuon, idThamSoPhatTra);
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

            worksheet.Cell(1, 1).Value = "Mã phiếu trả";
            worksheet.Cell(1, 2).Value = "Mã phiếu mượn";
            worksheet.Cell(1, 3).Value = "Mã độc giả";
            worksheet.Cell(1, 4).Value = "Họ tên độc giả";
            worksheet.Cell(1, 5).Value = "Ngày trả";
            worksheet.Cell(1, 6).Value = "Sách đã trả";
            worksheet.Cell(1, 7).Value = "Tiền phạt";

            int row = 2;
            foreach (var pt in danhSachPhieuTra)
            {
                worksheet.Cell(row, 1).Value = pt.MaPhieuTra;
                worksheet.Cell(row, 2).Value = pt.MaPhieuMuon;
                worksheet.Cell(row, 3).Value = pt.MaDocGia;
                worksheet.Cell(row, 4).Value = pt.HoTenDocGia;
                worksheet.Cell(row, 5).Value = pt.NgayTra;
                worksheet.Cell(row, 6).Value = pt.TongSachTra;
                worksheet.Cell(row, 7).Value = pt.TongTienPhat;
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
