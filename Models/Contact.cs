using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Exercice_API_01.Models


{
    public class Contact
    {
        private int _id;
        [RegularExpression(@"^[A-Z].")]
        private string _firstName;

        [RegularExpression(@"^[A-Z\-]*")]
        
        private string _lastName;

        private readonly string? _fullName;

        private readonly int _age;

        private bool _isMale;

        private string _birthDate;

        public int Id { get => _id; set => _id = value; }

        [NotNull]
        public string FirstName { get => _firstName; set => _firstName = value; }

        public string LastName { get => _lastName; set => _lastName = value; }
        public string FullName => _fullName;
        public int Age => _age;
        public bool IsMale { get => _isMale; set => _isMale = value; }

        [DataType(DataType.DateTime)]
        public string BirthDate { get => _birthDate; set => _birthDate = value; }


        public Contact()
        {
            _fullName = FirstName + " " + LastName;
            //_age = Date d'aujourdhui - Date de naissance
        }
    }
}
