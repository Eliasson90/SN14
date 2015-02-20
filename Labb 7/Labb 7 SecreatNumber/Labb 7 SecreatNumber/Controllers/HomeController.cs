using Labb_7_SecreatNumber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labb_7_SecreatNumber.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var number = GetNumber();
            return View(number);
        }

        //GET:
        public ActionResult NewPage() 
        {
            GetNumber().Initialize();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(int? number)
        {
              if(Session.IsNewSession)
            {
                //detta är en ny, dvs efter timeoout
                // hanter fel enligt labb PM
                return View("SessionError");
            }
            

            var secretNumber = GetNumber();
            if(!number.HasValue)
            {              
                //om värde 0-100
                //kolla
               ModelState.AddModelError("number", "Ange ett tal");
                // är allt ok , och vi kan gå vidare....
               
            }
            else if (number < 1 || number > 100)
            {
                ModelState.AddModelError("number", "Gissningen misslyckades, rätta till felet och försök igen.");
                ModelState.AddModelError("number", "Talet måste vara mellan 1 och 100");
            }
            else
            {
                secretNumber.MakeGuess(number.Value);
            }

            
            return View(secretNumber);
        

        }

        private SecretNumber GetNumber()
        {
            var number = (SecretNumber)Session["Number"];
            if (number == null)
            {
                number = new SecretNumber();
                Session["Number"] = number;
            }
            return number;
        }
	}
}