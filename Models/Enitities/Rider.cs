using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Models.Enitities
{
    public class Rider: BaseEntity
    {
        public string PlateNumber;
        public string RiderRegNumber;
        public string UserName;

        public Rider(int id, string plateNumber, string riderRegNumber, string userName, bool isDeleted): base(id,isDeleted) 
        { 
            PlateNumber = plateNumber;
            RiderRegNumber = riderRegNumber;
            UserName = userName;
        }


    }
}
