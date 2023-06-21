using BusinessObjects;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance;
        private readonly AppDBContext _context;

        public OrderDAO(AppDBContext context)
        {
            this._context = context;
        }

        public static OrderDAO GetInstance(AppDBContext dbContext)
        {

            if (instance == null)
            {
                instance = new OrderDAO(dbContext);
            }

            return instance;
        }

        //Get All Orders
        public  List<Order> GetOrders()
        {
            var listOrders = new List<Order>();
            try
            {
                
                    listOrders = _context.Orders.ToList();
                
            } catch(Exception ex)
            {
                throw new Exception();
            }
            return listOrders;
        }
        //Get Order matches OrderID
        public  Order GetOrdersById(string id)
        {
            var order = new Order();
            try
            {
                
                    order = _context.Orders.Where(x => x.OrderID.Equals(id)).SingleOrDefault();
                
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return order;
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
                
            } catch(Exception ex)
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
                        _context.Entry<Order>(order).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                    }
                
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing Order
        public  void DeleteOrder(Order order)
        {
            try
            {
                
                    var orderCheck = _context.Orders.SingleOrDefault(x => x.OrderID.Equals(order.OrderID));
                    if(orderCheck != null)
                    {
                        _context.Orders.Remove(orderCheck);
                        _context.SaveChanges();
                    }
                
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}