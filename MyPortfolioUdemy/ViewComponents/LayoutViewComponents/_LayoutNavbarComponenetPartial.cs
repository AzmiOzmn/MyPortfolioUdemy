using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponenetPartial : ViewComponent
	{
		 MyPortfolioContext context = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.toDoListCount=context.ToDoLists.Where(a=>a.Status == false).Count();
			var values = context.ToDoLists.Where(a=>a.Status==false).ToList();	
			return View(values);
		}
	}
}
