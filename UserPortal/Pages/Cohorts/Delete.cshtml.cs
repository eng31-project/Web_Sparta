using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserPortal.Models;

namespace UserPortal.Pages.Cohorts
{
    public class DeleteModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public DeleteModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }
        public IList<User> UserL { get; set; }
        [BindProperty]
        public Cohort Cohort { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cohort = await _context.Cohorts
                .Include(c => c.Specialisation).FirstOrDefaultAsync(m => m.CohortID == id);

            if (Cohort == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            if (id == null)
            {
                return NotFound();
            }

            Cohort = await _context.Cohorts.FindAsync(id);
            UserL = await _context.Users
                .Include(u => u.Role).Where(m => m.CohortID == id).ToListAsync();

            if (Cohort != null)
            {
                if (UserL == null)
                {
                    _context.Cohorts.Remove(Cohort);
                    await _context.SaveChangesAsync();
                }
                else if (UserL != null)
                {
                    return RedirectToPage("./Index"); ;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
