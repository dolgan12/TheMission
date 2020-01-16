using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TheMission.API.Models;

namespace TheMission.API.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Users.Any() && !context.Skills.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeed.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();
                    context.Users.Add(user);
                }

                context.SaveChanges();

                var skillData = System.IO.File.ReadAllText("Data/SkillSeed.json");
                var skills = JsonConvert.DeserializeObject<List<Skill>>(skillData);

                foreach (var skill in skills)
                {
                    context.Skills.Add(skill);
                }
                context.SaveChanges();              
                
            }
            
        }

        public static void SeedSkills(DataContext context) {
            
        }

         private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }
    }
}