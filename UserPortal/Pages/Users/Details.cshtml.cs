using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserPortal.Models;

namespace UserPortal.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public DetailsModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

        new public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users
                .Include(u => u.Cohort)
                .Include(u => u.Role).FirstOrDefaultAsync(m => m.UserID == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
