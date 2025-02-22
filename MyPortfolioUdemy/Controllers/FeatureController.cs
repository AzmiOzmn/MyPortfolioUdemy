using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class FeatureController : Controller
    {

        MyPortfolioContext context = new();
        public IActionResult Index()
        {
            var values = context.Features.ToList();
            return View(values);
        }

        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateFeature(Feature model)
        {
            context.Features.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateFeature(int id)
        {
            var values = context.Features.Find(id);
            return View(values);
        }



        [HttpPost]

        public IActionResult UpdateFeature(Feature model)
        {
            context.Features.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult DeleteFeature(int id)
        {
            var values = context.Features.Find(id);
            context.Features.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

       

       
    }
}
