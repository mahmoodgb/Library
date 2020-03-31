using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{    
    public class BooksController : Controller
    {
        public static ICollection<Book> books; //= new List<Book>();
        public BooksController()
        {
            books = new List<Book>
            {
                new Book{BookID = 1, FullTitle = "ASP.Net Core MVC 3.1", Price= 14, Type=BookType.New},
                new Book{BookID = 2, FullTitle = "JavaFX", Price= 18, Type=BookType.Used},
                new Book{BookID = 3, FullTitle = "C++ How to Program", Price= 22, Type=BookType.New}
            };
        }
        // GET: Books
        public ActionResult Index()
        {
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View(books.FirstOrDefault(b => b.BookID == id));
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View(new Book { Price = 15 });
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {            
            return View(books.FirstOrDefault(b => b.BookID == id));
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    books.Remove(books.FirstOrDefault(b => b.BookID == id));
                    books.Add(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View(books.FirstOrDefault(b => b.BookID == id));
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book model)
        {
            try
            {
                books.Remove(books.FirstOrDefault(b => b.BookID == id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}