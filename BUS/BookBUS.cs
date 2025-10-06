using System.Collections.Generic;
using DTO;
using DAO;

namespace BUS
{
    public class BookBUS
    {
        public List<BookDTO> GetAllBooks()
        {
            return BookDAO.GetAllBooks();
        }

        public bool AddBook(BookDTO book)
        {
            if (string.IsNullOrWhiteSpace(book.TieuDe) || book.GiaSach <= 0)
                return false;

            return BookDAO.AddBook(book);
        }

        public bool UpdateBook(BookDTO book)
        {
            if (book.MaSach <= 0)
                return false;

            return BookDAO.UpdateBook(book);
        }

        public bool DeleteBook(int maSach)
        {
            if (maSach <= 0)
                return false;

            return BookDAO.DeleteBook(maSach);
        }
    }
}
