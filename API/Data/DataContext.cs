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

    entity.HasOne(h => h.Category)
           .WithMany(c => c.Houses)
           .HasForeignKey(h => h.CategoryId)
           .OnDelete(DeleteBehavior.Cascade);

    entity.HasOne(h => h.Town)
        .WithMany(t => t.Houses)
        .HasForeignKey(h => h.TownId)
        .OnDelete(DeleteBehavior.Cascade);

    entity.HasOne(h => h.District)
        .WithMany(d => d.Houses)
        .HasForeignKey(h => h.DistrictId)
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