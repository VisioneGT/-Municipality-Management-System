using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using YourNamespace.Data;
using YourNamespace.Models;
using System.Linq;

namespace YourNamespace.Pages
{
    public class PrivacyModel(ILogger<PrivacyModel> logger, ApplicationDbContext context) : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger = logger;
        private readonly ApplicationDbContext _context = context;

        [BindProperty]
        public required ServiceRequest ServiceRequest { get; set; }

        [BindProperty]
        public int UpdateRequestID { get; set; }

        [BindProperty]
        public int DeleteRequestID { get; set; }

        public required List<ServiceRequest> ServiceRequests { get; set; }

        public void OnGet()
        {
            ServiceRequests = _context.ServiceRequests.ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.ServiceRequests.Add(ServiceRequest);
                _context.SaveChanges();
                return RedirectToPage(); // Prevent form resubmission
            }
            OnGet();
            return Page();
        }

        public IActionResult OnPostUpdateStatus()
        {
            var serviceRequest = _context.ServiceRequests
                .FirstOrDefault(sr => sr.RequestID == UpdateRequestID && sr.Status == "Pending");

            if (serviceRequest != null)
            {
                serviceRequest.Status = "Complete";
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            var serviceRequest = _context.ServiceRequests
                .FirstOrDefault(sr => sr.RequestID == DeleteRequestID);

            if (serviceRequest != null)
            {
                _context.ServiceRequests.Remove(serviceRequest);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
