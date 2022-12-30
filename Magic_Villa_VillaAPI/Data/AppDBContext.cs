using Magic_Villa_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Magic_Villa_VillaAPI.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Villa> Villas { get; set; }

    public DbSet<VillaNumber> VillaNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Villa>().HasData
            (
                new Villa()
                {
                    Id = 1,
                    Name = "Test Valla 1",
                    Details = "Testing Details here for you!",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 1200,
                    Amenity = "Testing amenity here!",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }, 
                new Villa()
                {
                    Id = 2,
                    Name = "Test Valla 2",
                    Details = "Testing Details here for you!",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                    Occupancy = 3,
                    Rate = 150,
                    Sqft = 1000,
                    Amenity = "Testing amenity here!",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },      
                new Villa()
                {
                    Id = 3,
                    Name = "Test Valla 3",
                    Details = "Testing Details here for you!",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                    Occupancy = 6,
                    Rate = 250,
                    Sqft = 1500,
                    Amenity = "Testing amenity here!",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
    }
}
