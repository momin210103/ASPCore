using System;
using ServiceContracts.Enums;
using Entities;
using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class PersonAddRequest
    {
        public Guid PersonID { get; set; }

        [Required(ErrorMessage = "PersonName is required")]
        public string? PersonName { get; set; }
        
        [Required(ErrorMessage = "Email cannot be blank")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public GenderOptions? Gender { get; set; }

        public Guid? CountryID { get; set; }

        public string? Address { get; set; }

        public bool ReceiveNewsLetters { get; set; }
        public Person ToPerson()
        {
            return new Person()
            {
                PersonName = PersonName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                CountryID = CountryID,
                Address = Address,
                ReceiveNewsLetters = ReceiveNewsLetters
            };
        }


    }
}
