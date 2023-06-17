using BusinessObjects;

namespace DataAccess
{
    public class OrderDAO
    {
        //Get All Orders
        public static List<Order> GetOrders()
        {
            var listOrders = new List<Order>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listOrders = context.Orders.ToList();
                }
            } catch(Exception ex)
            {
                throw new Exception();
            }
            return listOrders;
        }
        //Get Order matches OrderID
        public static Order GetOrdersById(string id)
        {
            var order = new Order();
            try
            {
                using (var context = new AppDBContext())
                {
                    order = context.Orders.Where(x => x.OrderID.Equals(id)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return order;
        }
        //Post new Order
        public static void AddOrder(Order order)
        {
            try
            {
                using(var context = new AppDBContext())
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
                    context.Orders.Add(orderAdd);
                    context.SaveChanges();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Put existing Order
        public static void UpdateOrder(Order order)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var orderCheck = context.Orders.SingleOrDefault(x => x.OrderID == order.OrderID);
                    if (orderCheck != null)
                    {
                        context.Entry<Order>(order).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing Order
        public static void DeleteOrder(Order order)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var orderCheck = context.Orders.SingleOrDefault(x => x.OrderID.Equals(order.OrderID));
                    if(orderCheck != null)
                    {
                        context.Orders.Remove(orderCheck);
                        context.SaveChanges();
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}