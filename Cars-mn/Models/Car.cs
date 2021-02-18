using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_mn.Models
{
  public class Car
  {
    public int Id { get; set; }
    [Display(Name = "Manufacturer")]
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    [Required]
    [MaxLength(20)]
    public string Model { get; set; }
    [Display(Name = "Engine Type")]
    public int EngineTypeId { get; set; }
    public EngineType EngineType { get; set; }
    public int Year { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    [Display(Name = "Dealer Name")]
    public int DealerId { get; set; }
    public Dealer Dealer { get; set; }
  }
}
