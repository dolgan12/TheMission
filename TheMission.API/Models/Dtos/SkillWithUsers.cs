using System.Collections.Generic;

namespace TheMission.API.Models.Dtos
{
    public class SkillWithUsers
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public IEnumerable<UserScore> UserScores { get; set; }
    }
}