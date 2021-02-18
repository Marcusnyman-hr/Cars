using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_mn.Models
{
  public class City
  {
    public int Id { get; set; }
    [Required]
    [StringLength(20)]
    [Display(Name = "City Name")]
    public string Name { get; set; }
  }
}
