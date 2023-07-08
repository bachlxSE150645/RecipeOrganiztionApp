using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.MapData;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class RecipeDetailDAO
    {
        private readonly AppDBContext _context;

        public RecipeDetailDAO(AppDBContext context)
        {
            _context = context;
        }

        //Get All Recipe Details
        public List<RecipeDetail> GetRecipeDetails()
        {
            try
            {
                return _context.RecipeDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Recipe Details by Recipe ID
        public List<RecipeDetail> GetRecipeDetailsByRecipeId(Guid recipeId)
        {
            try
            {
                return _context.RecipeDetails
                    .Where(x => Guid.Equals(x.RecipeID, recipeId))
                    .Include(c => c.Recipe)
                    .Include(c => c.Ingredient).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Recipe Details by Ingredient ID
        public List<RecipeDetail> GetRecipeDetailsByIngredientId(string ingredientId)
        {
            try
            {
                return _context.RecipeDetails.Where(x => x.IngredientID == Guid.Parse(ingredientId)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Recipe Detail by Recipe ID and Ingredient ID
        public RecipeDetail GetRecipeDetailsByRecIdAndIngId(string recId, string IngId)
        {
            try
            {
                return _context.RecipeDetails.SingleOrDefault(x => x.RecipeID == Guid.Parse(recId) && x.IngredientID == Guid.Parse(IngId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Recipe Detail
        public async Task<RecipeDetail> AddRecipeDetail(RecipeDetail inf)
        {
            try
            {
                _context.RecipeDetails.Add(inf);
                await _context.SaveChangesAsync();
                return inf;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Recipe by Recipe ID and Ingredient ID
        public void UpdateRecipeDetail(RecipeDetail recipeDetail)
        {
            try
            {
                var recipeDetailCheck = _context.RecipeDetails.SingleOrDefault(x => x.RecipeID == recipeDetail.RecipeID && x.IngredientID == recipeDetail.IngredientID);
                if (recipeDetailCheck != null)
                {
                    _context.Entry(recipeDetailCheck).CurrentValues.SetValues(recipeDetail);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Recipe Detail
        public void DeleteRecipeDetail(RecipeDetail recipeDetail)
        {
            try
            {
                var recipeDetailCheck = _context.RecipeDetails.SingleOrDefault(x => x.RecipeID == recipeDetail.RecipeID && x.IngredientID == recipeDetail.IngredientID);
                if (recipeDetailCheck != null)
                {
                    _context.RecipeDetails.Remove(recipeDetailCheck);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}