using BusinessObjects;

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
                return _context.Orders.SingleOrDefault(x => x.OrderID.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Order
        public void AddOrder(Order order)
        {
            try
            {
                var orderAdd = new Order
                {
                    MealID = order.MealID,
                    AccountID = order.AccountID,
                    CreateDate = order.CreateDate,
                    Quantity = order.Quantity,
                    TotalPrice = order.TotalPrice,
                    Status = order.Status,
                    Detail = order.Detail
                };
                _context.Orders.Add(orderAdd);
                _context.SaveChanges();
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