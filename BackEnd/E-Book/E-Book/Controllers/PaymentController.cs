using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EBook.Models;
using EBook.Utils;

namespace EBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        SqlDbHelper bookDb = new SqlDbHelper();
        /*
        [HttpPost]
        public IActionResult Pay([FromBody] User user)
        {
            int result = bookDb.AddUser(user);
            return Ok(result);
        }
        */
        [HttpPost]
        public IActionResult Pay([FromBody] Card card)
        {

            int result = bookDb.AddCard(card);
            return Ok(result);
        }
    }
}
