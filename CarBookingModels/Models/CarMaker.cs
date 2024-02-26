using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingModels.Models
{
    public class CarMaker
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="Car Maker")]
        public string Name { get; set; }
        [ValidateNever]
        public virtual List<Car> Cars { get; set; }
    }
}
