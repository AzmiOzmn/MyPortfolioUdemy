﻿using Microsoft.AspNetCore.Mvc;
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

		public IActionResult ChangeIsReadToTrue(int id)
		{
			var values = context.Messages.Find(id);
			values.IsRead = true;
			context.SaveChanges();
			return RedirectToAction("Inbox");

		}

        public IActionResult ChangeIsReadToFalse(int id)
        {
            var values = context.Messages.Find(id);
            values.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");

        }

		public IActionResult Delete(int id)
		{
			var values = context.Messages.Find(id);
			context.Messages.Remove(values);
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult MessageDetail(int id)
		{
			var value = context.Messages.Find(id);
			return View(value);
		}
    }
}
