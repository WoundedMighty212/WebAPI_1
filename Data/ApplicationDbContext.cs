namespace WebAPI_1.Data
{
    using Microsoft.EntityFrameworkCore;
    using WebAPI_1.Models;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<UserLoginInfo> UserLoginInfo { get; set; }
    }
}
