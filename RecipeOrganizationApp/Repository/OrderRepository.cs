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
        public OrderRepository(AppDBContext dbContext)
        {
            _context = OrderDAO.GetInstance(dbContext);
        }

        private readonly OrderDAO _context;

        public List<Order> GetOrders() => _context.GetOrders();
        public Order GetOrdersById(string id) => _context.GetOrdersById(id);
        public void AddOrder(Order order) => _context.AddOrder(order);
        public void UpdateOrder(Order order) => _context.UpdateOrder(order);
        public void DeleteOrder(Order order) => _context.DeleteOrder(order);
    }
}
