using DataAccesLayer;
using LibraryDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRUD
{
    public class BookCategoryCRUD
    {
        private FilipLibraryEntities DbContext;

        private BookCategoryCRUD()
        {
            DbContext = new FilipLibraryEntities();
        }

        public List<BookCategory> GetAllBooksCategory()
        {
            return this.DbContext.BookCategories.ToList();
        }

        public BookCategory GetBookCategory(int bookCategoryId)
        {
            return this.DbContext.BookCategories.Where(p => p.Id == bookCategoryId).FirstOrDefault();
        }

        public bool CreateBookCategory(BookCategory bookCategoryItem)
        {
            bool status;

            try
            {
                this.DbContext.BookCategories.Add(bookCategoryItem);
                this.DbContext.SaveChanges();
                status = true;
            }

            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateBookCategory(BookCategory bookCategoryItem)
        {
            bool status;

            try
            {
                BookCategory bookCategory = this.DbContext.BookCategories.Where(p => p.Id == bookCategoryItem.Id).FirstOrDefault();
                if (bookCategory != null)
                {
                    bookCategory.Id = bookCategoryItem.Id;
                    bookCategory.Name = bookCategoryItem.Name;

                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteBookCategory(int bookCategoryId)
        {
            bool status;
            try
            {
                BookCategory bookCategory = this.DbContext.BookCategories.Where(p => p.Id == bookCategoryId).SingleOrDefault();
                if (bookCategory != null)
                {
                    this.DbContext.BookCategories.Remove(bookCategory);
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
