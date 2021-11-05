using Laboratoria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_laby.Controllers
{
    public class BookController : Controller
    {
        static List<Book> books = new List<Book>();
        private static int index = 0;
        public IActionResult Index()
        {
            return View(books);
        }
        public IActionResult AddForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book Book)
        {
            if (ModelState.IsValid)
            {
                index++;
                Book.Id = index;
                books.Add(Book);
                return View("ConfirmBook", Book);
            }
            else
                return View("AddForm");
        }
        public IActionResult List()
        {
            return View(books);
        }
        public IActionResult EditForm(int id)
        {
            return View(FindBook(id));
        }
        [HttpPost]
        public IActionResult Edit(Book editedBook)
        {
            if (ModelState.IsValid)
            {
                Book originalBook = FindBook(editedBook.Id);
                originalBook.Author = editedBook.Author;
                originalBook.Title = editedBook.Title;
                originalBook.PublishingYear = editedBook.PublishingYear;
                return View("List", books);
            }
            else
                return View("EditForm");
        }
        public IActionResult DeleteConfirm(int id)
        {
            return View(FindBook(id));
        }
        public IActionResult Delete(int id)
        {
            books.Remove(FindBook(id));
            return View("List", books);
        }
        public Book FindBook(int id)
        {
            foreach (var book in books)
            {
                if (book.Id == id)
                    return book;
            }
            throw new Exception("Nie ma takiej książki");
        }
    }
}