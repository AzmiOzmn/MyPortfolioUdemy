using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioContext context = new();
        public IActionResult Index()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }

        public IActionResult CreateContact()
        {
            return View();
        }


        [HttpPost]

        public IActionResult CreateContact(Contact model)
        {
            context.Contacts.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContact(int id)
        {
            var values = context.Contacts.Find(id);
            context.Contacts.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult UpdateContact(int id)
        {
            var values = context.Contacts.Find(id);
            return View(values);
        }

        public IActionResult UpdateContact(Contact model)
        {
            context.Contacts.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
