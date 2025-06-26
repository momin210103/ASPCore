using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; // namespace for Attribute
using ModelValidationExample.CustomValidator;
namespace ModelValidationExample.Models

{
    public class Person:IValidatableObject
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

        //[Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }


        //[Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match Re-enter the password")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [BindNever]
        [Range(0,999.99, ErrorMessage = "{0} should be between {1}Tk and {2}Tk")]
        public Double? Price { get; set; }


        //[YearValidator(2005,ErrorMessage = "should be less than {0}")]
        [YearValidator(2005)]
        
        public DateTime? DateOfBirth { get; set; } 



        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "ToDate should be greater than or equal FromDate")]


        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public List<string?> Tags { get; set; } = new List<string?>();
    
      

        public override string ToString()
        {
            return $"Person Object - PersonName:{PersonName}, Email:{Email},Phone:{Phone}," +
                $"Password:{Password},Confirm Password:{ConfirmPassword},Price:{Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either of Date Of Birth or Age", new[] { nameof(Age) });
            }
        }
    }
}
