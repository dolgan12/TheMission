using System.Collections.Generic;

namespace TheMission.API.Models.Dtos
{
    public class UserWithSkillsDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public IEnumerable<SkillsAndScoreDto> Skills { get; set; }
    }
}