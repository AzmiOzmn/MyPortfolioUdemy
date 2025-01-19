using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class ExperienceController : Controller
	{
		MyPortfolioContext db = new MyPortfolioContext();
		public IActionResult ExperienceList()
		{
			var values = db.Experiences.ToList();
			return View(values);
		}


		[HttpGet]
		public IActionResult CreateExperience()
		{
			return View();
		}


		[HttpPost]
		public IActionResult CreateExperience(Experience model)
		{
			db.Experiences.Add(model);
			db.SaveChanges();
			return RedirectToAction("ExperienceList");
		}

		public IActionResult DeleteExperience(int id)
		{
			var value = db.Experiences.Find(id);
			db.Experiences.Remove(value);
			db.SaveChanges();
			return RedirectToAction("ExperienceList");
		}


		[HttpGet]
		public ActionResult UpdateExperience(int id)
		{
			var value = db.Experiences.Find(id);
			return View(value);
		}



		[HttpPost]
		public ActionResult UpdateExperience(Experience model)
		{
			db.Experiences.Update(model);
			db.SaveChanges();
			return RedirectToAction("ExperienceList");
		}


	}

	}

