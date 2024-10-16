using AutoMapper;
using IMF.Api.DTO.Common;
using IMF.DAL.Models.Common;
namespace IMF.Api.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyDTO, Company>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Company, CompanyDTO>();
        }
    }
}