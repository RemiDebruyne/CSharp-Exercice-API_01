using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Exercice_API_01.Models


{
    public class Contact : BaseModel
    {
        [Required]
        [RegularExpression(@"^[A-Z].*")]
        [Column("First_name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z].*")]
        [Column("Last_name")]
        public string LastName { get; set; }


        public string? FullName => FirstName + " " + LastName;


        public int Age
        {
            get
            {
                DateTime currentDate = DateTime.Today;
                int age = currentDate.Year - BirthDate.Year;

                // Vérifier si l'anniversaire de cette année est déjà passé
                if (BirthDate > currentDate.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }


        //static int GetAge(DateTime birthDate)
        //{
        //    DateTime currentDate = DateTime.Today;
        //    int age = currentDate.Year - birthDate.Year;

        //    // Vérifier si l'anniversaire de cette année est déjà passé
        //    if (birthDate > currentDate.AddYears(-age))
        //    {
        //        age--;
        //    }

        //    return age;
        //}
    }
}
