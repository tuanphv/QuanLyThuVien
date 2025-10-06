using System.Collections.Generic;
using LibraryManagement.DTO;
using LibraryManagement.DAO;

namespace LibraryManagement.BUS
{
    public class BookBUS
    {
        private BookDAO bookDAO = new BookDAO();

        public List<BookDTO> GetAllBooks()
        {
            return bookDAO.GetAllBooks();
        }

        public bool AddBook(BookDTO book)
        {
            if (string.IsNullOrWhiteSpace(book.TieuDe) || book.GiaSach <= 0)
                return false;
            return bookDAO.InsertBook(book);
        }

        public bool UpdateBook(BookDTO book)
        {
            if (book.MaSach <= 0)
                return false;
            return bookDAO.UpdateBook(book);
        }

        public bool DeleteBook(int maSach)
        {
            return bookDAO.DeleteBook(maSach);
        }
    }
}
