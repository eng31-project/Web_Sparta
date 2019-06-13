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
    public class DetailsModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;
        public IList<User> UserL { get; set; }
        public DetailsModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

        public Cohort Cohort { get; set; }
        public User Users { get; set; }

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            if (id == null)
            {
                return NotFound();
            }
            UserL = await _context.Users
                .Include(u => u.Role).Where(m => m.CohortID == id).ToListAsync();


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
