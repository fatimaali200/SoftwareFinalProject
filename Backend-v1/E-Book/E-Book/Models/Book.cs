using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace EBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Edition { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }
        public string Image { get; set; }
        public bool Bought { get; set; } = false;
        public int BuyDate { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
