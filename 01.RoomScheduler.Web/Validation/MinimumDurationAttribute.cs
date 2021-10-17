using RoomScheduler.Web.InputModels;
using System.ComponentModel.DataAnnotations;

namespace RoomScheduler.Web.Validation
{
    public class MinimumDurationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string hours = (string)value;

            FormFilterInputModel inputModel = (FormFilterInputModel)validationContext.ObjectInstance;

            if (hours == "00" && inputModel.Minutes == ":00")
            {
                return new ValidationResult("Duration should be at least 00:15");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
