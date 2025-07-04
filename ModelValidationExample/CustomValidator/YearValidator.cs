﻿using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.CustomValidator
{
    public class YearValidator : ValidationAttribute
    {
        public int MinimumYear { get; set; } 
        public string DefaultErrorMessage { get; set; } = "Year should be greater than or equal to {0}";
        public YearValidator() { }
        public YearValidator(int minimumYear)
        {
            MinimumYear = minimumYear;

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage,MinimumYear));

                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }


    }
}
