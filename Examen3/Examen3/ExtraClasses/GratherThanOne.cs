using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GreaterThanOne : ValidationAttribute
    {
        public static ValidationResult ValidationCantity(decimal cantity)
        {
            if (cantity >= 1)
                return ValidationResult.Success;
            else
                return new ValidationResult("Introduce una cantidad superior a 1");
        }
    }
}
