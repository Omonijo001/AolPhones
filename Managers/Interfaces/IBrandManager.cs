using AolPhones.Models.Enitities;
using AolPhones.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Interfaces
{
    public interface IBrandManager
    {
        public Brand Create(string name);
        public Brand Get(int id);
        public Brand Get(string name);
        public List<Brand> GetAll();
        public Brand Update(string oldName, string newName);
        public bool Delete(string name);
    }
}
