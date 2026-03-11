using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        public string? FullName { get; set; }

        public string? Position { get; set; }

        public string? Department { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        public DateTime? HireDate { get; set; }
    }
}
