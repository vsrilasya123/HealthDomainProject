using EvolentHealth.Business.Services;
using EvolentHealth.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Evolent.WebApi.Controllers
{
    public class ContactController : ApiController
    {
        private ICustomerService _customerService;

        public ContactController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Contact

        public IEnumerable<Customer> GetAllContacts()
        {
            
            return _customerService.LoadAllContacts();
        }

        // GET: api/Contact/5
        [HttpGet]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetContactById(int id)
        {
            //Customer customer = db.Customers.Find(id);
            Customer customer = _customerService.GetContactById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Contact/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(Customer customer)
        {

              _customerService.UpdateContact(customer);
            //if (custItem != null)
            //{
            //    custItem.First_Name = customer.First_Name;
            //    custItem.Last_Name = customer.Last_Name;
            //    custItem.Email_Id = customer.Email_Id;
            //    custItem.Phone_Number = customer.Phone_Number;
            //    custItem.Status = customer.Status;
            //}

            //}
            //catch (Exception)
            //{
            //    status = false;
            //}
            //return status;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{

            //    throw;

            //}

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contact
        [HttpPost]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _customerService.CreateContact(customer);
            return CreatedAtRoute("DefaultApi", new { id = customer.Customer_Id }, customer);
        }

        // DELETE: api/Contact/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteContact(id);
            return Ok();
        }
    }
}
