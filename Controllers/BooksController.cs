﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryCollectionWebApplication.Data;
using LibraryCollectionWebApplication.Models;
using LibraryCollectionWebApplication.Models.ViewModels;
using LibraryCollectionWebApplication.Migrations;

namespace LibraryCollectionWebApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryWebAppContext _context;

        public BooksController(LibraryWebAppContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var libraryWebAppContext = _context.Books.Include(b => b.Category).Include(b => b.User);
            return View(await libraryWebAppContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Description,Price,Worth,CategoryId,UserId")] BookUpdateViewModel bookUpdate)
        {
            decimal newPrice;
            decimal newWorth;
            try
            {
                newPrice = System.Convert.ToDecimal(bookUpdate.Price);
                newWorth = System.Convert.ToDecimal(bookUpdate.Worth);
            }
            catch (Exception)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                Book CreateBook = new Book()
                {
                    Id = bookUpdate.Id,
                    Title = bookUpdate.Title,
                    Author = bookUpdate.Author,
                    Description = bookUpdate.Description,
                    Price = newPrice,
                    Worth = newWorth,
                    CategoryId = bookUpdate.CategoryId,
                    UserId = bookUpdate.UserId
                };
                _context.Add(CreateBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", bookUpdate.UserId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", bookUpdate.CategoryId);
            return View(bookUpdate);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            BookUpdateViewModel viewModel = new()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price?.ToString(),
                Worth = book.Worth?.ToString(),
                CategoryId = book.CategoryId,
                UserId = book.UserId,
            };
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", viewModel.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", viewModel.UserId);
            return View(viewModel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Description,Price,Worth,CategoryId,UserId")] BookUpdateViewModel bookUpdate)
        {
            if (id != bookUpdate.Id)
            {
                return NotFound();
            }

            decimal newPrice;
            decimal newWorth;
            try
            {
                newPrice = System.Convert.ToDecimal(bookUpdate.Price);
                newWorth = System.Convert.ToDecimal(bookUpdate.Worth);
            }
            catch (Exception)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Book bookEdit = await _context.Books.FindAsync(id);
                    bookEdit.Title = bookUpdate.Title;
                    bookEdit.Author = bookUpdate.Author;
                    bookEdit.Description = bookUpdate.Description;
                    bookEdit.Price = newPrice;
                    bookEdit.Worth = newWorth;
                    bookEdit.CategoryId = bookUpdate.CategoryId;
                    bookEdit.UserId = bookUpdate.UserId;
                    _context.Update(bookEdit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(bookUpdate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookUpdate);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'LibraryWebAppContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
