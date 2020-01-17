using System.Collections.Generic;

namespace TheMission.API.Models.Dtos
{
    public class SkillForListDto
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public virtual ICollection<UserSkillForListDto> UserSkills { get; set; }
    }
}