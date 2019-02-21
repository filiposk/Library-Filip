
using AutoMapper;
using DataAccesLayer;
using LibraryDAL;
using LibraryWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LibraryWebApi.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<BookModel, Book>();
            Mapper.CreateMap<Book, BookModel>();

            Mapper.CreateMap<BookCategoryModel, BookCategory>();
            Mapper.CreateMap<BookCategory, BookCategoryModel>();

            Mapper.CreateMap<WriterModel, Writer>();
            Mapper.CreateMap<Writer, WriterModel>();

            Mapper.CreateMap<UserModel, User>();
            Mapper.CreateMap<User, UserModel>();

            Mapper.CreateMap<AdminModel, Admin>();
            Mapper.CreateMap<Admin, AdminModel>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }

    }
}