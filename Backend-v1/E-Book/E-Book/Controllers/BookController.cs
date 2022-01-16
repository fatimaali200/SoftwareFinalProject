using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EBook.Models;
using EBook.Utils;
using System.IO;

namespace EBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        SqlDbHelper bookDb = new SqlDbHelper();

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            Book book = bookDb.GetBook(id);

            return book;
        }

        [HttpGet("/image/{id}")]
        public ActionResult<Book> GetImage(string id)
        {

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", id);
            MemoryStream stream = new MemoryStream();
           
            using (var fs = System.IO.File.Open(path, FileMode.Open))
            {
                fs.CopyTo(stream);
            }
        
            stream.Position = 0; //reset memory stream position.

            return File(stream, "image/jpeg");
        }

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            List<Book> books = new List<Book>();
            books = bookDb.GetBooks();
            /*List<book> books = new List<book>()
            {
                new book()
                {
                    Price = 10,
                    Description = "test test test",
                    Img = "photo"
                },
                new book()
                {
                    Price = 10,
                    Description = "test test test",
                    Img = "photo"
                },
                new book()
                {
                    Price = 10,
                    Description = "test test test",
                    Img = "photo"
                }
            };*/
            return books;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Book>> GetBoughtBooks()
        {
            List<Book> books = new List<Book>();
            books = bookDb.GetBooks().Where(t => t.Bought == true).ToList();
            
            return books;
        }

        [HttpPost]
        public IActionResult AddBook([FromForm] Book book)
        {
            if (book.ImageFile != null)
            {
                string imageName = SaveImage(book.ImageFile);
                book.Image = imageName;
            }

            int result = bookDb.AddBook(book);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateBook([FromForm] Book book)
        {
            if (book.ImageFile != null)
            {
                string imageName = SaveImage(book.ImageFile);
                book.Image = imageName;
            }
            int result = bookDb.UpdateBook(book);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            int result = bookDb.DeleteBook(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public void Buybook(int id)
        {
            Book book = bookDb.GetBook(id);
            book.BuyDate = DateTime.UtcNow.Day;
            book.Bought = true;
            bookDb.UpdateBook(book);
        }

        [Route("[action]/{id}")]
        public IActionResult CancelBook(int id)
        {
            Book book = bookDb.GetBook(id);
            if(book.BuyDate - DateTime.UtcNow.Day < 5)
            {
                book.Bought = false;
                bookDb.UpdateBook(book);
                return Ok();
            }
            return BadRequest();
            
        }
        private string SaveImage(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();

                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                string imageName = $"{Guid.NewGuid().ToString()}-{file.FileName}";

                string path = Path.Combine(dir, imageName);

                Directory.CreateDirectory(dir);

                System.IO.File.WriteAllBytes(path, fileBytes);

                return imageName;
            }
        }
    }
}
