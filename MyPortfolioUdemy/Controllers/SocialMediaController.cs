using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class SocialMediaController : Controller
    {

        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }

        public IActionResult CreateSocial()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateSocial(SocialMedia model)
        {
            context.SocialMedias.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocial(int id)
        {
            var values = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult UpdateSocial(int id)
        {
            var values = context.SocialMedias.Find(id);
            return View(values);
        }

        [HttpPost]

        public IActionResult UpdateSocial(SocialMedia model)
        {
            context.SocialMedias.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
