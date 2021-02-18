using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_mn.Models
{
  public class Dealer
  {
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    [Display(Name = "Dealer Name")]
    public string Name { get; set; }
    [Display(Name = "City")]
    public int CityId { get; set; }
    public City City { get; set; }
    public List<Car> Cars { get; set; }
  }
}
