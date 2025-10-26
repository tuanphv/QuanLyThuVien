using System.Collections.Generic;
using DTO;
using DAO;
using System.ComponentModel;

namespace BUS
{
    public class BookBUS
    {
        public static BindingList<BookDTO> GetAllBooks()
        {
            return BookDAO.GetAllBooks();
        }

        public static bool AddBook(BookDTO book)
        {
            if (string.IsNullOrWhiteSpace(book.TieuDe) || book.GiaSach <= 0)
                return false;

            return BookDAO.AddBook(book);
        }

        public static bool UpdateBook(BookDTO book)
        {
            if (book.MaSach <= 0)
                return false;

            return BookDAO.UpdateBook(book);
        }

        public static bool DeleteBook(int maSach)
        {
            if (maSach <= 0)
                return false;

            return BookDAO.DeleteBook(maSach);
        }

        //Trí thêm
        public static BookDTO GetBookById(int maSach)
        {
            return BookDAO.GetBookById(maSach);
        }
    }
}
