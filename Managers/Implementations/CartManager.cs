using AolPhones.Managers.Interfaces;
using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Implementations
{
    public class CartManager : ICartManager
    {
        public static List<Cart> CartDB = new List<Cart>();
        public Cart AddCart(string customerUserName, Dictionary<string, int> products, double totalPrice)
        {
            Cart cart = new Cart(CartDB.Count+1,GenerateCartNumber(),customerUserName,products,totalPrice,false);
            CartDB.Add(cart);
            return cart;
        }

        private string GenerateCartNumber()
        {
            Random rand = new Random();
            var cartNo = rand.Next(1000, 9999);
            return ($"AOL/cart/{cartNo}");
        }
        public Cart Get(int id)
        {
            foreach (var item in CartDB)
            {
                if (item.Id == id && item.IsDeleted == false)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Cart> GetCarts(string userName)
        {
            var list = new List<Cart>();
            foreach (var item in CartDB)
            {
                if(item.CustomerUserName == userName)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public List<Cart> GetAll()
        {
            return CartDB;
        }

        private bool CartExists(int id)
        {
            foreach (var item in CartDB)
            {
                if(item.Id == id && item.IsDeleted == false)
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
