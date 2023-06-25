using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository ingRepo;

        public IngredientController(AppDBContext dbContext)
        {
            ingRepo = new IngredientRepository(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetIngredient()
        {
            try
            {
                return Ok(ingRepo.GetIngredients());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{IngredientId}")]
        public ActionResult<Ingredient> GetIngredientById(Guid IngredientId)
        {
            try
            {
                return Ok(ingRepo.GetIngredientsById(IngredientId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRoleAsync(string ingName)
        {
            var result = await ingRepo.AddIngredient(ingName);
            if (result == null)
            {
                return Conflict("Something wrong!");
            }
           
            return Ok(result);
        }
    }
}
