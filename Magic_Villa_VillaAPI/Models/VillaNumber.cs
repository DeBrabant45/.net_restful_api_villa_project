﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic_Villa_VillaAPI.Models;

public class VillaNumber
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Number { get; set; }

    [MaxLength(255)]
    public string Details { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set;}

    [ForeignKey(nameof(Villa))]
    public int VillaId { get; set; }

    public Villa Villa { get; set; }
}
