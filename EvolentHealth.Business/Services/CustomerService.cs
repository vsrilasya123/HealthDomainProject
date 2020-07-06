using EvolentHealth.Data.DbEntities;
using EvolentHealth.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth.Business.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> LoadAllContacts();
        Customer GetContactById(int id);
        void CreateContact(Customer customer);
        void UpdateContact(Customer customer);
        void DeleteContact(int customerId);
        //void SaveContact();
    }

    public class CustomerService : ICustomerService
    {
        //  private UnitOfWork<EvolentHealthDBContext> unitOfWork = new UnitOfWork<EvolentHealthDBContext>();
        //private GenericRepository<Customer> repository;
        private ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
            //unitOfWork = unitOfWork;
        }

        #region ICustomerService Members

        public IEnumerable<Customer> LoadAllContacts()
        {
            return customerRepository.GetContacts();
        }

        public Customer GetContactById(int id)
        {
            return customerRepository.GetContactById(id);
        }

        public void CreateContact(Customer customer)
        {
            customerRepository.AddContact(customer);
        }

        public void UpdateContact(Customer customer)
        {
            customerRepository.UpdateContact(customer);
        }

        public void DeleteContact(int customerId)
        {
            customerRepository.DeleteContact(customerId);
        }

        #endregion
    }
}
