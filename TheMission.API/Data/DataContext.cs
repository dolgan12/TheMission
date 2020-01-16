using Microsoft.EntityFrameworkCore;
using TheMission.API.Models;

namespace TheMission.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Skill>()
                .HasIndex(s => s.SkillName)
                .IsUnique();

            builder.Entity<UserSkill>()
                .HasKey(c => new {c.UserId, c.SkillId});
        }
    }
}