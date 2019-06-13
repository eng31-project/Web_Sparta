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
    public class IndexModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public IndexModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

        public IList<Cohort> Cohort { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            Cohort = await _context.Cohorts
                .Include(c => c.Specialisation).ToListAsync();
            return Page();
        }
    }
}
