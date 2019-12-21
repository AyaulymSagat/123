using CarRent.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Passport : IValidatableObject
    {
        [Display(Name = "Passport Id")]
        [Key]
        public int passportID { get; set; }


        [Display(Name = "Passport Serial Number")]
        [CheckIFSerialNumberCorrect(ErrorMessage = "Serial Number length should be 5")]
        public int No { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistationDate { get; set; }

        [Display(Name = "Passport Level")]
        [Remote(action: "IsValidLevel", controller: "Passports")]
        public string Level { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Level.Length<1 || Level.Length>3)
                yield return new ValidationResult("Input 'Level' should be at least 1 and not bigger than 2");

           
        }
    }
}
