using AolPhones.Managers.Implementations;
using AolPhones.Managers.Interfaces;
using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace AolPhones.Menus
{
    public class SuperAdminMenu
    {
        IManagerManager managerManager = new ManagerManager();
        IUserManager userManager = new UserManager();
        IRiderManager riderManager = new RiderManager();
        ICustomerManager customerManager = new CustomerManager();
        IProductManager productManager = new ProductManager();
        IOrderManager orderManager = new OrderManager();
        public void SuperMenu()
        {
            Console.WriteLine("Enter 1 to Register Manager\nEnter 2 to Register Rider\nEnter 3 to view all Manager\nEnter 4 to view all Customer\nEnter 5 to view all Rider\nEnter 6 to view all Products\nEnter 7 to view all Products Available\nEnter 8 to view all Orders\nEnter 9 to Logout ");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                RegisterManager();
                SuperMenu();
            }
            else if (option == 2)
            {
                RegisterRider();
                SuperMenu();
            }
            else if (option == 3)
            {
                ViewAllManager();
                SuperMenu();
            }
            else if (option == 4)
            {
                ViewAllCustomer();
                SuperMenu();
            }
            else if (option == 5)
            {
                ViewAllRider();
                SuperMenu();
            }
            else if (option == 6)
            {
                ViewAllProduct();
                SuperMenu();
            }
            else if (option == 7)
            {
                ViewAllProductAvailable();
                SuperMenu();
            }
            else if (option == 8)
            {
                ViewAllOrder();
                SuperMenu();
            }
            else if (option == 9)
            {
                Logout();
                SuperMenu();
            }
            else
            {
                Console.WriteLine("Invalid option!!!Kindly Enter a valid option");
                SuperMenu();
            }
        }
         
        public void RegisterManager()
        {
            Console.Write("Enter Manager Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Manager Email address: ");
            string email = Console.ReadLine();
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter your Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your Phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter your address: ");
            string address = Console.ReadLine();
            string role = "Manager";
            var manager = managerManager.Register(name, email, password, username, phoneNumber, "null", address);
            if (manager != null)
            {
                Console.WriteLine("Manager Registered Sucessfully");
            }
            else
            {
                Console.WriteLine("Manager already exist");
            }

            SuperMenu();

        }

        public void RegisterRider()
        {
            Console.Write("Enter Rider Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Rider Email address: ");
            string email = Console.ReadLine();
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter your Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your Phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter your address: ");
            string address = Console.ReadLine();
            Console.Write("Enter your Vehicle Plate Number: ");
            string plateNumber = Console.ReadLine();
            string role = "Rider";
            var rider = riderManager.Register(name, email, password, username, phoneNumber, address, plateNumber, "null");
            if (rider != null)
            {
                Console.WriteLine("registration successful");
            }
            else
            {
                Console.WriteLine("rider already exist");
            }
            SuperMenu();


        }
        public void ViewAllManager()
        {
            var managers = managerManager.GetAll();
            foreach (var manager in managers)
            {
                var user = userManager.Get(manager.UserName);
                Console.WriteLine($"StaffNumber: {manager.StaffNumber}\tUsername: {manager.UserName}\tPhonenumber: {user.PhoneNumber}");
            }
        }
        public void ViewAllCustomer()
        {
            var customer = customerManager.GetAll();
            foreach (var item in customer)
            {
                var user = userManager.Get(item.UserName);
                Console.WriteLine($"Username: {item.UserName}\tName: {user.Name}\tEmail: {user.Email}\tAddress: {user.Address}\tPhoneNumber: {user.PhoneNumber}");
            }
        }
        public void ViewAllRider()
        {
            var rider = riderManager.GetAll();
            foreach (var item in rider)
            {
                Console.WriteLine($"Username: {item.UserName}\tRider RegNumber:{item.RiderRegNumber}\tPlateNumber: {item.PlateNumber}");
            }
        }
    
        public void ViewAllProduct()
        {
            var products = productManager.GetAll();
            foreach (var product in products)
            {
               Console.WriteLine($"ProductName: {product.Name}\tBrandName: {product.BrandName}\tProdctPrice: {product.Price}");
            
            }
        }
        public void ViewAllProductAvailable()
        {
            var products = productManager.GetAll();
            foreach (var product in products)
            {
                if (product.IsAvaliable == true)
                {
                    Console.WriteLine($"ProductName: {product.Name}\tBrandName: {product.BrandName}\tProductPrice: {product.Price}");
                }
            }
        }
        public void ViewAllOrder()
        {
            var order = orderManager.GetAll();
            foreach(var item in order)
            {
                
               Console.WriteLine($"Username:{item.UserName}\tReference Number: {item.ReferenceNumber}\tStatus: {item.Status}\tDate: {item.Date}");
               
            }
        }
        public void Logout()
        {
            Console.WriteLine("Logout Sucessfully");
            MainMenu mainMenu = new MainMenu();
            mainMenu.Menu();
        }


    }
}
