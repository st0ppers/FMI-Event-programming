using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
	public class GenresController : Controller
	{
		private readonly DatabaseContext _context;
		public GenresController(DatabaseContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var genres = await _context.Genres.ToListAsync();
			return View(genres);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddAndUpdateGenres request)
		{
			var genre = new Genre()
			{
				Name = request.Name,
			};

			await _context.Genres.AddAsync(genre);
			await _context.SaveChangesAsync();

			return RedirectToAction("Add");
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		//Get genre
		[HttpGet]
		public async Task<IActionResult> View(int id)
		{
			var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);

			if (genre == null) return View("Index");
			var model = new AddAndUpdateGenres()
			{
				Id = genre.Id,
				Name = genre.Name,
			};
			return await Task.Run(() => View("View", model));
		}

		//Update genre
		[HttpPost]
		public async Task<IActionResult> View(AddAndUpdateGenres request)
		{
			var genre = await _context.Genres.FindAsync(request.Id);

			if (genre == null) return RedirectToAction("Index");

			genre.Id = request.Id;
			genre.Name = request.Name;

			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		//Delet genre
		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var genre = await _context.Genres.FindAsync(id);

			if (genre == null) return RedirectToAction("Index");

			_context.Genres.Remove(genre);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}
