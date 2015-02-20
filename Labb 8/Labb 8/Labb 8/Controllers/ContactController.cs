using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Labb_8.Models;
using Labb_8.Models.Repository;

namespace Labb_8.Controllers
{
    public class ContactController : Controller
    {
     private IRepository _repository;

        public ContactController()
            : this(new XmlRepository())
        {
        }

        // mest för testning....
        public ContactController(IRepository repository)
        {
            _repository = repository;
        }

        
        // GET: /Products/
        public ActionResult Index()
        {
            var contact = _repository.GetContact();            
            return View(contact);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Email, FirstName, LastName")]Contact contact)
        {
            try 
	{	        
		if(ModelState.IsValid)
            {
                _repository.AddContact(contact);
                _repository.Save();

                TempData["success"] = "Produkten sparad!";

                return RedirectToAction("Index");
            }
	}
	catch (Exception)
	{
		
		TempData["error"] = "Misslyckades med att spara, försök igen!";
	}

            return View(contact);
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if(!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contact = _repository.GetContact(id.Value);
            if(contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_POST(Guid id)
        {
            var contactToUpdate = _repository.GetContact(id);
            if(contactToUpdate == null)
            {
                return HttpNotFound();
            }

            if(TryUpdateModel(contactToUpdate, string.Empty, new string[] { "Email", "FirstName", "LastNAme" } ))
            {

                try
                {
                    _repository.UpdateContact(contactToUpdate);
                    _repository.Save();

                    TempData["success"] = string.Format("Uppdaterade {0}", contactToUpdate.Name);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    //Snart....
                    TempData["error"] = string.Format("Misslyckades att uppdatera {0}", contactToUpdate.Name);
                }

            }
            return View(contactToUpdate);
          
        }


        [HttpGet]
        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contact = _repository.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(Guid id)
        {
            try
            {
                var contact = new Contact { Contactid = id };
                _repository.DeleteContact(contact);
                _repository.Save();

                TempData["success"] = "Produkt borttagen";
               
            }
            catch (Exception)
            {
                TempData["error"] = "Misslyckades att ta bort produkten";
                RedirectToAction("Delete", new { id = id });
            }

            return RedirectToAction("Index");
        }

	}
}