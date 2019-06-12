using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserPortal.Models;

namespace UserPortal.Pages.Cohorts
{
    public class DetailsModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public DetailsModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

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
    }
}
