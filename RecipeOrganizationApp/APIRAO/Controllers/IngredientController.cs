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

        public IngredientController(IIngredientRepository _IngredientRepository)
        {
            this.ingRepo = _IngredientRepository;
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

        [HttpDelete("{IngId}")]
        public async Task<IActionResult> DeleteIng(Guid IngId)
        {
            try
            {
                ingRepo.DeleteIngredient(IngId);
                return Ok("delete succses");
            }
            catch
            {
                return BadRequest("Not Found ID");
            }
        }
    }
}
