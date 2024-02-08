using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Exercice_API_01.Helper
{
    public class PasswordValidator :  Attribute
    {
        public class CustomAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object? value, ValidationContext context)
            {
                string str = value.ToString();


                if (str.Length < 8)
                    return new ValidationResult("Votre mot de passe doit contenir au minimum 8 caractères");
                if (Regex.Matches(str, "[a-z]").Count < 2)
                    return new ValidationResult("Votre mot doit contenir au moins 2 minuscule");
                if (Regex.Matches(str, "[A-Z]").Count < 2)
                    return new ValidationResult("Votre mot de passe doit contenir au moins 2 majuscules");
                if (Regex.Matches(str, "[0-9]").Count < 2)
                    return new ValidationResult("Votre mot de passe doit contenir au moins 2 chiffres");
                if (Regex.Matches(str, "[.+*?!:;,^@/$(){}|]").Count < 2)
                    return new ValidationResult("Votre mot de passe doit contenir au moins 2 caractères spéciaux");
                return ValidationResult.Success;
                // [A-Z]{2,}[0-9]{2,}[.+*?!:;,^@/$(){}|]{2,}
            }
        }
    }
}
