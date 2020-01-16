using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheMission.API.Models
{
    public class UserSkill
    {
        [Key, Column(Order = 0)]
        public virtual int UserId {get; set; }
        
        [Key, Column(Order = 1)]
        public int SkillId { get; set; }
        
        public int Score { get; set; }
        public virtual User User { get; set; }
        public virtual Skill Skill { get; set; }
    }
}