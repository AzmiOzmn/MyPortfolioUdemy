using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class ExperinceController : Controller
	{
		MyPortfolioContext db = new MyPortfolioContext();
		public IActionResult ExperienceList()
		{
			var values = db.Experiences.ToList();
			return View(values);
		}

		public IActionResult CreateExperience()
		{
			return View();
		}


		[HttpPost]
		public IActionResult CreateExperience(Experience model)
		{
			db.Experiences.Add(model);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
