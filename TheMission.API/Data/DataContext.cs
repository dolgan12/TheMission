using Microsoft.EntityFrameworkCore;
using TheMission.API.Models;

namespace TheMission.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
    }
}