using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApi.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Isbn { get; set; }
    }

}
