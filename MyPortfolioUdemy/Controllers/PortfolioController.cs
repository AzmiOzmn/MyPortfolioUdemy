using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class PortfolioController : Controller
    {

        MyPortfolioContext context = new();
        public IActionResult Index()
        {
            var values = context.Portfolios.ToList();
            return View(values);
        }

        public IActionResult CreatePortfolio()
        {
            return View();
        }


        [HttpPost]

        public IActionResult CreatePortfolio(Portfolio db)
        {
            context.Portfolios.Add(db);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var portfolio = context.Portfolios.Find(id);
            context.Portfolios.Remove(portfolio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePortfolio(int id)
        {
            var portfolio = context.Portfolios.Find(id);
            return View("UpdatePortfolio", portfolio);
        }

        [HttpPost]

        public IActionResult UpdatePortfolio(Portfolio db)
        {
            var portfolio = context.Portfolios.Find(db.PortfolioId);
            context.Portfolios.Update(portfolio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
