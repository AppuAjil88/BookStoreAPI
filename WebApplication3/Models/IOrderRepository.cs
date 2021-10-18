using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    interface IOrderRepository
    {
        Order addOrder(Order order);
        List<Order> viewOrdersByUserID(int id);
        List<Order> viewAllOrders();

    }
}
