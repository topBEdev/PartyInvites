using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Diagnostics;
using System;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            ViewBag.Date = DateTime.Now.ToString();
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(item => item.WillAttend == true));
        }
    }
}