using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Models.Enitities
{
    public class User : BaseEntity
    {
        public string Name;
        public string Email;
        public string Password;
        public string UserName;
        public string PhoneNumber;
        public string Address;
        public double Wallet;
        public string Role;


        public User(int id, string name, string email, string password, string userName, string phoneNumber, string address, double wallet, string role, bool isDeleted) : base(id, isDeleted)
        {
            Name = name;
            Email = email;
            Password = password;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Address = address;
            Wallet = wallet;
            Role = role;
        }
    }
}
