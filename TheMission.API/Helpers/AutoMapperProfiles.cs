using AutoMapper;
using TheMission.API.Models;
using TheMission.API.Models.Dtos;

namespace TheMission.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(
                    dest => dest.UserSkills,
                    opt => opt.MapFrom(src => src.UserSkills)
                );
                
            CreateMap<Skill, SkillForListDto>()
                .ForMember(
                    dest => dest.UserSkills,
                    opt => opt.MapFrom(src => src.UserSkills)
                );
            CreateMap<UserSkill, UserSkillForListDto>();
            CreateMap<User, UserForSkillDto>();
            CreateMap<Skill, SkillWithUsers>();
        }
    }
}