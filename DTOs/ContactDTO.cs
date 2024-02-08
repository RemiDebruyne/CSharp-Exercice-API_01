using System.ComponentModel.DataAnnotations;

namespace Exercice_API_01.DTOs
{
    public class ContactDTO
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][A-Za-z\- ]*", ErrorMessage = "FirstName must start with an uppercase letter !")]
        public string? FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z\- ]*", ErrorMessage = "LastName must be in uppercase !")]
        public string? LastName { get; set; }
        public string? FullName => FirstName + " " + LastName; // get => pas d'attribut/variable FullName
        [Required]
        //[JsonIgnore] // la prop sera ignorée pour la serialisation de l'objet
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get // get => pas d'attribut/variable age
            {
                int age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate > DateTime.Now.AddYears(-age)) //ajout de vérification mois/jour
                    age--;
                return age;
            }
        }
        [Required]
        public string? Gender { get; set; }
    }
}
