using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_Web.Domain.Models.DTO;

public class VillaUpdateDTO
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Name { get; set; }

    [Required]
    public int Occupancy { get; set; }

    [Required]
    public int Sqft { get; set; }

    [Required]
    [MaxLength(255)]
    public string Details { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public double Rate { get; set; }

    [Url]
    [Required]
    public string ImageUrl { get; set; }

    [Required]
    [MaxLength(255)]
    public string Amenity { get; set; }
}
