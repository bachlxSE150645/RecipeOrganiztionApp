using BusinessObjects;
using BusinessObjects.MapData;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess
{
    public class OrderDAO
    {
        private readonly AppDBContext _context;

        public OrderDAO(AppDBContext context)
        {
            this._context = context;
        }

        //Get All Orders
        public List<Order> GetOrders()
        {
            try
            {
                return _context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Order matches OrderID
        public Order GetOrdersById(string id)
        {
            try
            {
                return _context.Orders.SingleOrDefault(x => x.OrderID.ToString().Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Order matches UserID
        public List<Order> GetOrdersByUserId(string id)
        {
            try
            {
                return _context.Orders.Where(x=>x.AccountID.ToString().Equals(id)).OrderBy(x=>x.CreateDate).ToList();
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Post new Order
        public async Task<Order> AddOrder(OrderData order)
        {
            try
            {
                var meal = await _context.Meals!.FirstOrDefaultAsync(c => c.MealID.ToString().Equals(order.MealID.ToString()));
                var orderAdd = new Order
                {
                    OrderID = Guid.NewGuid(),
                    MealID = order.MealID,
                    AccountID = order.AccountID,
                    CreateDate = DateTime.Now,
                    Quantity = order.Quantity,
                    TotalPrice = meal.Price * order.Quantity,
                    Status = "waiting",
                    Detail = order.Detail
                };
                _context.Orders.Add(orderAdd);
                await _context.SaveChangesAsync();
                return orderAdd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Order
        public void UpdateOrder(Order order)
        {
            try
            {
                var orderCheck = _context.Orders.SingleOrDefault(x => x.OrderID == order.OrderID);
                if (orderCheck != null)
                {
                    _context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Order
        public void DeleteOrder(Order order)
        {
            try
            {
                var orderCheck = _context.Orders.SingleOrDefault(x => x.OrderID.Equals(order.OrderID));
                if (orderCheck != null)
                {
                    _context.Orders.Remove(orderCheck);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}