using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibraryWebApi.Controllers
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<WriterModel> Writer { get; set; }
        public ICollection<BookCategoryModel> BookCategory { get; set; }
    }
}