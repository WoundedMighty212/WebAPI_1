namespace WebAPI_1.Data
{
    using Microsoft.EntityFrameworkCore;
    //using System.Reflection.Emit;
    //using System.Xml;
    using WebAPI_1.Models;
    using WebAPI_1.Models.RegistrationData;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            
        }
        public DbSet<Race> Race { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<UserLoginInfo> UserLoginInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserLoginInfo>()
           .Property(e => e.Password)
           .HasColumnType("binary(64)");

            modelBuilder.Entity<Race>()
            .HasKey(e => e.id); // Set Id as primary key

            modelBuilder.Entity<Race>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd(); // Ensure auto-increment

            modelBuilder.Entity<UserLoginInfo>()
            .HasKey(e => e.id); // Set Id as primary key

            modelBuilder.Entity<UserLoginInfo>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd(); // Ensure auto-increment

            modelBuilder.Entity<UserData>()
            .HasKey(e => e.id); // Set Id as primary key

            modelBuilder.Entity<UserData>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd(); // Ensure auto-increment

            //setup Foreign Key
            modelBuilder.Entity<UserData>()
               .HasOne(c => c.userLoginInfo)
               .WithMany(p => p.Children)
               .HasForeignKey(c => c.FKID)
               .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
