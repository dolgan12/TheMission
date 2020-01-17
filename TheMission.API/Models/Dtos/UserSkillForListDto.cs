namespace TheMission.API.Models.Dtos
{
    public class UserSkillForListDto
    {
        public int Score { get; set; }
        public virtual SkillForListDto Skill { get; set; }
        public virtual UserForSkillDto User {get; set;}
    }
}