using BusinessObjects;
using BusinessObjects.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Order GetOrdersById(string id);
        Task<Order> AddOrder(OrderData order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
