using AolPhones.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Models.Enitities
{
    public class Brand: BaseEntity
    {
        public string Name;

        public Brand(int id, string name,  bool isDeleted): base(id, isDeleted)
        {
            Name = name;
        }



    }
}
