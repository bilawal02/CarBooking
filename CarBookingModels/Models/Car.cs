using CarBookingModels.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarBookingWeb.Models
{
    public class Car
    {
        [Key]
        [Display(Name ="Id")]
        public int CarId { get; set; }
        [Required(ErrorMessage ="Year is Required")]
        public int Year { get; set; }
        //[Required(ErrorMessage = "Name is Required")]
        //public string Name { get; set; }
        [Required(ErrorMessage = "Model is Required")]
        public string Model { get; set; }
        //[Required(ErrorMessage ="Car Maker is Required")]
        //public int CarMakerId { get; set; }
        [Display(Name ="Car Maker")]
        public int? CarMakerId { get; set; }
        [ValidateNever]
        public virtual CarMaker CarMaker { get; set; }
    }
}
