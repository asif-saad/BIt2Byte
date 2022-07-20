using System.ComponentModel.DataAnnotations;

namespace Bit2Byte.Helpers
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {


        public MyCustomValidationAttribute(string Text)
        {
            text = Text;
        }

        public string text { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value != null)
            {
                string achieveName = value.ToString();
                if (achieveName.Contains(text))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Achievement does not contain the desired value");
        }


    }
}
