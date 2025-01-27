using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class ToDoListController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.ToDoLists.ToList();
            return View(values);
        }

        public IActionResult CreateToDo()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateToDo(ToDoList model)
        {
            model.Status = false;
            context.ToDoLists.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteToDo(int id)
        {
            var values = context.ToDoLists.Find(id);
            context.ToDoLists.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateToDo(int id)
        {
            var value = context.ToDoLists.Find(id);
            return View(value);
        }


        [HttpPost]
        public IActionResult UpdateToDo(ToDoList model)
        {
           context.ToDoLists.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToDoListStatusTrue(int id)
        {
            var value = context.ToDoLists.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

		public IActionResult ChangeToDoListStatusFalse(int id)
		{
			var value = context.ToDoLists.Find(id);
			value.Status = false;
			context.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
