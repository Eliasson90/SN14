using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Bibliotek;


namespace SQL_Labb4.Controllers
{
    public class ContactController : Controller
    {
     
        // GET: /Products/
        [HttpGet]
        public ActionResult Index()
        {
            IList<Kund> kunder;
           using(var ctx = new Entities())
           {
               
               var kundboklan = (from K in ctx.Kunds
                             join L in ctx.Lans on K.KundId equals L.LanId
                             join B in ctx.Boks on K.KundId equals B.BokId
                             select new {K,L,B })
                            .ToList();

           }
           return View(kunder);
        }

    //    [HttpGet]
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "Email, FirstName, LastName")]Contact contact)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                _repository.Add(contact);
    //                _repository.Save();

    //                TempData["success"] = "Kontkten sparad!";

    //                return RedirectToAction("Index");
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            TempData["error"] = "Misslyckades med att spara, försök igen!";
    //        }

    //        return View(contact);
    //    }

    //    [HttpGet]
    //    public ActionResult Edit(Guid? id)
    //    {
    //        if (!id.HasValue)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
    //        }

    //        var contact = _repository.GetContactById(id.Value);
    //        if (contact == null)
    //        {
    //            return HttpNotFound();
    //        }

    //        return View(contact);
    //    }

    //    [HttpPost, ActionName("Edit")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit_POST(Guid id)
    //    {
    //        var contactToUpdate = _repository.GetContactById(id);
    //        if (contactToUpdate == null)
    //        {
    //            return HttpNotFound();
    //        }

    //        if (TryUpdateModel(contactToUpdate, string.Empty, new string[] { "Email", "FirstName", "LastName" }))
    //        {

    //            try
    //            {
    //                _repository.Update(contactToUpdate);
    //                _repository.Save();

    //                TempData["success"] = string.Format("Uppdaterade {0} {1}", contactToUpdate.FirstName, contactToUpdate.LastName);
    //                return RedirectToAction("Index");
    //            }
    //            catch (Exception)
    //            {
    //                //Snart....
    //                TempData["error"] = string.Format("Misslyckades att uppdatera {0}", contactToUpdate.FirstName, contactToUpdate.LastName);
    //            }

    //        }
    //        return View(contactToUpdate);

    //    }


    //    [HttpGet]
    //    public ActionResult Delete(Guid? id)
    //    {
    //        if (!id.HasValue)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
    //        }

    //        var contact = _repository.GetContactById(id.Value);
    //        if (contact == null)
    //        {
    //            return HttpNotFound();
    //        }

    //        return View(contact);
    //    }

    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirm(Guid id)
    //    {
    //        try
    //        {
    //            var contact = new Contact { ContactId = id };
    //            _repository.Delete(contact);
    //            _repository.Save();

    //            TempData["success"] = "Kontakt borttagen";

    //        }
    //        catch (Exception)
    //        {
    //            TempData["error"] = "Misslyckades att ta bort Kontakten";
    //            RedirectToAction("Delete", new { id = id });
    //        }

    //        return RedirectToAction("Index");
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Search(string search)
    //    {
    //        if (!string.IsNullOrEmpty(search))
    //        {
    //            var contacts = _repository.GetAllContacts()
    //                .Where(x => x.LastName == search)
    //                .ToList();


    //            ViewBag.VisaKnapp = true;
    //            return View("Index", contacts);

    //        }
    //        return View("Index");
    //    }


    }
}