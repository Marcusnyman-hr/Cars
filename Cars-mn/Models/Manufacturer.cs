using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_mn.Models
{
  public class Manufacturer
  {
    public int Id { get; set; }
    [Required]
    [StringLength(10)]
    [Display(Name = "Manufacturer")]
    public string ManufacturerName { get; set; }
  }
}
