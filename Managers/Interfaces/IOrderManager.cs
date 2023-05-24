using AolPhones.Models.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AolPhones.Managers.Interfaces
{
    public interface IOrderManager
    {
        public Order MakeOrder(string userName, int CartNumber);
        public Order Get(string refNumber);
        public List<Order> GetAll();
        public void ReceiveOrder(string refNumber);
        public void ParkOrder(string refNumber);
        public void EnrouteOrder(string refNumber);
        public void DeliverOrder(string refNumber);

    }
}
