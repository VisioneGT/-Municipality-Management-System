using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourNamespace.Data;
using YourNamespace.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNamespace.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Citizen Citizen { get; set; }

        public List<Citizen> Citizens { get; set; } = new List<Citizen>();

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
            Citizen = new Citizen();
        }

        public void OnGet()
        {
            Citizens = _context.Citizens.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Citizens.Add(Citizen);
                await _context.SaveChangesAsync();
                Citizens = _context.Citizens.ToList();
            }
            return Page();
        }

        public IActionResult OnPostDeleteAsync(int citizenId)
        {
            var citizen = _context.Citizens.FirstOrDefault(c => c.CitizenId == citizenId);
            if (citizen != null)
            {
                _context.Citizens.Remove(citizen);
                _context.SaveChanges();
                Citizens = _context.Citizens.ToList();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync(int citizenId, string FullName, string Address, string PhoneNumber, string Email)
        {
            var citizenToUpdate = _context.Citizens.FirstOrDefault(c => c.CitizenId == citizenId);
            if (citizenToUpdate != null)
            {
                // Update the citizen properties with the provided values
                citizenToUpdate.FullName = FullName;
                citizenToUpdate.Address = Address;
                citizenToUpdate.PhoneNumber = PhoneNumber;
                citizenToUpdate.Email = Email;

                _context.Citizens.Update(citizenToUpdate);
                await _context.SaveChangesAsync();
                Citizens = _context.Citizens.ToList();
            }
            return Page();
        }
    }
}