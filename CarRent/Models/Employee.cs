using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Employee
    {
        [Display(Name = "Employee ID")]
        [Key]
        public int EmployeeID { get; set; }

        [Display(Name = "Employee Email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required, MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Display(Name = "Employee Surname")]
        [Required, MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters")]
        public string Surname { get; set; }

        [Display(Name = "Passport")]
        public int passportID { get; set; }

        public virtual Passport Passport { get; set; }
        public virtual EmployeeDetails EmployeeDetails { get; set; }

    }
}
