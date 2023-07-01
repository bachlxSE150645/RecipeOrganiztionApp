﻿using BusinessObjects;
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
        public IActionResult DeleteApprovingRecipe(Guid recId)
        {
            try
            {
                if (recId == null)
                {
                    return NotFound();
                }
                var rec = recRepo.GetRecipesById(recId);
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
        public async Task<IActionResult> ApprovedRecpice(Guid recId)
        {

            try
            {
                if (recId == null)
                {
                    return NotFound();
                }
                var rec = recRepo.GetRecipesById(recId);
                rec.Status = "true";
                recRepo.UpdateRecipe(rec);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }
    }
}
