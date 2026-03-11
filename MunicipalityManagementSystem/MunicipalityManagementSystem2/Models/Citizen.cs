using System;

namespace YourNamespace.Models
{
    public class Citizen
    {
        public int CitizenId { get; set; }

        public string? FullName { get; set; }  // Nullable properties
        public string? Address { get; set; }  // Nullable properties
        public string? PhoneNumber { get; set; }  // Nullable properties
        public string? Email { get; set; }  // Nullable properties

        public DateTime? DateOfBirth { get; set; }  // Nullable DateTime
        public DateTime RegistrationDate { get; set; } // Automatically set to current date

        // Constructor with initialization
        public Citizen(string? fullName, string? address, string? phoneNumber, string? email, DateTime? dateOfBirth)
        {
            FullName = fullName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
            RegistrationDate = DateTime.Now;  // Automatically set registration date to now
        }

        // Parameterless constructor (if needed for EF or other frameworks)
        public Citizen() 
        {
            RegistrationDate = DateTime.Now;  // Default value if parameterless constructor is used
        }
    }
}
