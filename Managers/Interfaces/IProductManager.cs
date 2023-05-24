using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Interfaces
{
    public interface IProductManager
    {
        public Product Create(string name, int ram, int rom, string batteryMAH, double price, int quantity, string brandName );
        public Product Get (string name);
        public Product Get (int id);
        public List<Product> GetProductsByBrandName(string brandName);
        public List<Product> GetAll();
        public Product Update(string name, int ram, int rom, string batteryMAH, double price);
        public bool Delete(string name);
    }
}
