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
    public class DeleteModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public DeleteModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

        [BindProperty]
        new public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FindAsync(id);

            if (User != null)
            {
                _context.Users.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
