using System;
using System.ComponentModel.DataAnnotations;

namespace RoomScheduler.Web.Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;

            if (date.Date < DateTime.Today.Date)
            {
                return new ValidationResult("Date should be greater than today.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
