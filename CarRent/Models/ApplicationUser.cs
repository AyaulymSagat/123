using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Messages = new HashSet<Message>();
        }

        public string City { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

    }
}
