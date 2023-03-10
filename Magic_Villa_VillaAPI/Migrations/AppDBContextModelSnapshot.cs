// <auto-generated />
using System;
using Magic_Villa_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVillaVillaAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Magic_Villa_VillaAPI.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "Testing amenity here!",
                            CreatedDate = new DateTime(2023, 1, 2, 11, 43, 2, 739, DateTimeKind.Local).AddTicks(732),
                            Details = "Testing Details here for you!",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                            Name = "Test Valla 1",
                            Occupancy = 5,
                            Rate = 200.0,
                            Sqft = 1200,
                            UpdatedDate = new DateTime(2023, 1, 2, 11, 43, 2, 739, DateTimeKind.Local).AddTicks(778)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Testing amenity here!",
                            CreatedDate = new DateTime(2023, 1, 2, 11, 43, 2, 739, DateTimeKind.Local).AddTicks(782),
                            Details = "Testing Details here for you!",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                            Name = "Test Valla 2",
                            Occupancy = 3,
                            Rate = 150.0,
                            Sqft = 1000,
                            UpdatedDate = new DateTime(2023, 1, 2, 11, 43, 2, 739, DateTimeKind.Local).AddTicks(784)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Testing amenity here!",
                            CreatedDate = new DateTime(2023, 1, 2, 11, 43, 2, 739, DateTimeKind.Local).AddTicks(787),
                            Details = "Testing Details here for you!",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                            Name = "Test Valla 3",
                            Occupancy = 6,
                            Rate = 250.0,
                            Sqft = 1500,
                            UpdatedDate = new DateTime(2023, 1, 2, 11, 43, 2, 739, DateTimeKind.Local).AddTicks(789)
                        });
                });

            modelBuilder.Entity("Magic_Villa_VillaAPI.Models.VillaNumber", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("VillaId");

                    b.ToTable("VillaNumbers");
                });

            modelBuilder.Entity("Magic_Villa_VillaAPI.Models.VillaNumber", b =>
                {
                    b.HasOne("Magic_Villa_VillaAPI.Models.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
