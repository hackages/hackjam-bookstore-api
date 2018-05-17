using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreWebApi.Dto;
using BookstoreWebApi.Entities;

namespace BookstoreWebApi.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<Book> ToBooks(this IQueryable<BookEntity> @this) => @this.Select(entity => new Book {Category = entity.Isbn, Isbn = entity.Id.ToString()});
    }
}
