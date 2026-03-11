using System;

namespace YourNamespace.Models
{
    public class Report
    {
        public int ReportID { get; set; }
        public int? CitizenID { get; set; }
        public Citizen? Citizen { get; set; } // Navigation property (not bound to the constructor)
        public string? ReportType { get; set; }
        public string? Details { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string? Status { get; set; }

        // Parameterless constructor for EF Core
        public Report() {}

        // No need for another constructor with parameters, EF Core will handle population of the properties automatically
    }
}
