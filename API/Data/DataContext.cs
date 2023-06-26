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
        public DbSet<HouseLike> HouseLikes { get; set; }
        public DbSet<Message> Messages { get; set; }





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

            modelBuilder.Entity<HouseLike>()
                .HasKey(hl => new { hl.AppUserId, hl.HouseId });

            modelBuilder.Entity<HouseLike>()
                .HasOne(hl => hl.AppUser)
                .WithMany(au => au.LikedHouses)
                .HasForeignKey(hl => hl.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HouseLike>()
                .HasOne(hl => hl.House)
                .WithMany(h => h.LikedByUsers)
                .HasForeignKey(hl => hl.HouseId)
                .OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Entity<Message>()
                .HasOne(u=>u.Recipient)
                .WithMany(m=>m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);
                
                       modelBuilder.Entity<Message>()
                .HasOne(u=>u.Sender)
                .WithMany(m=>m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);



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