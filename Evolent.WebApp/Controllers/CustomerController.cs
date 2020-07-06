using Evolent.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Evolent.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<ContactModel> contactsList;
            HttpResponseMessage response = GlobalVariables.httpClient.GetAsync("contact").Result;
            contactsList = response.Content.ReadAsAsync<IEnumerable<ContactModel>>().Result;
            return View(contactsList);

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new ContactModel());
        }
        [HttpPost]
        public ActionResult AddOrEdit(ContactModel custModel)
        {
          
                //HTTP POST
                var postTask = GlobalVariables.httpClient.PostAsJsonAsync<ContactModel>("contact", custModel);
                postTask.Wait();
                var result = postTask.Result;
            

            return RedirectToAction("Index");


        }

        public ActionResult EditContact(int id)
        {
            HttpResponseMessage response = GlobalVariables.httpClient.GetAsync("contact/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<ContactModel>().Result);
        }

        public ActionResult Update(ContactModel product)
        {
            var postTask = GlobalVariables.httpClient.PutAsJsonAsync<ContactModel>("contact", product);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            TempData["SuccessMessage"] = "Saved Successfully";
            return View(product);
        }

        public ActionResult DeleteContact(int id)
        {
            HttpResponseMessage response = GlobalVariables.httpClient.DeleteAsync("contact/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }


    }
}