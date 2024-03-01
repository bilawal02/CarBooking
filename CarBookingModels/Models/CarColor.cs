using CarBookingModels.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CarBookingWeb.Models
{
    public class CarColor : BaseDomainEntity
    {
        //[Key]
        //public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Car Color")]
        public string Name { get; set; }
        [ValidateNever]
        public virtual List<Car> Cars { get; set; }
    }
}