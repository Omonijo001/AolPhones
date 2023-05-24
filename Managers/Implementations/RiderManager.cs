using AolPhones.Managers.Interfaces;
using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AolPhones.Managers.Implementations
{
    public class RiderManager : IRiderManager
    {
        public static List<Rider> riderDB = new List<Rider>();
        IUserManager userManager = new UserManager();
        IProductManager productManager = new ProductManager();

        private bool RiderExist(string userName)
        {
            foreach (var rider in riderDB)
            {
                if (rider.UserName == userName && rider.IsDeleted == false)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Delete(string userName)
        {
            var rider = Get(userName);
            if (rider != null)
            {
                Console.WriteLine("rider deleted successfully");
                rider.IsDeleted = true;
                return true;
            }
            Console.WriteLine("rider not found");
            return false;
        }

        public Rider Get(int id)
        {
            foreach(var rider in riderDB)
            {
                if (rider.Id == id && rider.IsDeleted == false)
                {
                    return rider;
                }
            }
            return null;
        }

        public Rider Get(string userName)
        {
            foreach (var rider in riderDB)
            {
                if (rider.UserName == userName && rider.IsDeleted == false)
                {
                    return rider;
                }
            }
            return null;
        }

        public List<Rider> GetAll()
        {
            return riderDB;
        }
        public List<Product> GetAllProductAvailable(int ProductId)
        {
            var list = new List<Product>();
            var product = productManager.Get(ProductId);
            foreach (var rider in riderDB)
            {
                if (product.IsAvaliable = true)
                {
                    list.Add(product);
                }
            }
            return list;
        }

        public Rider Register(string name, string email, string password, string userName, string phoneNumber, string address, string plateNumber, string riderRegNumber)
        {
            var riderCheck = RiderExist(userName);
            if (riderCheck == false)
            {
                User user = new User(UserManager.userDB.Count + 1, name, email, password, userName, phoneNumber, address, 0, "Rider", false);
                UserManager.userDB.Add(user);

                Rider rider = new Rider(riderDB.Count + 1,plateNumber, GenerateRiderRegNumber(), userName, false);
                riderDB.Add(rider);
                return rider;
            }
            return null;
        }

        private string GenerateRiderRegNumber()
        {
            Random rand = new Random();
            var asd = rand.Next(1000, 9999);
            return $"AOL/RID/{asd}";
        }
        public Rider Update(string userName, string name, string plateNumber, string phoneNumber, string address)
        {
            var rider = Get(userName);
            if (rider != null)
            {
                if (rider.UserName == userName && rider.IsDeleted == false)
                {
                    var user = userManager.Get(userName);
                    user.Name = name;
                    rider.PlateNumber = plateNumber;
                    user.PhoneNumber = phoneNumber;
                    user.Address = address;
                    Console.WriteLine($"{userName}: your name,plate number, phone number and address has been updated successfully");
                    return rider;
                }
            }
            Console.WriteLine($"{userName} not found!!!");
            return null;
        }
    }
}
