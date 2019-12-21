using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Brand:IValidatableObject
    {
        [Required]
        [Key]
        [Display(Name = "Brand ID")]
        public int BrandId { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Description.Any(Char.IsWhiteSpace))
                yield return new ValidationResult("Write Description correctly");
        }
    }
}
