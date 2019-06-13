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

namespace UserPortal.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public EditModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

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
           ViewData["CohortID"] = new SelectList(_context.Cohorts, "CohortID", "CohortID");
           ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            if (!ModelState.IsValid)
            {
                ViewData["CohortID"] = new SelectList(_context.Cohorts, "CohortID", "CohortID");
                ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName");
                return Page();
            }

            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.UserID))
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

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
