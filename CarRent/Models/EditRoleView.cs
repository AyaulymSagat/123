using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class EditRoleView
    {
        public EditRoleView()
        {
            Users = new List<string>();
        }
        public string ID { get; set; }

        [Required(ErrorMessage ="Role Name is required!!!")]
        public string roleName { get; set; }

        public List<string> Users { get; set; }


    }
}
