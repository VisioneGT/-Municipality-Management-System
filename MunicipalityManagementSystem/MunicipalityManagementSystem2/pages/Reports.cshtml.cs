using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourNamespace.Data; // Include the correct namespace for your DB context
using YourNamespace.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Pages
{
    public class ReportsModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;

        // Properties to bind to the form
        [BindProperty]
        public required Report NewReport { get; set; }

        // Property for displaying success message after submitting the form
        public required string SuccessMessage { get; set; }

        // Property to hold the list of reports
        public required List<Report> Reports { get; set; }

        // Property for the Report ID to update the status
        [BindProperty]
        public int ReportIDToUpdate { get; set; }

        // Method to display the form (GET)
        public async Task OnGetAsync()
        {
            // Retrieve the reports from the database
            Reports = await _context.Reports.ToListAsync();
        }

        // Method to handle form submission (POST)
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                NewReport.SubmissionDate = DateTime.Now;
                NewReport.Status = "Pending"; // Default status, you can modify it based on your logic

                // Add the new report to the database
                _context.Reports.Add(NewReport);
                await _context.SaveChangesAsync();

                SuccessMessage = "Report submitted successfully!";

                // Redirect to the same page or to a success page
                return RedirectToPage("Reports");
            }

            // If validation fails, stay on the same page and show errors
            return Page();
        }

        // Method to update the status of the report (update to "Completed")
        public async Task<IActionResult> OnPostUpdateStatusAsync()
        {
            var report = await _context.Reports.FirstOrDefaultAsync(r => r.ReportID == ReportIDToUpdate);

            if (report != null)
            {
                report.Status = "Completed";
                await _context.SaveChangesAsync();
                SuccessMessage = "Report status updated to Completed!";
            }
            else
            {
                SuccessMessage = "Report not found!";
            }

            return RedirectToPage("Reports");
        }

        // Method to delete a report
        public async Task<IActionResult> OnPostDeleteAsync(int reportId)
        {
            var report = await _context.Reports.FindAsync(reportId);

            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
                SuccessMessage = "Report deleted successfully!";
            }
            else
            {
                SuccessMessage = "Report not found!";
            }

            return RedirectToPage("Reports");
        }
    }
}
