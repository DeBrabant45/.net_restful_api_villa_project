using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_VillaAPI.Models.DTO;

public class VillaNumberUpdateDTO
{
    [Required]
    public int Number { get; set; }
    [Required]
    public int VillaId { get; set; }
    [MaxLength(255)]
    public string Details { get; set; }
}
