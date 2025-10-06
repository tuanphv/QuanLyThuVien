using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class BookBUS
    {
        private readonly BookDAO bookDAO = new BookDAO();

        public List<BookDTO> GetAllBooks()
        {
            return bookDAO.GetAllBooks();
        }

        public bool AddBook(BookDTO book)
        {
            if (string.IsNullOrWhiteSpace(book.TieuDe) || book.GiaSach <= 0)
                return false;

            return bookDAO.AddBook(book);
        }

        public bool UpdateBook(BookDTO book)
        {
            if (book.MaSach <= 0)
                return false;

            return bookDAO.UpdateBook(book);
        }

        public bool DeleteBook(int maSach)
        {
            if (maSach <= 0)
                return false;

            return bookDAO.DeleteBook(maSach);
        }
    }
}
