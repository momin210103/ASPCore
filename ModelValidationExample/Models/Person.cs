using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; // namespace for Attribute
namespace ModelValidationExample.Models
{
    public class Person
    {
        [Required (ErrorMessage = " {0} can't be empty or null")] //attribute apply for data validations
        [Display(Name = "Person Name")] // Display attribute for custom display name
        [StringLength(40,MinimumLength = 5, ErrorMessage = "{0} should between {2} and {1} characters")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabets,space and dot(.)")]
        public string? PersonName { get;set; }

        [EmailAddress(ErrorMessage = "{0} Invalid ")]
        public string? Email { get; set; }


        [Phone(ErrorMessage = "{0} should be 11 digits")]
        //[ValidateNever]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match Re-enter the password")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }


        [Range(0,999.99, ErrorMessage = "{0} should be between {1}Tk and {2}Tk")]
        public Double? Price { get; set; }

        public override string ToString()
        {
            return $"Person Object - PersonName:{PersonName}, Email:{Email},Phone:{Phone}," +
                $"Password:{Password},Confirm Password:{ConfirmPassword},Price:{Price}";
        }

    }
}
