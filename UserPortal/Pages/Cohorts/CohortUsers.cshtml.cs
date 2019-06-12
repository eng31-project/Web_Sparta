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
    public class CohortUsersModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public CohortUsersModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }
        public IList<User> User { get; set; }

       // public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            } 
            User = await _context.Users
                .Include(u => u.Cohort)
                .Include(u => u.Role).ToListAsync();
            

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
          
   
    }
}
