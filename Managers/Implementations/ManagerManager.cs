using AolPhones.Managers.Interfaces;
using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Implementations
{
    public class ManagerManager : IManagerManager
    {
        public static List<Manager> ManagerDB = new List<Manager>();
        IUserManager userManager = new UserManager();


        private bool ManagerExist(string userName)
        {
            foreach (var manager in ManagerDB)
            {
                if (manager.UserName == userName && manager.IsDeleted == false)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Delete(string userName)
        {
            var manager = Get(userName);
            if (manager != null)
            {
                Console.WriteLine("manager deleted successfully");
                manager.IsDeleted = true;
                return true;
            }
            Console.WriteLine("manager not found");
            return false;
        }

        public Manager Get(string userName)
        {
            foreach (var manager in ManagerDB)
            {
                if (manager.UserName == userName && manager.IsDeleted == false)
                {
                    return manager;
                }
            }
            return null;
        }

        public List<Manager> GetAll()
        {
            return ManagerDB;
        }

        public Manager Register(string name, string email, string password, string userName, string phoneNumber, string staffNumber, string address)
        {
            var managerExist = ManagerExist(userName);
            if (managerExist == false)
            {
                User user = new User(UserManager.userDB.Count + 1, name, email, password, userName, phoneNumber, address, 0, "Manager", false);
                UserManager.userDB.Add(user);

                Manager manager = new Manager(ManagerDB.Count + 1, userName, GenerateStaffNumber(), false);
                ManagerDB.Add(manager);
                return manager;
            }
            return null;
        }

        public Manager Update(string userName, string name, string phoneNumber, string address)
        {
            var manager = Get(userName);
            if (manager != null )
            {
                if (manager.UserName == userName && manager.IsDeleted == false)
                {
                    var user = userManager.Get(userName);
                    user.Name = name;
                    user.PhoneNumber = phoneNumber;
                    user.Address = address;
                    Console.WriteLine("Details updated successfully");
                    return manager;
                }
            }
            Console.WriteLine($"{userName} not found!!!");
            return null;
        }

        private string GenerateStaffNumber()
        {
            Random rand = new Random();
            var abc = rand.Next(1000, 9999);
            return $"AOL/MG/{abc}";
        }
    }
}
