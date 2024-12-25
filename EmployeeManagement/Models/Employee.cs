//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter a first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter a last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter an email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter a phone number")]
        [DisplayFormat(DataFormatString ="{0: ###-###-####}")]
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter your date of birth")]
        [DisplayFormat(DataFormatString ="{0: dd-MM-yyyy}")]
        [CustomValidation(typeof(Employee), nameof(DOB))]
        public System.DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Enter a position")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Enter a salary")]
        public Nullable<decimal> Salary { get; set; }

        public static ValidationResult DOB(DateTime date, ValidationContext context)
        {
            if(date > DateTime.Now)
            {
                return new ValidationResult("Cant be in future");
            }
            return ValidationResult.Success;
        }
    }
}