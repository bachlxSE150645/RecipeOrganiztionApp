﻿using BusinessObjects;
using BusinessObjects.MapData;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace DataAccess
{
    public class MealDAO
    {
        private readonly AppDBContext _context;

        public MealDAO(AppDBContext context)
        {
            this._context = context;
        }

        //Get All Meals
        public List<Meal> GetMeals()
        {
            try
            {
                return this._context.Meals
                    .Include(c => c.Account)
                    .Include(c => c.Recipe)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Meal> GetMealsByName(string mealName)
        {
            var meal = new List<Meal>();
            try
            {
                meal = this._context.Meals
                    .Include(c => c.Account)
                    .Include(c => c.Recipe)
                    .Where(x => x.Recipe.RecipeName.Contains(mealName) && x.Status.Equals("onsale"))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return meal;
        }

        //Get Meal matches ID
        public Meal GetMealsById(Guid id)
        {
            var meal = new Meal();
            try
            {

                meal = _context.Meals
                    .Include(c => c.Account)
                    .Include(c => c.Recipe)
                    .Where(x => x.MealID.Equals(id) && x.Status.Equals("onsale")).SingleOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return meal;
        }

        //Post new Meal
        public Meal AddMeal(MealData meal)
        {
            try
            {
                var mealCheck = _context.Meals.SingleOrDefault(x => x.AccountID == meal.AccountID && x.RecipeID == meal.RecipeID);
                if(mealCheck == null)
                {
                    var mealAdd = new Meal
                    {
                        MealID = Guid.NewGuid(),
                        AccountID = meal.AccountID,
                        RecipeID = meal.RecipeID,
                        Price = meal.Price,
                        Description = meal.Description,
                        Status = "onsale",
                        Account = _context.Accounts.SingleOrDefault(c => c.AccountID == meal.AccountID),
                        Recipe = _context.Recipes.SingleOrDefault(c => c.RecipeID == meal.RecipeID)
                    };
                    _context.Meals.Add(mealAdd);
                    _context.SaveChanges();
                    return mealAdd;
                }
                else
                {
                    if(mealCheck.Status == "onsale")
                    {
                        return null;
                    } else if(mealCheck.Status == "saleout")
                    {
                        UpdateMeal(mealCheck.MealID, (decimal)mealCheck.Price, mealCheck.Description, true);
                        return mealCheck;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Meal
        public Meal UpdateMeal(Guid mealID, decimal mealPrice, string mealDescription, bool saleornot)
        {
            try
            {
                var Meal = _context.Meals.SingleOrDefault(x => x.MealID == mealID);
                if (Meal != null)
                {
                    Meal.Price = mealPrice;
                    Meal.Description = mealDescription;
                    if(saleornot == true)
                    {
                        Meal.Status = "onsale";
                    }

                    _context.Entry<Meal>(Meal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
                return Meal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Meal
        public bool DeleteMeal(Guid mealID)
        {
            try
            {
                bool check = false;
                var Meals = _context.Meals.SingleOrDefault(x => x.MealID.Equals(mealID));
                if (Meals != null)
                {
                    Meals.Status = "saleout";
                    _context.Meals.Update(Meals);
                    _context.SaveChanges();
                    check = true;
                }
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Meal GetMealByRecipeId(Guid recipeId)
        {
            try
            {

                var  meal = _context.Meals
                    .Where(x => Guid.Equals(x.RecipeID, recipeId))
                    .Include(c => c.Account)
                    .Include(c => c.Recipe).FirstOrDefault();
                return meal;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}