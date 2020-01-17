using System.Collections.Generic;

namespace TheMission.API.Models.Dtos
{
    public class UserForListDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }

         public virtual ICollection<UserSkillForListDto> UserSkills {get; set;}
    }

}