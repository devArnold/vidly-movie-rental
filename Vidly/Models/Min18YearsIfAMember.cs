using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year >= 18 ?
                ValidationResult.Success : new ValidationResult("Customer should be atleast 18 years old");

            return age;

        }
    }
}