using AolPhones.Managers.Implementations;
using AolPhones.Managers.Interfaces;
using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Menus
{
    public class CustomerMenu
    {
        IProductManager productManager = new ProductManager();
        IUserManager userManager = new UserManager();
        ICartManager cartManager = new CartManager();
        IOrderManager orderManager = new OrderManager();
        ICustomerManager customerManager = new CustomerManager();

       
        public void CustomerMain()
        {
            Console.WriteLine("Enter 1 to view all Product Available\nEnter 2 for Carting\nEnter 3 to Fund Wallet\nEnter 4 to make order\nEnter 5 to Logout ");
            int option = int.Parse(Console.ReadLine()); 
            if (option == 1)
            {
                ViewAllProductAvailable();
                CustomerMain();
            }
            else if (option == 2)
            {
                Carting();
                CustomerMain();
            }
            else if (option == 3)
            {
                FundWallet();
                CustomerMain();
            }
            else if (option == 4)
            {
                MakeOrder();
                CustomerMain();
            }
            else if (option == 5)
            {
                Logout();
                CustomerMain();
            }
            else
            {
                Console.WriteLine("Invalid option!!!Kindly Enter a valid option");
                CustomerMain();
            }
        }

        public void ViewAllProductAvailable()
        {
            var products = productManager.GetAll();
            foreach(var product in products)
            {
                if(product.IsAvaliable == true)
                {
                    Console.WriteLine($"The product name is {product.Name},\tbrand name :{product.BrandName},\tthe price of the product is {product.Price}");
                }
            }

        }
        public void Carting()
        {
            Console.WriteLine("enter your username");
            var userName = Console.ReadLine();
            var user = userManager.Get(userName);
            var products = productManager.GetAll();
            Dictionary<string, int> pro = new Dictionary<string, int>();
            bool flag = true;
            while(flag)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"enter {product.Id} to cart {product.Name}");
                }
                int option = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the quantity you want: ");
                int quantity = int.Parse(Console.ReadLine());
                var productName = productManager.Get(option).Name;
                if(pro.ContainsKey(productName))
                {
                    pro[productName]+=quantity;
                }
                else
                {
                    pro.Add($"{productName}", quantity);
                }

                foreach (var p in pro)
                {
                    Console.WriteLine($"{p.Key}\t{p.Value}");
                }
                var price = CalculatePrice(pro);
                Console.WriteLine($"the total price is {price} and your wallet balance {user.Wallet}");
                
                Console.WriteLine("still want to cart? Enter y for Yes and n for No y/n");
                char opt = char.Parse(Console.ReadLine());
                if(opt == 'n')
                {
                    flag = false;
                }
            }
            var realPrice = CalculatePrice(pro);
            cartManager.AddCart(userName, pro, realPrice);

        }

        public double CalculatePrice(Dictionary<string, int> pro)
        {
            double price = 0;
            foreach (var item in pro)
            {
                var productPrice = productManager.Get(item.Key).Price;
                price += (productPrice * item.Value);
            }
            return price;
        }

        public void FundWallet()
        {
            Console.WriteLine("Enter your UserName");
            string userName =  Console.ReadLine();
            Console.WriteLine($"enter the amount you want to deposit ");
            double amount = double.Parse(Console.ReadLine());
            if(amount <= 0)
            {
                Console.WriteLine("Invalid input!!");
            }
            else
            {
                var user = userManager.Get(userName);
                var wallet = user.Wallet + amount;
                Console.WriteLine($"Your wallet balance is {wallet}");
                userManager.FundWallet(userName, amount); 
            }
        }
        public void MakeOrder()
        {
            Console.WriteLine("enter your userName");
            string userName = Console.ReadLine();
            var myCarts = cartManager.GetCarts(userName);
            foreach (var item in myCarts)
            {
                Console.WriteLine($"enter {item.CartNumber} to make order the cart items");
                
            }
            string cartNumber = Console.ReadLine();
            var order = orderManager.MakeOrder(userName, cartNumber);
            if(order == null)
            {
                Console.WriteLine("Transaction failed");
            }
            else
            {
                Console.WriteLine("Transaction successful");
               
            }
        }
        public void Logout()
        {
            Console.WriteLine("Logout Successfully");
            MainMenu mainMenu = new MainMenu();
            mainMenu.Menu();
        }

    }
}
