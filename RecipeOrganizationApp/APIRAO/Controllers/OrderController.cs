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

        //[HttpGet]
        //public async Task<IActionResult> GetMeals()
        //{
        //    try
        //    {
        //        return Ok(mealRepo.GetAllMeals());
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpGet("{MealId}")]
        //public async Task<IActionResult> GetMealID(Guid MealId)
        //{
        //    try
        //    {
        //        return Ok(mealRepo.GetMealsById(MealId));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> PostMeal(MealData inf)
        //{
        //    var result = mealRepo.AddMeal(inf);
        //    if (result == null)
        //    {
        //        return BadRequest("Something wrong!");
        //    }

        //    return Ok(result);
        //}

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
