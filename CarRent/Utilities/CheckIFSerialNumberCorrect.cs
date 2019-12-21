using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Utilities
{
    public class CheckIFSerialNumberCorrect: ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            return value.ToString().Length==5;

        }

    }
}
