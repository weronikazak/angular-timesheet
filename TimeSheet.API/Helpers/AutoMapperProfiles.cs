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
            CreateMap<User, UserForListDto>().ReverseMap();
            CreateMap<User, UserForLoginDto>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            ///// DO POPRAWY
            CreateMap<User, UserForDetailedDto>().ReverseMap();
            CreateMap<UserForUpdateDto, User>().ReverseMap();
            CreateMap<ProjectForListDto, Project>().ReverseMap();
            CreateMap<ProjectForDetailedDto, Project>().ReverseMap();
                // .ForMember(dest => dest.LastProject,
                //     opt => opt.MapFrom
                //         (scr => scr.Projects.Where(a => a.ProjectId));
        }
    }
}