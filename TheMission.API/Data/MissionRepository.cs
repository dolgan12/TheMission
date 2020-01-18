using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheMission.API.Models;
using TheMission.API.Models.Dtos;

namespace TheMission.API.Data
{
    public class MissionRepository : IMissionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MissionRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<UserWithSkillsDto> GetUser(int userId)
        {

           var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

           var userToReturn = _mapper.Map<UserWithSkillsDto>(user);

           var skills = (from u in _context.Users
                        join us in _context.UserSkills on u.UserId equals us.UserId
                        join sk in _context.Skills on us.SkillId equals sk.SkillId
                        where u.UserId == userId
                        select new SkillsAndScoreDto {
                            SkillName = sk.SkillName,
                            Score = us.Score
                        })
                        .ToListAsync();
            userToReturn.Skills = await skills;
           
            return userToReturn;
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            var skills = await _context.Skills.ToListAsync();
            return skills;
        }
        public async Task<SkillWithUsersDto> GetSkill(int skillId)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillId == skillId);
            
            var skillToReturn = _mapper.Map<SkillWithUsersDto>(skill);


            var scores = (from sk in _context.Skills
                        join us in _context.UserSkills on sk.SkillId equals us.SkillId
                        join u in _context.Users on us.UserId equals u.UserId
                        where sk.SkillId == skillId
                        select new UserScore {
                           UserName = u.Username,
                           Score = us.Score
                        })
                        .ToListAsync();
            
            skillToReturn.UserScores = await scores;

            return skillToReturn;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        
        public async Task<bool> AddSkill(SkillToAddDto skillToAdd)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillName == skillToAdd.SkillName);
            if (skill == null)
            {
                var newSkill = new Skill();
                newSkill.SkillName = skillToAdd.SkillName;
                this.Add<Skill>(newSkill);
                await SaveAll();

                skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillName == skillToAdd.SkillName);
            }
            
            var userSkill = await _context.UserSkills.FirstOrDefaultAsync(us => us.UserId == skillToAdd.UserId && us.SkillId == skill.SkillId);

            if (userSkill != null)
            {
                return false;
            }
            var newUserSkill = new UserSkill();
            newUserSkill.SkillId = skill.SkillId;
            newUserSkill.UserId = skillToAdd.UserId;
            newUserSkill.Score = skillToAdd.SkillScore;
            
            this.Add<UserSkill>(newUserSkill);

            return await this.SaveAll();

        }

        public async Task<UserSkill> GetUserSkill(int userId, string skillName)
        {
            var skillFromRepo = await _context.Skills.FirstOrDefaultAsync(s => s.SkillName == skillName);
            return await _context.UserSkills.FirstOrDefaultAsync(us => us.UserId == userId && us.SkillId == skillFromRepo.SkillId);
        }

        public async Task<IEnumerable<UserScore>> GetUsersWithSkill(int skillId)
        {
            var userSkills = (from us in _context.UserSkills
                            join u in _context.Users on us.UserId equals u.UserId
                            where us.SkillId == skillId
                            orderby us.Score
                            select new UserScore {
                           UserName = u.Username,
                           Score = us.Score
                        }).ToListAsync();

            return await userSkills;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}