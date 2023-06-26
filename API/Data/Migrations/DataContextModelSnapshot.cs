﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("API.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("API.Entities.Homes.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Balcony")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bathroom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("BusStop")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ComplexName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Credit")
                        .HasColumnType("bit");

                    b.Property<string>("Deed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Dues")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Exchange")
                        .HasColumnType("bit");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Furnish")
                        .HasColumnType("bit");

                    b.Property<bool?>("Generator")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Gross")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Gym")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasChimney")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasEastFrontage")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasElevator")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasNorthFrontage")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasSouthFrontage")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasSteelDoors")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasWestFrontage")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasWifi")
                        .HasColumnType("bit");

                    b.Property<string>("Heath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Hospital")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("Lake")
                        .HasColumnType("bit");

                    b.Property<bool?>("Metro")
                        .HasColumnType("bit");

                    b.Property<bool?>("Nature")
                        .HasColumnType("bit");

                    b.Property<bool?>("Parking")
                        .HasColumnType("bit");

                    b.Property<bool?>("Pharmacy")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Room")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Satellite")
                        .HasColumnType("bit");

                    b.Property<bool?>("Sea")
                        .HasColumnType("bit");

                    b.Property<bool?>("ShoppingCenter")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Square")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("SwimmingPool")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.Property<bool?>("Tramvay")
                        .HasColumnType("bit");

                    b.Property<bool?>("Van")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("TownId");

                    b.ToTable("Houses", (string)null);
                });

            modelBuilder.Entity("API.Entities.HouseLike", b =>
                {
                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.HasKey("AppUserId", "HouseId");

                    b.HasIndex("HouseId");

                    b.ToTable("HouseLikes");
                });

            modelBuilder.Entity("API.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MessageSent")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RecipientDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<string>("RecipientUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SenderDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("SenderUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("API.Entities.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("API.Entities.Homes.House", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("Houses")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Category", "Category")
                        .WithMany("Houses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.District", "District")
                        .WithMany("Houses")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Town", "Town")
                        .WithMany("Houses")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Category");

                    b.Navigation("District");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("API.Entities.HouseLike", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("LikedHouses")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("API.Entities.Homes.House", "House")
                        .WithMany("LikedByUsers")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("House");
                });

            modelBuilder.Entity("API.Entities.Message", b =>
                {
                    b.HasOne("API.Entities.AppUser", "Recipient")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Entities.AppUser", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.HasOne("API.Entities.Homes.House", "House")
                        .WithMany("Photos")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("Houses");

                    b.Navigation("LikedHouses");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");
                });

            modelBuilder.Entity("API.Entities.Category", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("API.Entities.District", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("API.Entities.Homes.House", b =>
                {
                    b.Navigation("LikedByUsers");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("API.Entities.Town", b =>
                {
                    b.Navigation("Houses");
                });
#pragma warning restore 612, 618
        }
    }
}
