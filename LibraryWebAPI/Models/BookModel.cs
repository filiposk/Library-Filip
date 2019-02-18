using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApi.Controllers
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<UserModel> User { get; set; }
        public ICollection<BookCategoryModel> BookCategory { get; set; }
    }
}