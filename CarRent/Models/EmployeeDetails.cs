using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class EmployeeDetails
    {
        [Key]
        [ForeignKey("Employee")]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Display(Name = "Age")]
        [Range(18, 70, ErrorMessage = "Age should be bigger than 18")]
        public int? Age { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Country")]
        [Required]
        public string Country { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
