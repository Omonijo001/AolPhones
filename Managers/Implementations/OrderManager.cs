using AolPhones.Managers.Interfaces;
using AolPhones.Menus;
using AolPhones.Models.Enitities;
using AolPhones.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Implementations
{
    public class OrderManager : IOrderManager
    {
        public static List<Order> OrderDB = new List<Order>();
        ICartManager cartManager = new CartManager();
        IUserManager userManager = new UserManager();
        IProductManager productManager = new ProductManager();
        public void DeliverOrder(string refNumber)
        {
            var order = Get(refNumber);
            if (order != null)
            {
                order.Status = Status.Delivered;
            }
        }
        
        public void EnrouteOrder(string refNumber)
        {
            var order = Get(refNumber);
            if (order != null)
            {
                order.Status = Status.EnrouteOrder;
            }
        }

        public Order Get(string refNumber)
        {
            foreach (var order in OrderDB)
            {
                if (order.ReferenceNumber == refNumber)
                {
                    return order;
                }
            }
            return null;
        }


        public List<Order> GetAll()
        {
            return OrderDB;
        }

        public Order MakeOrder(string userName, int cartNumber)
        {
            var user = userManager.Get(userName);
            var cart = cartManager.Get(cartNumber);
            if (user != null && cart != null)
            {
                foreach (var item in cart.Products)
                {
                    Console.WriteLine($"{item.Key}\t{item.Value}");
                }
                Console.WriteLine($"total price => {cart.TotalPrice}");
                if (user.Wallet > cart.TotalPrice)
                {
                    user.Wallet -= cart.TotalPrice;
                    var order = new Order(OrderDB.Count + 1, GenerateReferenceNumber(), userName, DateTime.Now, cartNumber, Status.Initiated, false);
                    OrderDB.Add(order);
                    foreach (var product in cart.Products)
                    {
                        var prod = productManager.Get(product.Key);
                        prod.Quantity -= product.Value;

                    }
                    cart.IsDeleted = true;
                    return order;
                }
                Console.WriteLine("insufficient fund");
                return null;
            }
            Console.WriteLine("invalid cridentials");
            return null;
            
            
        }

        public void ParkOrder(string refNumber)
        {
            var order = Get(refNumber);
            if (order != null)
            {
                order.Status = Status.ParkOrder;
            }
        }

        public void ReceiveOrder(string refNumber)
        {
            var order = Get(refNumber);
            if (order != null)
            {
                order.Status = Status.ReceiveOrder;
            }
        }

        private string GenerateReferenceNumber()
        {
            Random rand = new Random();
            return $"AOL/ord/" + rand.Next(1000, 9999).ToString();
        }
    }
}
