using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Models.Enitities
{
    public class Customer :BaseEntity
    {
        public string UserName;
        

        public Customer(int id, string userName, bool isDeleted) : base(id, isDeleted) 
        { 
            UserName = userName;
        }


    }
}
