
using System.Collections.Generic;

namespace TheMission.API.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}