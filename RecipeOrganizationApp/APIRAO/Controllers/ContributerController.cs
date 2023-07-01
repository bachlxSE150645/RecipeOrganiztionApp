using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using Microsoft.EntityFrameworkCore;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributerController : ControllerBase
    {
        private readonly IRecipeRepository recRepo;

        public ContributerController(AppDBContext dbContext)
        {
            recRepo = new RecipeRepository(dbContext);
        }
        [HttpDelete("RecpiceId")]
        public IActionResult DeleteApprovingRecipe(Recipe rec)
        {
            try
            {
                var recID = (rec.RecipeID);
                if (recID == null)
                {
                    return NotFound();
                }
                rec.Status = "false";
                recRepo.UpdateRecipe(rec);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> ApprovedRecpice(Guid repciceID, Recipe rec)
        {

            if (repciceID != rec.RecipeID)
            {
                return BadRequest();
            }
            try
            {
                rec.Status = "true";
                recRepo.UpdateRecipe(rec);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (recRepo.GetRecipesById(repciceID) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();

        }
    }
}
