using DAO;
using DTO;

namespace BUS
{
    public class BaoCaoBUS
    {
        public static BaoCaoMuonTheoKhoangDTO GetBaoCaoTheoKhoang(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
            {
                throw new Exception("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!");
            }

            return BaoCaoDAO.GetBaoCaoTheoKhoang(tuNgay, denNgay);
        }

        public static List<BaoCaoQuaHanDTO> GetBaoCaoQuaHan()
        {
            return BaoCaoDAO.GetBaoCaoQuaHan();
        }

        public static List<BaoCaoTopSachDTO> GetTopSachMuonNhieu(int top = 10)
        {
            if (top <= 0 || top > 100)
            {
                throw new Exception("Số lượng top phải từ 1 đến 100!");
            }

            return BaoCaoDAO.GetTopSachMuonNhieu(top);
        }

        public static List<BaoCaoTopDocGiaDTO> GetTopDocGiaTichCuc(int top = 10)
        {
            if (top <= 0 || top > 100)
            {
                throw new Exception("Số lượng top phải từ 1 đến 100!");
            }

            return BaoCaoDAO.GetTopDocGiaTichCuc(top);
        }

        public static List<BaoCaoNoDocGiaDTO> GetBaoCaoNoDocGia()
        {
            return BaoCaoDAO.GetBaoCaoNoDocGia();
        }

        public static List<ChiTietSachQuaHanDTO> GetChiTietSachQuaHan(string maDocGia)
        {
            if (string.IsNullOrWhiteSpace(maDocGia))
            {
                throw new Exception("Mã độc giả không được để trống!");
            }

            return BaoCaoDAO.GetChiTietSachQuaHan(maDocGia);
        }
    }
}
