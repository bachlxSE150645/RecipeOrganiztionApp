﻿using BusinessObjects;
using BusinessObjects.MapData;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealRepository mealRepo;

        public MealController(IMealRepository _mealRepository)
        {
            this.mealRepo = _mealRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeals(string? mealName = "")
        {
            if (string.IsNullOrWhiteSpace(mealName))
            {
                return Ok(mealRepo.GetAllMeals());
            }
            else
            {
                List<Meal> meal = mealRepo.GetMealsByName(mealName);
                return Ok(await Task.FromResult(meal));
            }
        }

        [HttpGet("{MealId}")]
        public async Task<IActionResult> GetMealByID(Guid MealId)
        {
            try
            {
                return Ok(mealRepo.GetMealsById(MealId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostMeal(MealData inf)
        {
            var result = mealRepo.AddMeal(inf);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }

        [HttpDelete("{MealId}")]
        public async Task<IActionResult> DeleteMeal(Guid MealId)
        {
            var rs = mealRepo.DeleteMeal(MealId);
            if (rs == null)
            {
                return BadRequest(rs);
            }

            return Ok(rs);
        }

        [HttpPut("{mealid}")]
        public async Task<IActionResult> Updatemeal(Guid mealid, decimal mealPrice, string mealDescription, bool saleornot)
        {
            var result = mealRepo.UpdateMeal(mealid, mealPrice, mealDescription, saleornot);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
