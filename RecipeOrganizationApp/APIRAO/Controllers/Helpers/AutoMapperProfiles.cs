using APIRAO.Controllers.DTOs.Recipe;
using AutoMapper;
using BusinessObjects;

namespace APIRAO.Controllers.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Recipe, CreateRecipeDTO>();

            CreateMap<CreateRecipeDTO, Recipe>();

        }
    }
}
