using EvolentHealth.Data.DbEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
            private EvolentDB _context;

            public CustomerRepository(EvolentDB context)
            {
                this._context = context;
            }

            public IEnumerable<Customer> GetContacts()
            {
                return _context.Customers.ToList();
            }
            public Customer GetContactById(int customerId)
            {
                return _context.Customers.Find(customerId);
            }

            public void AddContact(Customer customer)
            {
            _context.Customers.Add(customer);
            }

            public void DeleteContact(int customerId)
            {
                Customer customer = _context.Customers.Find(customerId);
            _context.Customers.Remove(customer);
            }

            public void UpdateContact(Customer customer)
            {
            _context.Entry(customer).State = EntityState.Modified;
            
            }

            public void Save()
            {
            _context.SaveChanges();
            }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

    
    public interface ICustomerRepository :IDisposable
    {
        IEnumerable<Customer> GetContacts();
        Customer GetContactById(int customerId);
        void AddContact(Customer customer);
        void UpdateContact(Customer customer);
        void DeleteContact(int customerId);
        void Save();
    }
}
