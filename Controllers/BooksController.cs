using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookApi.Models;
using System.Net.Http;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static string mmm ="444";
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
       


        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //        public async Task<ActionResult<Book>> PostBook(Book book)
        public async Task<ActionResult<Book>> PostBookAsync()

        {
            Book book = new Book();

            var client = new HttpClient();
            Console.WriteLine("Hello");

            var factory = new ConnectionFactory() {
                HostName = "localhost",
                Port = 31672
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                string timestamp = "";

                var consumer = new EventingBasicConsumer(channel);
                 consumer.Received +=  (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);


                  

                   

                    Console.WriteLine(" Press [enter] to exit.");




                };

                string timeStamp = "3443";
                book.Id = timeStamp;
                book.USDRATE = "44";
                book.UpdatedTime = "4";
                book.ChartName = mmm;
                book.USDRATEFLOAT = "33";
                try
                {
                    _context.Books.Add(book);

                    await _context.SaveChangesAsync();
                    Thread.Sleep(6000);

                }
                catch (DbUpdateException)
                {

                    throw;

                }
                Thread.Sleep(6000);


                return book;
            }

        }

        private string GetTimestamp(DateTime now)
        {
            throw new NotImplementedException();
        }
    }

        
    }
