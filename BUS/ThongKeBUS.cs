using DTO;

namespace BUS
{
    public class ThongKeBUS
    {
        public static ThongKeDTO GetThongKeTongQuan()
        {
            return DAO.ThongKeDAO.GetThongKeTongQuan();
        }

        public static List<SachMuonNhieuDTO> GetTop5SachMuonNhieu()
        {
            return DAO.ThongKeDAO.GetTop5SachMuonNhieu();
        }

        public static List<DocGiaTichCucDTO> GetTop3DocGiaTichCuc()
        {
            return DAO.ThongKeDAO.GetTop3DocGiaTichCuc();
        }

        public static List<ThongKeMuonTheoThangDTO> GetThongKeTheoThang(int? nam = null)
        {
            return DAO.ThongKeDAO.GetThongKeTheoThang(nam);
        }

        public static List<ThongKeMuonTheoQuyDTO> GetThongKeTheoQuy(int? nam = null)
        {
            return DAO.ThongKeDAO.GetThongKeTheoQuy(nam);
        }

        public static int GetThongKeTheoKhoang(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
            {
                throw new Exception("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
            }

            return DAO.ThongKeDAO.GetThongKeTheoKhoang(tuNgay, denNgay);
        }
    }
}
