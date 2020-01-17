using AutoMapper;
using TheMission.API.Models;
using TheMission.API.Models.Dtos;

namespace TheMission.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
                
            CreateMap<Skill, SkillForListDto>();
            CreateMap<UserSkill, UserSkillForListDto>();
            CreateMap<User, UserForSkillDto>();
            CreateMap<Skill, SkillWithUsersDto>();
            CreateMap<User, UserWithSkillsDto>();
        }
    }
}