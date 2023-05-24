using AolPhones.Managers.Implementations;
using AolPhones.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AolPhones.Menus
{
    public class MainMenu
    {
        IUserManager userManager = new UserManager();
        ICustomerManager customerManager = new CustomerManager();
        IManagerManager managerManager = new ManagerManager();
        IRiderManager riderManager = new RiderManager();
        ICartManager cartManager = new CartManager();
        SuperAdminMenu superAdminMenu = new SuperAdminMenu();
        RiderMenu riderMenu = new RiderMenu();
        CustomerMenu customerMenu = new CustomerMenu();
        ManagerMenu managerMenu = new ManagerMenu();
        public void Menu()
        {
            Console.WriteLine("Enter 1 to Register\nEnter 2 to Login");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                RegisterMenu();
            }
            else if (option == 2)
            {
                LoginMenu();
            }
            else
            {
                Console.WriteLine("You enter a wrong input\nEnter a valid option");
                Menu();
            }

        }
       
        public void RegisterMenu()
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Email address: ");
            string email = Console.ReadLine();
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter your Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your Phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();

            var customer = customerManager.Register(name, email, password, username, phoneNumber, address);
            if (customer != null)
            {
                var user = userManager.Get(name);
                user.Role = "Customer";
                Console.WriteLine("registration successful");
            }
            else
            {
                Console.WriteLine("customer already exist");
            }
            Menu();

        }

        public void LoginMenu()
        {
            Console.Write("Enter your Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            var user = userManager.Login(username, password);

            if (user != null)
            {
                if (user.Role == "SuperAdmin")
                {
                    superAdminMenu.SuperMenu();
                }
                else if (user.Role == "Manager")
                {
                    managerMenu.ManagerMain();  
                }
                else if (user.Role == "Customer")
                {
                    var count = cartManager.GetCarts(username).Count;
                    Console.WriteLine($"welcome {username}, you have {count} pending carts");
                    customerMenu.CustomerMain();
                }
                else if (user.Role == "Rider")
                {
                    riderMenu.RiderMain();
                }
              
            }
            else
            {
                Console.WriteLine("Incorrect password or username\nEnter a correct username and password");
                Console.WriteLine("Do you want to login again?\nEnter 1 for YES and 2 for NO");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    var menu = new MainMenu();
                    menu.LoginMenu();
                }
                else
                {
                    Menu();
                }
            }
        }
    }
}
