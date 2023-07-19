using BusinessObjects;
using BusinessObjects.MapData;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepo;
        private readonly IMealRepository mealRepo;

        public OrderController(IOrderRepository _orderRepository, IMealRepository _mealRepository)
        {
            this.orderRepo = _orderRepository;
            this.mealRepo = _mealRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                return Ok(orderRepo.GetOrders());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetOrderID(Guid OrderId)
        {
            try
            {
                return Ok(orderRepo.GetOrdersById(OrderId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("User/{UserId}")] // Get All Orders that 1 user bought
        public async Task<IActionResult> GetOrderByUserID(Guid UserId)
        {
            try
            {
                return Ok(orderRepo.GetOrdersByUserId(UserId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Owner/{OwnerId}")] // Get All Orders of 1 shop by shop owner's ID
        public async Task<IActionResult> GetOrderByOwnerID(Guid OwnerId)
        {
            var mealList = mealRepo.GetMealsByAccountId(OwnerId);
            List<Order> ordersList = new List<Order>();
            if(mealList.Count == 0)
            {
                return BadRequest();
            }
            else
            {
                foreach(var i in mealList)
                {
                    var orderList = orderRepo.GetOrdersByMealID(i.MealID);
                    foreach(var j in orderList)
                    {
                        ordersList.Add(j);
                    }
                }
                return Ok(ordersList);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostOrder(OrderData inf)
        {
            var result = await orderRepo.AddOrder(inf);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }
            return Ok(result);
        }

        [HttpDelete("{OrderId}")]
        public async Task<IActionResult> DeleteOrder(Guid OrderId)
        {
            var rs = orderRepo.GetOrdersById(OrderId);
            if (rs == null)
            {
                return BadRequest(rs);
            }
            else
            {
                orderRepo.DeleteOrder(rs);
                return Ok();
            }
        }

        [HttpPut("{OrderId}")]
        public async Task<IActionResult> UpdateOrder(Guid OrderId, OrderData inf)
        {
            var rs = orderRepo.GetOrdersById(OrderId);
            if (rs == null)
            {
                return BadRequest();
            }
            else
            {
                var meal = mealRepo.GetMealsById(rs.MealID);
                rs.CreateDate = DateTime.Now;
                rs.Quantity = inf.Quantity;
                rs.TotalPrice = inf.Quantity * meal.Price;
                rs.Detail = inf.Detail;
                orderRepo.UpdateOrder(rs);
                return Ok(rs);
            }
        }
    }
}
