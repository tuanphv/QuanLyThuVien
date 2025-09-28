namespace BUS
{
    public class ReaderBUS
    {
        public static List<DTO.ReaderDTO> GetAllReaders()
        {
            return DAO.ReaderDAO.GetAllReaders();
        }
    }
}
