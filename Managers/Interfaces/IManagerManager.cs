using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Interfaces
{
    public interface IManagerManager
    {
        public Manager Register(string name, string email, string password, string userName, string phoneNumber, string staffNumber, string address);
        public Manager Get(string userName);
        public List<Manager> GetAll();
        public Manager Update(string userName, string name, string phoneNumber, string address);
        public bool Delete(string userName);

    }
}
