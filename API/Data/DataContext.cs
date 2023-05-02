using API.Entities;
using API.Entities.Homes;
using API.Entities.Location;

using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<HouseLocation> HouseLocations { get; set; }
        public DbSet<HouseCategory> HouseCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<District> Districts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                 .HasMany(u => u.Houses)
                 .WithOne(a => a.AppUser)
                 .HasForeignKey(a => a.AppUserId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HouseLocation>()
             .HasKey(hl => hl.Id);

            modelBuilder.Entity<HouseLocation>()
                .HasOne(hl => hl.House)
                .WithMany(h => h.HouseLocations)
                .HasForeignKey(hl => hl.HouseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HouseLocation>()
                .HasOne(hl => hl.City)
                .WithMany()
                .HasForeignKey(hl => hl.LocationCityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HouseLocation>()
                .HasOne(hl => hl.Town)
                .WithMany()
                .HasForeignKey(hl => hl.LocationTownId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HouseLocation>()
                .HasOne(hl => hl.District)
                .WithMany()
                .HasForeignKey(hl => hl.LocationDistrictId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Category>()
                   .HasKey(c => c.Id);

            modelBuilder.Entity<HouseCategory>()
                .HasKey(hc => new { hc.HouseId, hc.ChoosenCategoryId });

            modelBuilder.Entity<HouseCategory>()
                .HasOne(hc => hc.House)
                .WithMany(h => h.HouseCategories)
                .HasForeignKey(hc => hc.HouseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HouseCategory>()
                .HasOne(hc => hc.Category)
                .WithMany(c => c.HouseCategories)
                .HasForeignKey(hc => hc.ChoosenCategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<House>()
       .Property(a => a.Price)
       .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<House>()
            .Property(h => h.Square)
            .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<House>()
           .Property(h => h.Gross)
           .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<House>()
        .Property(h => h.Dues)
        .HasColumnType("decimal(18,2)");


        }


    }

}