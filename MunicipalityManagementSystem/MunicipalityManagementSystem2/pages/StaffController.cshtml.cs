using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourNamespace.Data;
using YourNamespace.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace YourNamespace.Pages
{
    public class StaffControllerModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;

        // This will hold the form data for creating or updating a staff member
        [BindProperty]
        public required Staff Staff { get; set; }

        // This will hold the staff data from the database for listing staff
        public List<Staff> StaffList { get; set; } = new List<Staff>();

        // GET request handler (for initial form loading and fetching staff data)
        public async Task OnGetAsync()
        {
            StaffList = await _context.Staff.ToListAsync();
        }

        // POST request handler for creating a new staff member and saving it to the database
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                StaffList = await _context.Staff.ToListAsync();
                return Page(); // Return the page with validation errors
            }

            // Check if the email already exists in the database
            var existingStaff = await _context.Staff
                                              .FirstOrDefaultAsync(s => s.Email == Staff.Email);

            if (existingStaff != null)
            {
                ModelState.AddModelError("Staff.Email", "This email address is already registered.");
                StaffList = await _context.Staff.ToListAsync();
                return Page(); // Return to the page to display the error
            }

            // Add new staff to the database
            _context.Staff.Add(Staff);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Staff member created successfully!";
            return RedirectToPage();
        }

        // POST request handler for deleting a staff member
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                TempData["ErrorMessage"] = "Staff member not found.";
                return RedirectToPage();
            }

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Staff member deleted successfully!";
            return RedirectToPage();
        }

        // POST request handler for updating a staff member's information
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!ModelState.IsValid)
            {
                StaffList = await _context.Staff.ToListAsync();
                return Page(); // Return to the page if the model is invalid
            }

            // Find the staff member by StaffID
            var staffToUpdate = await _context.Staff.FindAsync(Staff.StaffID);
            if (staffToUpdate == null)
            {
                TempData["ErrorMessage"] = "Staff member not found.";
                return RedirectToPage();
            }

            // Ensure the email is not empty
            if (string.IsNullOrEmpty(Staff.Email))
            {
                ModelState.AddModelError("Staff.Email", "Email cannot be empty. Please provide a valid email.");
                return Page(); // Stay on the page to prompt the user for a new email.
            }

            // Check if the email already exists for a different staff member
            var existingStaff = await _context.Staff
                                              .FirstOrDefaultAsync(s => s.Email == Staff.Email && s.StaffID != Staff.StaffID);
            if (existingStaff != null)
            {
                ModelState.AddModelError("Staff.Email", "This email address is already registered.");
                return Page(); // Return to the page to display the error
            }

            // Update the staff member's details
            staffToUpdate.FullName = Staff.FullName;
            staffToUpdate.Position = Staff.Position;
            staffToUpdate.Department = Staff.Department;
            staffToUpdate.Email = Staff.Email;
            staffToUpdate.PhoneNumber = Staff.PhoneNumber;

            // Save changes to the database
            _context.Staff.Update(staffToUpdate);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Staff member updated successfully!";
            return RedirectToPage();
        }
    }
}
