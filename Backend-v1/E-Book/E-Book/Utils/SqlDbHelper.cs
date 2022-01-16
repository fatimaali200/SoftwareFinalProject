using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using EBook.Models;

namespace EBook.Utils
{
    public class SqlDbHelper
    {
        private readonly MySqlConnection _conn;
        private string _connectionString = "Server=localhost;Database=EBook;Uid=root;Pwd=.916814.;";

        public SqlDbHelper()
        {

            _conn = new MySqlConnection(_connectionString);
        }

        public Book GetBook(int id)
        {
            var sql = "SELECT * FROM Book";
            var result = _conn.Query<Book>(sql).ToList();
            var value = result.Find(x => x.Id == id);
            return value;
        }

        public List<Book> GetBooks()
        {
            var sql = "SELECT * FROM Book";
            var result = _conn.Query<Book>(sql).ToList();
            return result;
        }
        public int AddBook(Book book)
        {
            string sql = "INSERT INTO book (name, price, amount, author ,edition ,description , image, bought) Values (@Name, @Price, @Amount, @Author,@Edition ,@Description , @Image, @Bought);";
            var result = _conn.Execute(sql, book);
            return result;
        }

        public int UpdateBook(Book book)
        {
            string sql = "UPDATE book Set id=@Id, price=@Price, amount=@Amount, author=@Author,name=@Name ,edition=@Edition , image=@Image, bought=@Bought, description=@Description WHERE id=@Id";
            var result = _conn.Execute(sql, book);
            return result;
        }
        public int DeleteBook(int id)
        {
            string sql = "DELETE FROM book WHERE id = @Id;";
            var result = _conn.Execute(sql, new { Id = id });
            return result;
        }
        /*
        public int AddUser(User user)
        {
            string sql = "INSERT INTO user (name, surname, birthDate, email, phoneNumber, tc) Values (@Name, @Surname, @BirthDate, @Email, @PhoneNumber, @Tc);";
            var result = _conn.Execute(sql, user);
            return result;
        }
        */
        public int AddCard(Card card)
        {
            string sql = "INSERT INTO card (cardNumber, fullName, month, year, cvv) Values (@CardNumber, @FullName, @Month, @Year, @Cvv);";
            var result = _conn.Execute(sql, card);
            return result;
        }
    }
}
