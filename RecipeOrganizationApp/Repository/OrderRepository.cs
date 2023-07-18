using BusinessObjects;
using BusinessObjects.MapData;
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
        public OrderRepository(AppDBContext dbContext)
        {
            dao = new OrderDAO(dbContext);
        }

        private readonly OrderDAO dao;

        public List<Order> GetOrders() => dao.GetOrders();
        public Order GetOrdersById(Guid id) => dao.GetOrdersById(id);
        public List<Order> GetOrdersByUserId(Guid id) => dao.GetOrdersByUserId(id);
        public Task<Order> AddOrder(OrderData order) => dao.AddOrder(order);
        public void UpdateOrder(Order order) => dao.UpdateOrder(order);
        public void DeleteOrder(Order order) => dao.DeleteOrder(order);
    }
}
