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
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<UserLoginInfo> UserLoginInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserLoginInfo>()
           .Property(e => e.Password)
           .HasColumnType("binary(64)");

            modelBuilder.Entity<Countries>()
           .HasKey(e => e.id); // Set Id as primary key

            modelBuilder.Entity<Countries>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd(); // Ensure auto-increment

            modelBuilder.Entity<Provinces>()
           .HasKey(e => e.id); // Set Id as primary key

            modelBuilder.Entity<Provinces>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd(); // Ensure auto-increment

            modelBuilder.Entity<Cities>()
           .HasKey(e => e.id); // Set Id as primary key

            modelBuilder.Entity<Cities>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd(); // Ensure auto-increment

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
            //setup Foreign Key
            modelBuilder.Entity<Provinces>()
              .HasOne(c => c.Countries)
              .WithMany(p => p.Children)
              .HasForeignKey(c => c.CountryFKID)
              .OnDelete(DeleteBehavior.Cascade);
            //setup Foreign Key
            modelBuilder.Entity<Cities>()
             .HasOne(c => c.Provinces)
             .WithMany(p => p.Children)
             .HasForeignKey(c => c.ProvinceFKID)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
