using AolPhones.Managers.Interfaces;
using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Implementations
{
    public class CustomerManager : ICustomerManager
    {
        public static List<Customer> CustomerDB = new List<Customer>();
        IUserManager userManager = new UserManager();
       
        private bool CustomerExist(string userName)
        {
            foreach(var customer in CustomerDB)
            {
                if(customer.UserName == userName)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Delete(string userName)
        {
            var customer = Get(userName);
            if(customer != null)
            {
                Console.WriteLine("customer deleted successfully");
                customer.IsDeleted = true;
                return true;
            }
            Console.WriteLine("customer not found");
            return false;
        }

        public Customer Get(string userName)
        {
            foreach(var customer in CustomerDB)
            {
                if(customer.UserName == userName)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return CustomerDB;
        }

        public Customer Register(string name, string email, string password, string userName,  string phoneNumber, string address)
        {
            var customerExist = CustomerExist(userName);
            if(customerExist == false)
            {
                User user = new User(UserManager.userDB.Count +1, name, email, password, userName, phoneNumber, address, 0, "customer", false);
                UserManager.userDB.Add(user);

                Customer customer = new Customer(CustomerDB.Count + 1,userName, false);
                CustomerDB.Add(customer);
                return customer;
            }
            return null;
        }

        public Customer Update(string name, string userName, string phoneNumber, string address)
        {
            
            var customer = Get(userName);
            if (customer != null)
            {
                if (customer.UserName == userName && customer.IsDeleted == false)
                {
                    var user = userManager.Get(userName);
                    user.Name = name;
                    user.PhoneNumber = phoneNumber;
                    user.Address = address;
                    Console.WriteLine($"{userName} , your name,phone number and address has been updated successfully");
                    return customer;
                }
            }
            Console.WriteLine($"{userName} not found!!!");
            return null;
        }
    }
}
