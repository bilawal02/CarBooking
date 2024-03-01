using CarBookingModels.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CarBookingWeb.Models
{
    public class CarModel : BaseDomainEntity
    {
        //[Key]
        //public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Car Model")]
        public string Name { get; set; }
        [ValidateNever]
        public virtual List<Car> Cars { get; set; }

        [Display(Name = "Car Maker")]
        public int? CarMakerId { get; set; }
        [ValidateNever]
        public virtual CarMaker CarMaker { get; set; }
    }
}