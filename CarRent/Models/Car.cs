using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Car:IValidatableObject
    {
        [Display(Name = "Car ID")]
        [Key]
        public int carID { get; set; }

        [Display(Name = "Car Name")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Car Name cannot be longer than 255 characters and less than 2 characters")]
        public string Name { get; set; }

        [Display(Name = "Car Image")]
        [Required]
        public string CarImage { get; set; }

        [Display(Name = "Car Model")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Car Model cannot be longer than 255 characters and less than 2 characters")]
        public string Model { get; set; }

        [Display(Name = "Car Cost Per Day")]
        public double price { get; set; }

        [Display(Name = "Car Year")]
        [Required]
        public int Year { get; set; }

        [Display(Name = "Car mileage")]
        public double Run { get; set; }

        public int BrandID { get; set; }

        public virtual Brand Brand { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (price < 0.0)
                yield return new ValidationResult("Input 'Run' cannot be negative");

            if (Run < 0.0)
                yield return new ValidationResult("Input 'Price' cannot be negative");

            if (Year<1980 || Year>2019)
                yield return new ValidationResult("Input 'Year' invalid year");
        }
    }
}
