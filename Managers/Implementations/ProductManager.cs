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
    public class ProductManager : IProductManager
    {
        public static List<Product> ProductDB = new List<Product>();
        IBrandManager brandManager = new BrandManager();

        private bool Exist(string name)
        {
            foreach (var product in ProductDB)
            {
                if (product.Name == name && product.IsDeleted == false)
                {
                    return true;
                }
            }
            return false;
        }
        public Product Create(string name, int ram, int rom, string batteryMAH, double price, int quantity, string brandName)
        {
            var check = Exist(name);
            if (check != null)
            {
                Product product = new Product(ProductDB.Count +1, name, ram, rom, batteryMAH, price, quantity, brandName, true, false);
                ProductDB.Add(product);
                Console.WriteLine($"Product: {name} created successfully");
                return product;
            }
            return null;
        }
        public bool Delete(string name)
        {
            var product = Get(name);
            if(product != null)
            {
                Console.WriteLine($"{name} deleted successfully");
                product.IsDeleted = true;
                return true;
            }
            Console.WriteLine("product not found");
            return false;
        }

        public Product Get(string name)
        {
            foreach(var product in ProductDB)
            {
                if (product.Name == name && product.IsDeleted == false)
                {
                    return product;
                }
            }
            return null;
        }

        public Product Get(int id)
        {
            foreach (var product in ProductDB)
            {
                if (product.Id == id && product.IsDeleted == false)
                {
                    return product;
                }
                
            }
            return null;
        }

        public List<Product> GetAll()
        {
            return ProductDB;
        }

        public List<Product> GetProductsByBrandName(string brandName)
        {
            var list = new List<Product>();
            foreach(var product in ProductDB)
            {
                if(product.BrandName == brandName && product.IsDeleted == false)
                {
                    list.Add(product);
                }
            }
            return list;
        }

        public Product Update(string name, int ram, int rom, string batteryMAH, double price)
        {
            var product = Get(name);
            if(product != null)
            {
                product.Ram = ram;
                product.Rom = rom;
                product.BatteryMAH = batteryMAH;
                product.Price = price;
                Console.WriteLine($"{name} features updated successfully");
                return product;
            }
            return null;
        }
    }
}
