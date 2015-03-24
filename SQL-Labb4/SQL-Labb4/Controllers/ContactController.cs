using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Bibliotek;
using SQL_Labb4.Models;


namespace SQL_Labb4.Controllers
{
    public class ContactController : Controller
    {
     
        // GET: /Products/
        [HttpGet]
        public ActionResult Index()
        {
            IList<KundVyModell> kunderMedLan;
            using (var ctx = new BibliotekDbEntities1())
            {


                var lanPerKund = from k in ctx.Kunds
                                 join l in ctx.Lans on k.KundId equals l.kundId
                                 where l.LamnasTillbaka.HasValue
                                 group k by k.KundId into grp
                                 select new { key = grp.Key, Count = grp.Count() };


                 kunderMedLan = (from k in ctx.Kunds
                                    join lk in lanPerKund on k.KundId equals lk.key into lks
                                    from lk in lks.DefaultIfEmpty()
                                    select new KundVyModell { KundId = k.KundId, ForNamn = k.ForNamn, EfterNamn = k.EfterNamn, TelefonNr = k.TelefonNr, Email = k.Email, AntalLan = lk == null ? 0 : lk.Count })
                                   .ToList();


            }
          return View(kunderMedLan);
      
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            KundVyModell kund;
            using (var ctx = new BibliotekDbEntities1())
            {
                
                var kundBoker = (from l in ctx.Lans
                                     join k in ctx.Kopias on l.KopiaId equals k.KopiaId
                                     join b in ctx.Boks on k.BokId equals b.BokId
                                     where l.LamnasTillbaka.HasValue && l.kundId == id  // parameter till frågan...
                                     select new KundBokModell{BokId = b.BokId, Titel= b.Titel, LaneDatum = l.LaneDatum, LamnasTillbaka = l.LamnasTillbaka })
                                    .ToList();

                 kund = (from k in ctx.Kunds
                           where k.KundId == id
                           select new KundVyModell
                           {
                               KundId = k.KundId,
                               ForNamn = k.ForNamn,
                               EfterNamn = k.EfterNamn,
                               TelefonNr = k.TelefonNr,
                               Email = k.Email

                           }).FirstOrDefault();

                if(kund != null)
                {
                    kund.Boker = kundBoker;
                }


            }

            return View(kund);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            TaBortKundModell delete;
            using (var ctx = new BibliotekDbEntities1())
            {


                var harLan = (from l in ctx.Lans
                              join k in ctx.Kopias on l.KopiaId equals k.KopiaId
                              where l.kundId == id && k.Status > 1
                              select l).Any();

                    delete = (from k in ctx.Kunds
                              where k.KundId == id
                              select new TaBortKundModell
                              {
                                  KundId = k.KundId,
                                  ForNamn = k.ForNamn,
                                  EfterNamn = k.EfterNamn,
                                  HarLan = harLan
                              }).FirstOrDefault();
                                                  
            }
            return View(delete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
               using (var ctx = new BibliotekDbEntities1())
               {
                   var harLan = (from l in ctx.Lans
                                 join k in ctx.Kopias on l.KopiaId equals k.KopiaId
                                 where l.kundId == id && k.Status > 1
                                 select l).Any();

                   if(harLan)
                   {
                       throw new InvalidOperationException();
                   }
                   ctx.DeleteKund(id);
               }

            }
            catch (Exception)
            {
                TempData["error"] = "Misslyckades att ta bort Kontakten";
                RedirectToAction("Delete", new { id = id });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Lana()
        {
            using (var ctx = new BibliotekDbEntities1())
            {

            }
            return View();
        }

    }
}