using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_VillaAPI.Models.DTO;

public class VillaDTO
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    public int Occupancy { get; set; }
    public int Sqft { get; set; }
    [MaxLength(255)]
    public string Details { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public double Rate { get; set; }
    [Url]
    public string ImageUrl { get; set; }
    [MaxLength(255)]
    public string Amenity { get; set; }
}
