using ClosedXML.Excel;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BUS
{
    public static class MuonTraBUS
    {
        // ... (Các hàm TimCuonSachSanSang, LapPhieuMuon, LapPhieuTra giữ nguyên) ...

        public static BindingList<SachMuonLuaChonDTO> TimCuonSachSanSang(string keyword, HashSet<string> maDaChon)
        {
            var list = MuonTraDAO.TimCuonSachSanSang(keyword);
            var result = list.Where(s => !maDaChon.Contains(s.MaCuonSach)).ToList();
            return new BindingList<SachMuonLuaChonDTO>(result);
        }

        public static DateTime TinhHanTraMacDinh(DateTime ngayMuon)
        {
            var thamSo = LayThamSoMuonTra();
            return ngayMuon.AddDays(thamSo.SoNgayMuonToiDa);
        }

        public static PhieuMuonDTO LapPhieuMuon(string maDocGia, List<SachMuonLuaChonDTO> sachChons, DateTime? hanTra)
        {
            DocGiaMuonInfoDTO? docGia = MuonTraDAO.LayThongTinDocGia(maDocGia);
            if (docGia == null) throw new Exception($"Không tìm thấy độc giả với mã: {maDocGia}");

            KiemTraDieuKienMuon(docGia, sachChons.Count);
            var phieu = new PhieuMuonDTO
            {
                MaDocGia = docGia.MaDocGia,
                NgayMuon = DateTime.Now,
                NgayTraDuKien = hanTra ?? TinhHanTraMacDinh(DateTime.Now),
                TongSach = sachChons.Count,
                SoSachChuaTra = sachChons.Count
            };
            int idPhieu = MuonTraDAO.TaoPhieuMuon(phieu, sachChons);
            return LayPhieuMuonTheoID(idPhieu) ?? phieu;
        }

        // Overload hỗ trợ Import Excel (Danh sách mã cuốn sách string)
        public static PhieuMuonDTO LapPhieuMuon(string maDocGia, List<string> danhSachMaCuon, DateTime? hanTra)
        {
            // 1. Tìm thông tin sách từ mã
            List<SachMuonLuaChonDTO> sachChons = new List<SachMuonLuaChonDTO>();
            HashSet<string> maDaChon = new HashSet<string>();

            // Lấy toàn bộ sách sẵn sàng để tra cứu (hoặc tối ưu hơn là query từng mã)
            // Ở đây dùng cách đơn giản: query all rồi lọc (chỉ hiệu quả với db nhỏ)
            // Cách tốt hơn: Viết thêm DAO LayCuonSachByMa
            var allSach = MuonTraDAO.TimCuonSachSanSang("");

            foreach (var ma in danhSachMaCuon)
            {
                var sach = allSach.FirstOrDefault(s => s.MaCuonSach.Equals(ma, StringComparison.OrdinalIgnoreCase));
                if (sach != null && !maDaChon.Contains(sach.MaCuonSach))
                {
                    // Khi import excel, mặc định lấy tình trạng hiện tại của sách, không update lỗi mới
                    sach.TinhTrangMuon = sach.TinhTrangHienTai;
                    sach.DanhSachLoiMoi = null;

                    sachChons.Add(sach);
                    maDaChon.Add(sach.MaCuonSach);
                }
            }

            if (sachChons.Count == 0) throw new Exception($"Không tìm thấy cuốn sách nào khả dụng trong danh sách import.");
            if (sachChons.Count != danhSachMaCuon.Count)
            {
            }

            return LapPhieuMuon(maDocGia, sachChons, hanTra);
        }

        private static void KiemTraDieuKienMuon(DocGiaMuonInfoDTO docGia, int soLuongMuon)
        {
            var thamSo = LayThamSoMuonTra();
            if (docGia.NgayHetHan < DateTime.Today) throw new Exception("Thẻ độc giả đã hết hạn.");
            if (docGia.TongNoHienTai > 0) throw new Exception($"Độc giả đang nợ {docGia.TongNoHienTai:N0} đồng.");
            int dangMuon = MuonTraDAO.DemSoSachDangMuon(docGia.ID);
            if (dangMuon + soLuongMuon > thamSo.SoSachMuonToiDa) throw new Exception($"Chỉ được mượn tối đa {thamSo.SoSachMuonToiDa} cuốn.");
        }

        public static PhieuTraDTO LapPhieuTra(int idPhieuMuon, BindingList<ChiTietPhieuMuonDTO> chiTietTra, out decimal tongTienPhat)
        {
            var sachTra = chiTietTra.Where(c => c.ChonTra && !c.DaTra).ToList();
            if (sachTra.Count == 0) throw new Exception("Chưa chọn sách để trả.");

            var listThamSoPhat = ThamSoPhatBUS.LayTatCa();
            decimal tong = 0;
            var thamSo = LayThamSoMuonTra();
            foreach (var item in sachTra)
            {
                CapNhatTienPhatChiTiet(item, thamSo, listThamSoPhat);
                tong += item.TienPhat;
            }

            int idPhieuTra = MuonTraDAO.TaoPhieuTra(idPhieuMuon, sachTra);
            var phieuTra = LayPhieuTraTheoID(idPhieuTra);

            if (phieuTra != null)
            {
                tongTienPhat = phieuTra.TongTienPhat;
                return phieuTra;
            }
            tongTienPhat = tong;
            return new PhieuTraDTO { TongTienPhat = tong };
        }

        // Overload cho Import Excel (Trả tất cả sách trong phiếu)
        public static PhieuTraDTO LapPhieuTra(string maPhieuMuon, out decimal tongTienPhat)
        {
            var phieuMuon = LayPhieuMuonTheoMa(maPhieuMuon);
            if (phieuMuon == null) throw new Exception($"Không tìm thấy phiếu mượn: {maPhieuMuon}");

            var chiTiet = LayChiTietPhieuMuon(phieuMuon.ID);
            // Chọn trả tất cả các cuốn chưa trả
            foreach (var item in chiTiet)
            {
                if (!item.DaTra)
                {
                    item.ChonTra = true;
                    // Mặc định khi import: Tình trạng trả = Tình trạng mượn (Không lỗi mới)
                    item.DanhSachIdLoiTra = item.DanhSachIdLoiMuon;
                    item.TinhTrangTra = item.TinhTrangMuon;
                }
            }

            return LapPhieuTra(phieuMuon.ID, chiTiet, out tongTienPhat);
        }

        public static void CapNhatTienPhatChiTiet(ChiTietPhieuMuonDTO chiTiet, ThamSoMuonTraDTO thamSo, List<ThamSoPhatDTO> listQuyDinh)
        {
            int soNgayTre = Math.Max(0, (DateTime.Today.Date - chiTiet.NgayTraDuKien.Date).Days);
            chiTiet.SoNgayTre = soNgayTre;
            decimal phatTreHen = (decimal)(soNgayTre * thamSo.DonGiaPhatMoiNgay);

            decimal phatHuHong = 0;
            var oldIds = (chiTiet.DanhSachIdLoiMuon ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var newIds = (chiTiet.DanhSachIdLoiTra ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var idStr in newIds)
            {
                if (!oldIds.Contains(idStr))
                {
                    if (int.TryParse(idStr, out int idLoi))
                    {
                        var quyDinh = listQuyDinh.FirstOrDefault(x => x.ID == idLoi);
                        if (quyDinh != null) phatHuHong += (chiTiet.DonGia * quyDinh.MucPhatPhanTram) / 100;
                    }
                }
            }
            chiTiet.TienPhat = phatTreHen + phatHuHong;
        }

        public static bool GiaHanPhieuMuon(int idPhieuMuon, DateTime hanTraMoi)
        {
            return MuonTraDAO.GiaHanPhieuMuon(idPhieuMuon, hanTraMoi);
        }

        // --- CÁC HÀM XÓA AN TOÀN ---

        public static bool XoaPhieuMuon(int id)
        {
            // Kiểm tra: Chỉ cho xóa phiếu chưa có sách nào được trả
            // Nếu đã trả 1 phần, việc xóa phiếu mượn sẽ làm mất lịch sử trả -> Không an toàn
            var chiTiet = LayChiTietPhieuMuon(id);
            if (chiTiet.Any(c => c.DaTra))
            {
                throw new Exception("Phiếu mượn này đã có sách được trả. Không thể xóa hoàn toàn.\nChỉ có thể xóa các phiếu chưa có giao dịch trả sách.");
            }

            return MuonTraDAO.XoaPhieuMuon(id);
        }

        public static bool XoaPhieuTra(int id)
        {
            // Xóa phiếu trả sẽ:
            // 1. Hồi phục trạng thái sách về "Đang mượn".
            // 2. Trừ tiền phạt của độc giả.
            return MuonTraDAO.XoaPhieuTra(id);
        }

        // Helper functions...
        public static BindingList<PhieuMuonDTO> LayTatCaPhieuMuon() => new BindingList<PhieuMuonDTO>(MuonTraDAO.LayDSPhieuMuon());
        public static BindingList<PhieuTraDTO> LayTatCaPhieuTra() => new BindingList<PhieuTraDTO>(MuonTraDAO.LayDSPhieuTra());
        public static PhieuMuonDTO? LayPhieuMuonTheoMa(string maPhieu) => MuonTraDAO.LayPhieuMuon(maPhieu, null);
        public static PhieuMuonDTO? LayPhieuMuonTheoID(int id) => MuonTraDAO.LayPhieuMuon(null, id);
        public static PhieuTraDTO? LayPhieuTraTheoID(int id) => MuonTraDAO.LayPhieuTra(id);
        public static BindingList<ChiTietPhieuMuonDTO> LayChiTietPhieuMuon(int id) => new BindingList<ChiTietPhieuMuonDTO>(MuonTraDAO.LayChiTietMuon(id));
        public static BindingList<ChiTietPhieuTraDTO> LayChiTietPhieuTra(int id) => new BindingList<ChiTietPhieuTraDTO>(MuonTraDAO.LayChiTietTra(id));
        public static ThamSoMuonTraDTO LayThamSoMuonTra() => MuonTraDAO.LayThamSoMuonTra();

        public static byte[] ExportPhieuMuonToExcel()
        {
            var data = MuonTraDAO.LayDSPhieuMuon();
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("DanhSachPhieuMuon");

            // Header
            ws.Cell(1, 1).Value = "Mã Phiếu";
            ws.Cell(1, 2).Value = "Mã Độc Giả";
            ws.Cell(1, 3).Value = "Tên Độc Giả";
            ws.Cell(1, 4).Value = "Ngày Mượn";
            ws.Cell(1, 5).Value = "Hạn Trả";
            ws.Cell(1, 6).Value = "Tổng Sách";
            ws.Cell(1, 7).Value = "Sách Chưa Trả";
            ws.Cell(1, 8).Value = "Tình Trạng";

            // Style Header
            var headerRange = ws.Range(1, 1, 1, 8);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Data
            int row = 2;
            foreach (var item in data)
            {
                ws.Cell(row, 1).Value = item.MaPhieuMuon;
                ws.Cell(row, 2).Value = item.MaDocGia;
                ws.Cell(row, 3).Value = item.HoTenDocGia;
                ws.Cell(row, 4).Value = item.NgayMuon;
                ws.Cell(row, 5).Value = item.NgayTraDuKien;
                ws.Cell(row, 6).Value = item.TongSach;
                ws.Cell(row, 7).Value = item.SoSachChuaTra;
                ws.Cell(row, 8).Value = item.TinhTrang;

                // Format Date
                ws.Cell(row, 4).Style.DateFormat.Format = "dd/MM/yyyy";
                ws.Cell(row, 5).Style.DateFormat.Format = "dd/MM/yyyy";

                row++;
            }

            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public static (List<PhieuMuonDTO> importedList, int fail) ImportPhieuMuonFromExcel(string filePath)
        {
            List<PhieuMuonDTO> importedList = new();
            int fail = 0;

            try
            {
                using var workbook = new XLWorkbook(filePath);
                var ws = workbook.Worksheet(1); // Lấy sheet đầu tiên
                var rows = ws.RangeUsed()?.RowsUsed();

                if (rows == null) return (importedList, 0);

                // Giả định file Excel có cột: Mã Độc Giả | Danh sách Mã sách (cách nhau bởi phẩy) | Ngày Trả Dự Kiến (Optional)
                // Bỏ qua header
                foreach (var row in rows.Skip(1))
                {
                    try
                    {
                        string maDocGia = row.Cell(1).GetValue<string>().Trim();
                        string strMaSach = row.Cell(2).GetValue<string>();

                        DateTime? hanTra = null;
                        if (!row.Cell(3).IsEmpty())
                        {
                            if (DateTime.TryParse(row.Cell(3).GetValue<string>(), out DateTime d))
                                hanTra = d;
                        }

                        if (string.IsNullOrEmpty(maDocGia) || string.IsNullOrEmpty(strMaSach))
                        {
                            fail++;
                            continue;
                        }

                        var listMaSach = strMaSach.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(s => s.Trim()).ToList();

                        var phieu = LapPhieuMuon(maDocGia, listMaSach, hanTra);
                        importedList.Add(phieu);
                    }
                    catch
                    {
                        fail++;
                    }
                }
            }
            catch (Exception)
            {
                throw; // Ném lỗi file (ví dụ file đang mở) để GUI xử lý
            }

            return (importedList, fail);
        }

        public static byte[] ExportPhieuTraToExcel()
        {
            var data = MuonTraDAO.LayDSPhieuTra();
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("LichSuTraSach");

            ws.Cell(1, 1).Value = "Mã Phiếu Trả";
            ws.Cell(1, 2).Value = "Mã Phiếu Mượn";
            ws.Cell(1, 3).Value = "Độc Giả";
            ws.Cell(1, 4).Value = "Ngày Trả";
            ws.Cell(1, 5).Value = "Số Sách Trả";
            ws.Cell(1, 6).Value = "Tổng Tiền Phạt";

            var headerRange = ws.Range(1, 1, 1, 6);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightGreen;

            int row = 2;
            foreach (var item in data)
            {
                ws.Cell(row, 1).Value = item.MaPhieuTra;
                ws.Cell(row, 2).Value = item.MaPhieuMuon;
                ws.Cell(row, 3).Value = item.HoTenDocGia;
                ws.Cell(row, 4).Value = item.NgayTra;
                ws.Cell(row, 5).Value = item.TongSachTra;
                ws.Cell(row, 6).Value = item.TongTienPhat;

                ws.Cell(row, 4).Style.DateFormat.Format = "dd/MM/yyyy HH:mm";
                ws.Cell(row, 6).Style.NumberFormat.Format = "#,##0";

                row++;
            }
            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public static (List<PhieuTraDTO> importedList, int fail) ImportPhieuTraFromExcel(string filePath)
        {
            List<PhieuTraDTO> importedList = new();
            int fail = 0;

            try
            {
                using var workbook = new XLWorkbook(filePath);
                var ws = workbook.Worksheet(1);
                var rows = ws.RangeUsed()?.RowsUsed();
                if (rows == null) return (importedList, 0);

                // Giả định file Excel Import Trả chỉ cần cột: Mã Phiếu Mượn
                // Hệ thống sẽ tự động trả tất cả sách còn lại của phiếu đó với tình trạng mặc định
                foreach (var row in rows.Skip(1))
                {
                    try
                    {
                        string maPhieuMuon = row.Cell(1).GetValue<string>().Trim();
                        if (string.IsNullOrEmpty(maPhieuMuon))
                        {
                            fail++;
                            continue;
                        }

                        // Gọi hàm overload xử lý trả qua mã phiếu
                        var phieuTra = LapPhieuTra(maPhieuMuon, out _);
                        importedList.Add(phieuTra);
                    }
                    catch
                    {
                        fail++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return (importedList, fail);
        }
    }
}