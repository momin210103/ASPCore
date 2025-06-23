using System.ComponentModel.DataAnnotations; // namespace for Attribute
namespace ModelValidationExample.Models
{
    public class Person
    {
        [Required] //attribute apply for data validations
        public string? PersonName { get;set; }
        public string? Email { get; set; }
        [Required (ErrorMessage = "Phone must be need")]
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Price { get; set; }

        public override string ToString()
        {
            return $"Person Object - PersonName:{PersonName}, Email:{Email},Phone:{Phone}," +
                $"Password:{Password},Confirm Password:{ConfirmPassword},Price:{Price}";
        }

    }
}
