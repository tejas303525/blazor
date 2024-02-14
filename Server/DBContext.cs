using Microsoft.EntityFrameworkCore;
using proj1.Shared;


namespace proj1.Server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=UserDB.db");
        }

        public DbSet<UserHardcodedAccount> Users { get; set; } = null!;
    }
}