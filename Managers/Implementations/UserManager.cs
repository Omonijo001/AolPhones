using AolPhones.Managers.Interfaces;
using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Implementations
{
    public class UserManager : IUserManager
    {
        public static List<User> userDB = new List<User>()
        {
            new User(1,"ade", "ade@gmail.com", "1234", "ade1234", "09080706050", "abeokuta", 0, "SuperAdmin", false)
        };

        private bool Exist(string userName)
        {
            foreach (var user in userDB)
            {
                if(user.UserName == userName && user.IsDeleted == false)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Delete(string userName)
        {
            var user = Get(userName); 
            if(user == null)
            {
                Console.WriteLine($"{userName} not found");
                return false;
            }
            else
            {
                Console.WriteLine($"{userName} deleted successfully ");
                user.IsDeleted = true;
                return true;
            }
        }

        public User FundWallet(string userName, double amount)
        {
            var user = Get(userName);
            if(user != null)
            {
                if(user != null && amount > 0)
                {
                    user.Wallet += amount;
                    Console.WriteLine($"{userName}, you fund {amount} to your wallet and your account balance is {user.Wallet}");
                    return user;
                }
                else if (user != null && amount <= 0)
                {
                    Console.WriteLine("Invalid amount");
                    Console.WriteLine("Kindly Enter a valid Amount");
                    return null;

                }
            }
            Console.WriteLine($"{userName} not found!!!");
            return null;
        }

        public User Get(int id)
        {
            foreach(var user in userDB)
            {
                if (user.Id == id && user.IsDeleted == false)
                {
                    return user;
                }
            }
            return null;
        }

        public User Get(string userName)
        {
            foreach (var user in userDB)
            {
                if (user.UserName == userName && user.IsDeleted == false)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            return userDB;
        }

        public User Login(string userName, string password)
        {
            var user = Get(userName);
            if (user != null)
            {
                if(user.UserName == userName && user.Password == password && user.IsDeleted == false)
                {
                    Console.WriteLine("Login Successfull");
                    return user;
                }
            }
            Console.WriteLine($"{userName} not found!!!");
            return null;
        }

        public User Update(string userName, string name, string phoneNumber, string address)
        {
            var user = Get(userName);
            if(user != null)
            {
                if (user.UserName == userName && user.IsDeleted == false)
                {
                    user.Name = name;
                    user.PhoneNumber = phoneNumber;
                    user.Address = address;
                    Console.WriteLine($"{userName} your name, phoneNumber and address has been updated");
                    return user;
                }
            }
            Console.WriteLine($"{userName} not found!!!");
            return null;
        }
    }
}
