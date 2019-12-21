using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class RentedCars
    {
        [Display(Name = "Rent ID")]
        public int ID { get; set; }

        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
