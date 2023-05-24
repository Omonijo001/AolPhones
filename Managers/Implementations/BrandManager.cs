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
    public class BrandManager : IBrandManager
    {
        public static List<Brand> BrandDB = new List<Brand>()
        {
            new Brand(1,"Infinix",false),
            new Brand(2,"Samsung", false)
        };

        public Brand Create(string name)
        {
            var brandExists = Exists(name);
            if (!brandExists)
            {
                Console.WriteLine($"{name} alraedy exist as a brand");
                return null;
            }
            var brand = new Brand(BrandDB.Count + 1, name, false);
            BrandDB.Add(brand);
            Console.WriteLine($"{name} brand created successfully");
            return brand;

        }

        public bool Delete(string name)
        {
            var brand = Get(name);
            if(brand == null)
            {
                Console.WriteLine($"{name} not found");
                return false;
            }
            brand.IsDeleted = true;
            Console.WriteLine($"{name} deleted succesfully");
            return true;
        }

        public Brand Get(int id)
        {
            foreach (var brand in BrandDB)
            {
                if (brand.Id == id && brand.IsDeleted == false)
                {
                    return brand;
                }
            }
            return null;
        }

        public Brand Get(string name)
        {
            foreach(var brand in BrandDB)
            {
                if(brand.Name == name && brand.IsDeleted == false)
                {
                    return brand;
                }
            }
            return null;
        }

        public List<Brand> GetAll()
        {
            return BrandDB;
        }

        public Brand Update(string oldName, string newName)
        {
            var brand = Get(oldName);
            if (brand == null)
            {
                Console.WriteLine($"{oldName} not found");
                return null;
            }
            brand.Name = newName;
            Console.WriteLine($"{oldName} changed succesfully to {newName}");
            return brand;
        }

        private bool Exists(string name)
        {
            foreach (var item in BrandDB)
            {
                if (item.Name == name && item.IsDeleted == false)
                 return false;
                
            }
            return true;
        }
    }
}
