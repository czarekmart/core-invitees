using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
			var hour = DateTime.Now.Hour;
			ViewBag.Greeting = hour < 12 ? "Good Morning" : hour < 17 ? "Good Afternoon" : "Good Evening";
            return View("MyView");
        }
		[HttpGet]
		public ViewResult RsvpForm()
		{
			return View();
		}

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse response)
		{
			if(ModelState.IsValid)
			{
				Repository.AddResponse(response);
				return View("Thanks", response);
			}
			else
			{
				return View();
			}
		}

		public ViewResult ListResponses()
		{
			return View(Repository.Responses.Where(x=>x.WillAttend == true));
		}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

		//public IActionResult PageLength()
		//{
		//	return View(new Models.PageLength() { Address="www.fox.com", Length = 4588 });
		//}
		//}
		public async Task<ViewResult> PageLength()
		{
			var pl = new Models.PageLength() { Address = "http://www.foxnews.com/" };
			pl.Length = await Models.PageLength.GetPageLength(pl.Address) ?? 999;
			return View(pl);
		}
	}
}
