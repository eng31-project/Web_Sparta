using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserPortal.Models;

namespace UserPortal.Pages.Cohorts
{
    public class EditModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public EditModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

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
           ViewData["SpecialisationID"] = new SelectList(_context.Specialisations, "SpecialisationID", "SpecialisationName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cohort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CohortExists(Cohort.CohortID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CohortExists(int id)
        {
            return _context.Cohorts.Any(e => e.CohortID == id);
        }
    }
}
