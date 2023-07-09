using BusinessObjects.MapData;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepo;

        public OrderController(IOrderRepository _orderRepository)
        {
            this.orderRepo = _orderRepository;
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
                return Ok(orderRepo.GetOrdersById(OrderId.ToString()));
            }
            catch
            {
                return BadRequest();
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

        //[HttpDelete("{MealId}")]
        //public async Task<IActionResult> DeleteMeal(Guid MealId)
        //{
        //    var rs = mealRepo.DeleteMeal(MealId);
        //    if (rs == null)
        //    {
        //        return BadRequest(rs);
        //    }

        //    return Ok(rs);
        //}

        //[HttpPut("{mealid}")]
        //public async Task<IActionResult> Updatemeal(Guid mealid, decimal mealPrice, string mealDescription)
        //{
        //    var result = mealRepo.UpdateMeal(mealid, mealPrice, mealDescription);
        //    if (result == null)
        //    {
        //        return BadRequest(result);
        //    }
        //    return Ok(result);
        //}
    }
}
