using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Models.Enitities
{
    public class Product: BaseEntity
    {
        public string Name;
        public int Ram;
        public int Rom;
        public string BatteryMAH;
        public double Price;
        public int Quantity;
        public string BrandName;
        public bool IsAvaliable;

        public Product(int id, string name, int ram, int rom, string batteryMAH, double price, int quantity, string brandName, bool isAvaliable, bool isDeleted): base(id, isDeleted)
        {
            Name = name;
            Ram = ram;
            Rom = rom;
            BatteryMAH = batteryMAH;
            Price = price;
            Quantity = quantity;
            BrandName = brandName;
            IsAvaliable = isAvaliable;
        }
    }
}
