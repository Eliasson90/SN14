using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Labb_8.Models;


namespace Labb_8.Controllers
{
    public class ContactController : Controller
    {
     private IRepository _repository;

        public ContactController()
            : this(new Repository())
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
            var contact = _repository.GetAllContacts();         
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
                _repository.Add(contact);
                _repository.Save();

                TempData["success"] = "Kontkten sparad!";

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
                throw new HttpException(404, "Du begärde ett oglitigt GUID");
            }

            var contact = _repository.GetContactById(id.Value);
            if(contact == null)
            {
                throw new HttpException(404, "Kontakten du begärde finns inte eller har just blivit borttagen");
            }

            return View(contact);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_POST(Guid id)
        {
            var contactToUpdate = _repository.GetContactById(id);
            if(contactToUpdate == null)
            {
                throw new HttpException(404, "Du begärde ett oglitigt GUID");
            }

            if(TryUpdateModel(contactToUpdate, string.Empty, new string[] { "Email", "FirstName", "LastName" } ))
            {

                try
                {
                    _repository.Update(contactToUpdate);
                    _repository.Save();

                    TempData["success"] = string.Format("Uppdaterade {0} {1}", contactToUpdate.FirstName, contactToUpdate.LastName);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    //Snart....
                    TempData["error"] = string.Format("Misslyckades att uppdatera {0}", contactToUpdate.FirstName, contactToUpdate.LastName);
                }

            }
            return View(contactToUpdate);
          
        }


        [HttpGet]
        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                throw new HttpException(404, "Du begärde ett oglitigt GUID");
            }

            var contact = _repository.GetContactById(id.Value);
            if (contact == null)
            {
                throw new HttpException(404, "Kontakten du begärde finns inte eller har just blivit borttagen");
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(Guid id)
        {
            try
            {
                var contact = new Contact { ContactId = id };
                _repository.Delete(contact);
                _repository.Save();

                TempData["success"] = "Kontakt borttagen";
               
            }
            catch (Exception)
            {
                TempData["error"] = "Misslyckades att ta bort Kontakten";
                RedirectToAction("Delete", new { id = id });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var contacts = _repository.GetAllContacts()
                    .Where(x => x.LastName == search)
                    .ToList();


                ViewBag.VisaKnapp = true;
                return View("Index", contacts);
              
            }
            return View("Index");
        }
        

	}
}