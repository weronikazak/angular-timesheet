using System.Linq;
using AutoMapper;
using TimeSheet.API.Data;
using TimeSheet.API.Dto;

namespace TimeSheet.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            ///// DO POPRAWY
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.LastProject,
                    opt => opt.MapFrom(scr => scr.Projects.Where));
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForLoginDto>();
            CreateMap<User, UserForRegisterDto>();
        }
    }
}