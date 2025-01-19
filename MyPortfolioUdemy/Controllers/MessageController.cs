using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
	public class MessageController : Controller
	{
		MyPortfolioContext context = new ();
		public IActionResult Inbox()
		{
			var values = context.Messages.ToList();
			return View(values);
		}
	}
}
