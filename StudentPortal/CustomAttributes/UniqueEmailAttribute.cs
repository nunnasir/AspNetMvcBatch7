using System.ComponentModel.DataAnnotations;

namespace StudentPortal.CustomAttributes
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = value?.ToString();
            var whiteListedDomain = new List<string> { "gmail.com", "yahoo.com" };


            if (email == "test@test.com")
            {
                return new ValidationResult("Email already taken");
            }

            return ValidationResult.Success;
        }
    }
}
