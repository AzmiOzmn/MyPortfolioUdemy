using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioContext context = new();
        public IActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateAbout(About model)
        {
            context.Abouts.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            var values = context.Abouts.Find(id);
            context.Abouts.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult UpdateAbout(int id) 
        { 
            var values = context.Abouts.Find(id);
            return View(values);
        }

        [HttpPost]

        public IActionResult UpdateAbout(About model)
        {
            context.Abouts.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
