using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreWebApi
{
    public class BookStoreContext : DbContext
    {
      
        public DbSet<BookEntity> Books { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

    }
}
