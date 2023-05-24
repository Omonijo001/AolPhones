using AolPhones.Managers.Implementations;
using AolPhones.Managers.Interfaces;
using AolPhones.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AolPhones.Menus
{
    public class RiderMenu
    {
        IOrderManager orderManager = new OrderManager();
        IUserManager userManager = new UserManager();
        ICustomerManager customerManager = new CustomerManager();
        IManagerManager managerManager = new ManagerManager();

        public void RiderMain()
        {
            Console.WriteLine("Enter 1 to view All Packed Order\nEnter 2 to view Customer Details of Packed Order\nEnter 3 to View Manager Details of Packed Order\nEnter 4 to register delivered order\nEnter 5 to Logout ");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                ViewAllPackedOrder();
                RiderMain();
            }
            else if(option == 2)
            {
                ViewCustomerDetails();
                RiderMain();
            }
            else if(option == 3)
            {
                ViewMangerDetails();
                RiderMain();
            }
            else if (option == 4)
            {
                RegisterDeliveredOrder();
                RiderMain();
            }
            else if(option == 5)
            {
                Logout();
                RiderMain();
            }
            else
            {
                Console.WriteLine("Invalid option!!!Kindly Enter a valid option");
                RiderMain() ;
            }
        }

        public void ViewAllPackedOrder()
        {
            var orders = orderManager.GetAll();
            foreach (var order in orders)
            {
                if(order.Status == Status.ParkOrder)
                {
                    var user = userManager.Get(order.UserName);
                    Console.WriteLine($"OrderRefrence Number: {order.ReferenceNumber}\tUsername: {order.UserName}\tAddress: {user.Address}\tPhoneNumber: {user.PhoneNumber}");
                }
            }
        }
        public void EnrouteOrder()
        {
            var order = orderManager.GetAll();
            foreach (var item in order)
            {
                if (item.Status == Status.ParkOrder)
                {
                    Console.WriteLine($"enter {item.ReferenceNumber} to deliver order to {item.UserName}");
                }
                var refNo = Console.ReadLine();
                orderManager.EnrouteOrder(refNo);
            }
        }
        
        public void RegisterDeliveredOrder()
        {
            var order = orderManager.GetAll();
            foreach (var item in order)
            {
                if (item.Status == Status.ParkOrder)
                {
                    var user = userManager.Get(item.UserName);
                    Console.WriteLine($"Username: {item.UserName}\tAddress: {user.Address}\tPhoneNumber: {user.PhoneNumber}");
                    item.Status  = Status.EnrouteOrder;
                }
                if (item.Status == Status.EnrouteOrder)
                {
                    Console.WriteLine($"enter {item.ReferenceNumber} to deliver order to {item.UserName}");
                }
                  var refNo = Console.ReadLine();
                 orderManager.DeliverOrder(refNo);
                Console.WriteLine($"{item.ReferenceNumber} delivered successfully");
                RiderMain();
            }
        }
        public void ViewCustomerDetails()
        {
            var customer = customerManager.GetAll();
            foreach (var item in customer)
            {
                var user = userManager.Get(item.UserName);
                Console.WriteLine($"Username: {item.UserName}\tName:{user.Name}\tEmail: {user.Email}\tAddress: {user.Address}\tPhoneNumber: {user.PhoneNumber}");
            }

        }
        public void ViewMangerDetails()
        {
            var managers = managerManager.GetAll();
            foreach (var manager in managers)
            {
                var user = userManager.Get(manager.UserName);
                Console.WriteLine($"StaffNumber: {manager.StaffNumber}\tUsername: {manager.UserName}\tPhoneNumber: {user.PhoneNumber}");
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
