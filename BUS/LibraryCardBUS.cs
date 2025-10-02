namespace BUS
{
    public class LibraryCardBUS
    {
        public static List<DTO.LibraryCardDTO> GetAllLibraryCards()
        {
            return DAO.LibraryCarDAO.GetAllLibraryCards();
        }

        public static bool AddLibraryCard(DTO.LibraryCardDTO card)
        {
            return ValidateLibraryCard(card) && DAO.LibraryCarDAO.AddLibraryCard(card);
        }

        public static bool UpdateLibraryCard(DTO.LibraryCardDTO card)
        {
            return ValidateLibraryCard(card) && DAO.LibraryCarDAO.UpdateLibraryCard(card);
        }

        public static bool DeleteLibraryCard(int cardId)
        {
            if (cardId <= 0)
                return false;
            return DAO.LibraryCarDAO.DeleteLibraryCard(cardId);
        }

        private static bool ValidateLibraryCard(DTO.LibraryCardDTO card)
        {
            if (card.MaDocGia <= 0)
                return false;
            if (card.NgayCap == DateTime.MinValue || card.NgayCap > DateTime.Now)
                return false;
            if (card.NgayHetHan == DateTime.MinValue || card.NgayHetHan <= card.NgayCap)
                return false;
            if (string.IsNullOrWhiteSpace(card.TrangThai))
                return false;
            return true;
        }
    }
}
