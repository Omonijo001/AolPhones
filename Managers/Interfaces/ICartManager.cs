using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Interfaces
{
    public interface ICartManager
    {
        public Cart AddCart(string customerUserName, Dictionary<string, int> products, double totalPrice);
        public Cart Get(int id);
        public Cart Get(string cartNumber);
        public List<Cart> GetCarts(string userName);
        public List<Cart> GetAll();
    }
}
