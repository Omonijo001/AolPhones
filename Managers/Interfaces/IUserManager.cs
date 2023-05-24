using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Interfaces
{
    public interface IUserManager
    {
        public User Login(string userName, string password);
        public User Get(int id);
        public User Get(string userName);
        public List<User> GetAll();
        public User Update(string userName , string name, string phoneNumber, string address);
        public bool Delete(string userName);
        public User FundWallet(string userName, double amount);
    }
}
