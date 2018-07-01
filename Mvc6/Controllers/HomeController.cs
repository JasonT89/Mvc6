using System;
using System.Web.Mvc;

namespace Mvc6.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Fevercheck()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FeverCheck(float? temperature, string useFarenheit)
        {
            if (temperature != null)
            {
                ViewData["temps"] = temperature;

                if (!useFarenheit.Equals("C"))
                {
                    ViewData["useFarenheit"] = true;
                }
                else
                {
                    ViewData["useFarenheit"] = false;
                }

                return View();
            }

            return View();
        }

        
        public ActionResult GuessingGame()
        {
            Session["randomNumber"] = new Random().Next(0, 100);

            return View();
        }

        [HttpPost]
        public ActionResult GuessingGame(int? numberguess)
        {

            if (!numberguess.HasValue)
            {
                Session.Remove("timesGuessed");
                Session["displayError"] = "The game was reset because a number was not provided";
                return RedirectToAction("GuessingGame");
            }

            Session["displayError"] = null;

            if (Session["timesGuessed"] != null)
            {
                Session["timesGuessed"] = Convert.ToInt32(Session["timesGuessed"]) + 1;
            }
            else
            {
                Session["timesGuessed"] = 1;
            }
            return View(numberguess);
        }
    }
}