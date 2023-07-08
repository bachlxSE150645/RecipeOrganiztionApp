using AutoMapper;
using BusinessObjects;
using Repository.DTOs.Recipe;

namespace APIRAO.Controllers.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Recipe, CreateRecipeDTO>().ReverseMap();
            CreateMap<RecipeDetail, RecipeIngredientDTO>().ReverseMap();
        }
    }
}
