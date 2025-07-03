using System.ComponentModel.DataAnnotations;

namespace RazorView.Models
{
    public class Student
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}
