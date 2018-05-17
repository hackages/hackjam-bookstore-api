using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApi.Dto
{
    public class Book
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Isbn { get; set; }
    }
}
