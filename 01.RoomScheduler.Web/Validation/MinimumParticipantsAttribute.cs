using System.ComponentModel.DataAnnotations;

namespace RoomScheduler.Web.Validation
{
    public class MinimumParticipantsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int participants = (int)value;

            if (participants < 2)
            {
                return new ValidationResult("Participants should be more than 2.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
