using BusinessObjects;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository :IOrderRepository
    {
        public List<Order> GetOrders() => OrderDAO.GetOrders();
        public Order GetOrdersById(string id) => OrderDAO.GetOrdersById(id);
        public void AddOrder(Order order) => OrderDAO.AddOrder(order);
        public void UpdateOrder(Order order) => OrderDAO.UpdateOrder(order);
        public void DeleteOrder(Order order) => OrderDAO.DeleteOrder(order);
    }
}
