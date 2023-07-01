using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTO;

namespace BusinessObjects
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Account, SignUpData>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
        }
    }
}
