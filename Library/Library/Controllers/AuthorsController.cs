using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Controllers
{
	public class AuthorsController : Controller
	{
		private readonly DatabaseContext _context;
		public AuthorsController(DatabaseContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var authors = await _context.Author.ToListAsync();
			return View(authors);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddAndUpdateAuthor request)
		{
			var author = new Author()
			{
				Name = request.Name,
			};

			await _context.Author.AddAsync(author);
			await _context.SaveChangesAsync();

			return RedirectToAction("Add");
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		//Get author
		[HttpGet]
		public async Task<IActionResult> View(int id)
		{
			var author = await _context.Author.FirstOrDefaultAsync(x => x.Id == id);

			if (author == null) return View("Index");
			var model = new AddAndUpdateAuthor()
			{
				Id = author.Id,
				Name = author.Name,
			};
			return await Task.Run(() => View("View", model));
		}

		//Update author
		[HttpPost]
		public async Task<IActionResult> View(AddAndUpdateAuthor request)
		{
			var author = await _context.Author.FindAsync(request.Id);

			if (author == null) return RedirectToAction("Index");

			author.Id = request.Id;
			author.Name = request.Name;

			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		//Delet author
		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var author = await _context.Author.FindAsync(id);

			if (author == null) return RedirectToAction("Index");

			_context.Author.Remove(author);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}
