using System.Collections.Generic;
using System.Threading.Tasks;
using TheMission.API.Models;
using TheMission.API.Models.Dtos;

namespace TheMission.API.Data
{
    public interface IMissionRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<UserWithSkillsDto> GetUser(int userId);
         Task<IEnumerable<Skill>> GetSkills();
         Task<SkillWithUsersDto> GetSkill(int id);

         Task<bool> AddSkill(SkillToAddDto skill);
         Task<UserSkill> GetUserSkill(int userId, string skillName);
         Task<IEnumerable<UserScore>> GetUsersWithSkill(int skillId);
    }
}