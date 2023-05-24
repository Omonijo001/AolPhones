using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Interfaces
{
    public interface IRiderManager
    {
        public Rider Register(string name, string email, string password, string userName, string phoneNumber, string address, string plateNumber, string riderRegNumber);
        public Rider Get(int id);
        public Rider Get(string userName);
        public List<Rider> GetAll();
        public List<Product> GetAllProductAvailable(int ProductId);
        public Rider Update(string userName, string name, string plateNumber, string phoneNumber, string address);
        public bool Delete(string userName);
    }
}
