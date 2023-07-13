using AutoMapper;
using BusinessObjects;
using BusinessObjects.MapData;
using Repository.DTOs.Recipe;

namespace APIRAO.Controllers.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Recipe, CreateRecipeDTO>().ReverseMap();
            CreateMap<RecipeDetail, RecipeIngredientDTO>().ReverseMap();
            CreateMap<Meal, RecipeMealDTO>().ReverseMap();
        }
    }
}
