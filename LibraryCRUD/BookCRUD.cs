using DataAccesLayer;
using LibraryDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRUD
{
    public class BookCRUD
    {
        public FilipLibraryEntities DbContext;

        public BookCRUD()
        {
            DbContext = new FilipLibraryEntities();
        }

        public List<Book> GetAllBooks()
        {
            return this.DbContext.Books.ToList();
        }

        public Book GetBook(int bookId)
        {
            return this.DbContext.Books.Where(p => p.Id == bookId).FirstOrDefault();
        }

        public bool CreateBook(Book bookItem)
        {
            bool status;

            try
            {
                this.DbContext.Books.Add(bookItem);
                this.DbContext.SaveChanges();
                status = true;
            }

            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateBook(Book bookItem)
        {
            bool status;

            try
            {
                Book book = this.DbContext.Books.Where(p => p.Id == bookItem.Id).FirstOrDefault();
                if (book != null)
                {
                    book.Id = bookItem.Id;
                    book.Name = bookItem.Name;
                    book.BookCategoryId = bookItem.BookCategoryId;
                    book.WriterId = bookItem.WriterId;
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteBook(int bookId)
        {
            bool status;
            try
            {
                Book book = this.DbContext.Books.Where(p => p.Id == bookId).SingleOrDefault();
                if (book != null)
                {
                    this.DbContext.Books.Remove(book);
                    this.DbContext.SaveChanges();
                }
                status = true;
            }

            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
