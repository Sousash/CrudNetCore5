using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudNetCore5.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> listBooks = _context.Book;

            return View(listBooks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                _context.Add(b);
                _context.SaveChanges();

                TempData["mensaje"] = "Book has been created succesfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //get the book
            var book = _context.Book.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book b)
        {
            if (ModelState.IsValid)
            {
                _context.Update(b);
                _context.SaveChanges();

                TempData["mensaje"] = "Book has been updated succesfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //get the book
            var book = _context.Book.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // get the book
            var b = _context.Book.Find(id);

            if (b == null)
            {
                return NotFound();
            }

            
            _context.Remove(b);
            _context.SaveChanges();

            TempData["mensaje"] = "Book has been deleted succesfully";

            return RedirectToAction("Index");
        }

    }
}
