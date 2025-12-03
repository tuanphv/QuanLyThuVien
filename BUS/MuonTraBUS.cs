using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static PhieuMuonDTO LapPhieuMuon(string maDocGia, List<string> danhSachMaCuon)
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
            DateTime ngayTraDuKien = thamSo.SoNgayMuonToiDa > 0
                ? ngayMuon.AddDays(thamSo.SoNgayMuonToiDa)
                : ngayMuon;

            return MuonTraDAO.TaoPhieuMuonVaChiTiet(docGia, danhSachIdCuon, ngayMuon, ngayTraDuKien);
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
    }
}
