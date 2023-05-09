using API.Entities;
using API.Entities.Homes;

using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<District> Districts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<House>(entity =>
{
    entity.ToTable("Houses");

    entity.HasKey(h => h.Id);

    entity.HasOne(h => h.AppUser)
        .WithMany(u => u.Houses)
        .HasForeignKey(h => h.AppUserId)
        .OnDelete(DeleteBehavior.Cascade);

    entity.HasMany(h => h.HouseCategories)
        .WithOne(hc => hc.House)
        .HasForeignKey(hc => hc.HouseId)
        .OnDelete(DeleteBehavior.Cascade);

    entity.HasMany(h => h.HouseTowns)
.WithOne(hc => hc.House)
.HasForeignKey(hc => hc.HouseId)
.OnDelete(DeleteBehavior.Cascade);

    entity.HasMany(h => h.HouseDistricts)
.WithOne(hc => hc.House)
.HasForeignKey(hc => hc.HouseId)
.OnDelete(DeleteBehavior.Cascade);


});

            ///Town
            modelBuilder.Entity<Town>(entity =>
            {
                entity.ToTable("Towns");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .IsRequired();
            });

            modelBuilder.Entity<HouseTown>(entity =>
         {
             entity.ToTable("HouseTowns");

             entity.HasKey(hc => new { hc.HouseId, hc.TownId });



             entity.HasOne(hc => hc.House)
                 .WithMany(h => h.HouseTowns)
                 .HasForeignKey(hc => hc.HouseId)
                 .OnDelete(DeleteBehavior.Cascade);

             entity.HasOne(hc => hc.Town)
                 .WithMany(c => c.HouseTowns)
                 .HasForeignKey(hc => hc.TownId)
                 .OnDelete(DeleteBehavior.Cascade);
         });



            ///District
            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("Districts");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .IsRequired();
            });

            modelBuilder.Entity<HouseDistrict>(entity =>
         {
             entity.ToTable("HouseDistricts");

             entity.HasKey(hc => new { hc.HouseId, hc.DistrictId });

             entity.HasOne(hc => hc.House)
                 .WithMany(h => h.HouseDistricts)
                 .HasForeignKey(hc => hc.HouseId)
                 .OnDelete(DeleteBehavior.Cascade);

             entity.HasOne(hc => hc.District)
                 .WithMany(c => c.HouseDistricts)
                 .HasForeignKey(hc => hc.DistrictId)
                 .OnDelete(DeleteBehavior.Cascade);
         });





            ///Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .IsRequired();
            });

            modelBuilder.Entity<HouseCategory>(entity =>
         {
             entity.ToTable("HouseCategories");

             entity.HasKey(hc => new { hc.HouseId, hc.CategoryId });

             entity.HasOne(hc => hc.House)
                 .WithMany(h => h.HouseCategories)
                 .HasForeignKey(hc => hc.HouseId)
                 .OnDelete(DeleteBehavior.Cascade);

             entity.HasOne(hc => hc.Category)
                 .WithMany(c => c.HouseCategories)
                 .HasForeignKey(hc => hc.CategoryId)
                 .OnDelete(DeleteBehavior.Cascade);
         });





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