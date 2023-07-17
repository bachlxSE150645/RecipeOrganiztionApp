using AutoMapper;
using BusinessObjects;


namespace BusinessObjects
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Account, SignUpData>().ReverseMap();
        }
    }
}
