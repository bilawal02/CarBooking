using System.ComponentModel.DataAnnotations;

namespace CarBookingWeb.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required(ErrorMessage ="Year is Required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
    }
}
