using RoomScheduler.Web.InputModels;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RoomScheduler.Web.Validation
{
    public class ValidDurationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string hours = (string)value;

            FormFilterInputModel inputModel = (FormFilterInputModel)validationContext.ObjectInstance;
            string duration = hours + inputModel.Minutes;

            if (!Regex.IsMatch(duration, @"^0[0-6]:(00|15|30|45)$"))
            {
                return new ValidationResult("Duration is not in correct format.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
