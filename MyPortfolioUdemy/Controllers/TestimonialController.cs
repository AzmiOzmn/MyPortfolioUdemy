using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }

        public IActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateTest(Testimonial model)
        {
            context.Testimonials.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTest(int id)
        {
            var values = context.Testimonials.Find(id);
            context.Testimonials.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult UpdateTest(int id)
        {
            var values = context.Testimonials.Find(id);
            return View(values);
        }

        [HttpPost]

        public IActionResult UpdateTest(Testimonial model)
        {
            context.Testimonials.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

