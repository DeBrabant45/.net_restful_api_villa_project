using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_Web.Domain.Models.DTO;

public class VillaNumberDTO
{
    [Required]
    public int Number { get; set; }

    [Required]
    public int VillaId { get; set; }

    [MaxLength(255)]
    public string Details { get; set; }

    public VillaDTO Villa { get; set; }
}
