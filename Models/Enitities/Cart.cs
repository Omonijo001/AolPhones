using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Models.Enitities
{
    public class Cart: BaseEntity
    {
        public string CartNumber;
        public string CustomerUserName;
        public Dictionary<string, int> Products;
        public double TotalPrice;

        public Cart(int id, string cartNumber, string customerUserName, Dictionary<string, int> products, double totalPrice, bool isDeleted) : base(id, isDeleted)
        {
            CartNumber = cartNumber;
            CustomerUserName = customerUserName;
            Products = products;
            TotalPrice = totalPrice;

        }
    }
}
