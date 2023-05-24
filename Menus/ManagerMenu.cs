using AolPhones.Managers.Implementations;
using AolPhones.Managers.Interfaces;
using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AolPhones.Menus
{
    public class ManagerMenu
    {
        IProductManager productManager = new ProductManager();
        IBrandManager brandManager = new BrandManager();
        IRiderManager riderManager = new RiderManager();
        IOrderManager orderManager = new OrderManager();
        IManagerManager managerManager = new ManagerManager();
        public void ManagerMain()
        {
            Console.WriteLine("Enter 1 to Create Product\nEnter 2 to view all Rider\nEnter 3 to view all Product\nEnter 4 to view all Product Available\nEnter 5 to view order initiated\nEnter 6 to view Delivered Order\nEnter 7 to Register Brand\nEnter 8 to Logout");
            int option = int.Parse(Console.ReadLine()); 
            if (option == 1)
            {
                CreateProduct();
                ManagerMain();
            }
            else if (option == 2)
            {
                ViewAllRider();
                ManagerMain();
            }
            else if (option == 3)
            {
                ViewALlProduct();
                ManagerMain();
            }
            else if (option == 4)
            {
                ViewAllProductAvailable();
                ManagerMain();
            }
            else if (option == 5)
            {
                ViewOrderInitiated();
                ManagerMain();  
            }
            else if (option == 6)
            {
                ViewDeliveredOrder();
                ManagerMain();
            }
            else if (option == 7)
            {
                RegisterBrand();
                ManagerMain();
            }
            else if( option == 8)
            {
                Logout();
                ManagerMain();
            }
            else
            {
                Console.WriteLine("Invalid option!!!Kindly Enter a valid option");
                ManagerMain();
            }
        }
        public void CreateProduct()
        {
            Console.Write("Enter the name of the product: ");
            string name = Console.ReadLine();
            Console.Write("Enter the CameraMP of the product: ");
            string cameraMP = Console.ReadLine();
            Console.Write("Enter the color of the product: ");
            string color = Console.ReadLine();
            Console.Write("Enter the ram capacity of the product: ");
            int ram = int.Parse(Console.ReadLine());
            Console.Write("Enter the rom capacity of the product: ");
            int rom = int.Parse(Console.ReadLine());
            Console.Write("Enter the battery capacity of the product: ");
            string batteryMAH = Console.ReadLine();
            Console.Write("Enter the price of the product: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter the quantity of the product: ");
            int quantity = int.Parse(Console.ReadLine());
            var brands = brandManager.GetAll();
            foreach ( var brand in brands )
            {
                Console.Write($"Enter {brand.Name} to select the product brand: ");
            }
            string brandName = Console.ReadLine();
            var product = productManager.Create(name,cameraMP,color,ram,rom,batteryMAH,price,quantity,brandName);
            if(product != null)
            {
                Console.WriteLine($"{name} created successfully");
                ManagerMain();
            }
            else
            {
                Console.WriteLine("Product not created");
            }
            
        }

        public void RegisterBrand()
        {
            Console.Write("Enter the Brand Name you want to register: ");
            string name = Console.ReadLine();
            var brand = brandManager.Create(name);
            if(brand != null)
            {
                Console.WriteLine($"{name} registered successfully");
                
            }
            else
            {
                Console.WriteLine("Brand already exist");
            }
        }
        public void ViewAllRider()
        {
            var riders = riderManager.GetAll();
            foreach (var rider in riders)
            {
                Console.WriteLine($"Rider username: {rider.UserName}\tRider RegNumber: {rider.RiderRegNumber}\tRider PlateNumber: {rider.PlateNumber}");
            }
        }
        public void ViewALlProduct()
        {
            var products = productManager.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"Product Name: {item.Name}\tBrandName: {item.BrandName}\tPrice of Product: {item.Price}\tProduct Quantity: {item.Quantity}");
            }
        }
        public void ViewAllProductAvailable()
        {
            var products = productManager.GetAll();
            foreach (var item in products)
            {
                if(item.IsAvaliable == true)
                {
                    Console.WriteLine($"Product Name: {item.Name}\tBrandName: {item.BrandName}\tPrice of Product: {item.Price}\tProduct Quantity: {item.Quantity}");
                }
            }
        }

        public void ViewOrderInitiated()
        {
            var order = orderManager.GetAll();
            foreach (var item in order)
            {
                if (item.Status == Models.Enums.Status.Initiated)
                {
                    Console.WriteLine($"Enter {item.ReferenceNumber} after  the order as been made from {item.UserName} to pack order");
                }
                string refNo = Console.ReadLine();
                orderManager.ParkOrder(refNo);
                Console.WriteLine($"{item.ReferenceNumber} packed, order available for pick up");
            }
            
        }
        public void ViewDeliveredOrder()
        {
            var order = orderManager.GetAll();
            List<Order> delivered = new List<Order>();
            foreach (var item in order)
            {
                if (item.Status == Models.Enums.Status.Delivered)
                {
                    Console.WriteLine($"Enter {item.ReferenceNumber} from {item.UserName} after been delivered ");
                }
            }
            string refNum = Console.ReadLine();
            orderManager.ReceiveOrder(refNum);
            Console.WriteLine("Delivered Successfully");
        }

        public void Logout()
        {
            Console.WriteLine("Logout Successfully");
            MainMenu mainMenu = new MainMenu();
            mainMenu.Menu();
        }
    }
}
