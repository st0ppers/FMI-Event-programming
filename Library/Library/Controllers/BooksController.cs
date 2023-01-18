using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
	public class BooksController : Controller
	{
		public readonly DatabaseContext _context;

		public BooksController(DatabaseContext cotnext)
		{
			_context = cotnext;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var books = await _context.Books.ToListAsync();
			return View(books);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		//Add book
		[HttpPost]
		public async Task<IActionResult> Add(AddAndUpdateBook request)
		{
			var book = new Book()
			{
				Pgaes = request.Pages,
				Price = request.Price,
				Title = request.Title,
				Author = request.Author,
				Genre = request.Genre,
				Id = request.Id
			};
			await _context.Books.AddAsync(book);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		//Get book
		[HttpGet]
		public async Task<IActionResult> View(int id)
		{
			var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

			if (book == null) return View("Index");
			var model = new AddAndUpdateBook()
			{
				Pages = book.Pgaes,
				Price = book.Price,
				Title = book.Title,
				Author = book.Author,
				Genre = book.Genre,
				Id = book.Id
			};
			return await Task.Run(() => View("View", model));
		}

		//Update book
		[HttpPost]
		public async Task<IActionResult> View(AddAndUpdateBook request)
		{
			var book = await _context.Books.FindAsync(request.Id);

			if (book == null) return RedirectToAction("Index");

			book.Pgaes = request.Pages;
			book.Price = request.Price;
			book.Title = request.Title;
			book.Author = request.Author;
			book.Genre = request.Genre;
			book.Id = request.Id;

			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		//Delet book
		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var book = await _context.Books.FindAsync(id);

			if (book == null) return RedirectToAction("Index");

			_context.Books.Remove(book);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}
