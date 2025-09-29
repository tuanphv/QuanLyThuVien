namespace BUS
{
    public class LibraryCardBUS
    {
        public static List<DTO.LibraryCardDTO> GetAllLibraryCards()
        {
            return DAO.LibraryCarDAO.GetAllLibraryCards();
        }
    }
}
