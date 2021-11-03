using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratoria.Models;

namespace Laboratoria.Controllers
{
    public class BookController : Controller
    {
        static List<Book> books = new List<Book>();
        public IActionResult Index()
        {
            return View(books);
        }
        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(books);
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            books.Add(book);
            return View("ConfirmBook", book);
        }
    }
}
