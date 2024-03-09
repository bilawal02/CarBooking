using CarBookingModels.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarBookingWeb.Models
{
    public class Car:BaseDomainEntity
    {
        //[Key]
        //[Display(Name ="Id")]
        //public int CarId { get; set; }

        [Required(ErrorMessage ="Year is Required")]
        [Display(Name = "Manufacture Year")]
        public int Year { get; set; }

        //[Required(ErrorMessage = "Name is Required")]
        //public string Name { get; set; }
        //[Required(ErrorMessage = "Model is Required")]
        //public string Model { get; set; }
        [Display(Name = "Car Model")]
        public int? CarModelId { get; set; }
        [ValidateNever]
        public virtual CarModel CarModel { get; set; }

        //[Required(ErrorMessage ="Car Maker is Required")]
        //public int CarMakerId { get; set; }
        [Display(Name ="Car Maker")]
        public int? CarMakerId { get; set; }
        [ValidateNever]
        public virtual CarMaker CarMaker { get; set; }

        [Display(Name = "Car Color")]
        public int? CarColorId { get; set; }
        [ValidateNever]
        public virtual CarColor CarColor { get; set; }

        [Required(ErrorMessage = "License Plate Number is Required")]
        [StringLength(7)]
        [Display(Name = "License Plate Number")]
        public string LicensePlateNumber { get; set; }
    }
}
