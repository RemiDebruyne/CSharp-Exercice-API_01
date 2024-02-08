using Exercice_API_01.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Exercice_API_01.Models


{
    public class Contact : BaseModel
    {
        [Column("first_name")]
        [Required]
        public string? FirstName { get; set; }
        [Column("last_name")]
        [Required]
        public string? LastName { get; set; }

        [Required]
        [PasswordValidator]
        public string Password { get; set; }

        [Column("birth_date")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Column("gender")]
        [Required]
        public string Gender { get; set; }
    }
}
