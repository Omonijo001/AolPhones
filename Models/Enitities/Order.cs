using AolPhones.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Models.Enitities
{
    public class Order: BaseEntity
    {
        public string ReferenceNumber;
        public string UserName;
        public DateTime Date;
        public int CartId;
        public Status Status;


        public Order(int id, string referenceNumber, string userName, DateTime date, int cartId, Status status, bool isDeleted): base(id,isDeleted)
        {
            ReferenceNumber = referenceNumber;
            UserName = userName;
            Date = date;
            CartId = cartId;
            Status = status;

        }
    }
}
