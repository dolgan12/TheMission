using System.Collections.Generic;

namespace TheMission.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<UserSkill> UserSkills {get; set;}
    }
}