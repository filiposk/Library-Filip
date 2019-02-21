using LibraryCRUD;
using LibraryDAL;
using LibraryWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;

namespace LibraryWebApi.Controllers
{
    public class ShowLibraryDatabaseController : ApiController
    {
        private BookCRUD _bookCRUD;

        private ShowLibraryDatabaseController(BookCRUD bookCRUD)
        {
            this._bookCRUD = bookCRUD;
        }
        // GET: ShowLibraryDatabase
        [HttpGet]
        public JsonResult<List<BookModel>> GetAllBooks()
        {
            EntityMapper<Book, BookModel> mapObj = new EntityMapper<Book, BookModel>();
            List<Book> bookList = _bookCRUD.GetAllBooks();
            List<BookModel> books = new List<BookModel>();
            foreach (var item in bookList)
            {
                books.Add(mapObj.Translate(item));
            }
            return Json<List<BookModel>>(books);
        }
        [HttpGet]
        public JsonResult<BookModel> GetBooks(int id)
        {
            EntityMapper<Book, BookModel> mapObj = new EntityMapper<Book, BookModel>();
            Book dalBook = _bookCRUD.GetBook(id);
            BookModel books = new BookModel();
            books = mapObj.Translate(dalBook);
            return Json<BookModel>(books);
        }
        [HttpPost]
        public bool InsertProduct(BookModel book)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<BookModel, Book> mapObj = new EntityMapper<BookModel, Book>();
                Book bookObj = new Book();
                bookObj = mapObj.Translate(book);
                status = _bookCRUD.CreateBook(bookObj);
            }
            return status;

        }
        [HttpPut]
        public bool UpdateProduct(BookModel book)
        {
            EntityMapper<BookModel, Book> mapObj = new EntityMapper<BookModel, Book>();
            Book bookObj = new Book();
            bookObj = mapObj.Translate(book);
            var status = _bookCRUD.UpdateBook(bookObj);
            return status;

        }
        [HttpDelete]
        public bool DeleteProduct(int id)
        {
            var status = _bookCRUD.DeleteBook(id);
            return status;
        }
    }
}
}