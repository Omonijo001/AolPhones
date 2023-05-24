using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Models.Enitities
{
    public class Manager: BaseEntity
    {
        public string UserName;
        public string StaffNumber;

        public Manager(int id, string userName, string staffNumber, bool isDeleted) : base(id, isDeleted)
        {
            UserName = userName;
            StaffNumber = staffNumber;
        }
    }
}
