using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities;
using ServiceContracts.Enums;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents the DTO class that contain update person
    /// </summary>
    public class PersonUpdateRequest
    {
        [Required]
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
                PersonID = PersonID,
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
