using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = db.Skills.ToList();
            return View(values);
        } 

        
        

        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill model) 
        {
            db.Skills.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSkill(int id)
        {
            var skill = db.Skills.Find(id);
            return View("UpdateSkill", skill);
        }

        [HttpPost]

        public IActionResult UpdateSkill(Skill model)
        {
            var values = db.Skills.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var values = db.Skills.Find(id);
            db.Skills.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
