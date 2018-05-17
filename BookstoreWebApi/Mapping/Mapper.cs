using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreWebApi.Dto;
using BookstoreWebApi.Entities;

namespace BookstoreWebApi.Mapping
{
    public class Mapper
    {
        public static BookEntity ToBookEntity(BookPatch book, BookEntity bookEntity)
        {
            bookEntity.Title = book.Title;
            return bookEntity;
        }

        public static Book ToBook(BookEntity bookEntity) => new Book { Title = bookEntity.Title, Category = bookEntity.Category, Isbn = bookEntity.Isbn};
    }
}
