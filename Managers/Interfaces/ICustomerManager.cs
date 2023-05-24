using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Interfaces
{
    public interface ICustomerManager
    {
        public Customer Register(string name, string email, string userName, string password, string phoneNumber, string address);
        public Customer Get(string userName);
        public List<Customer> GetAll();
        public Customer Update(string name, string userName, string phoneNumber, string address);
        public bool Delete(string userName);
    }
}
