using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserPortal.Models;

namespace UserPortal.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public CreateModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CohortID"] = new SelectList(_context.Cohorts, "CohortID", "CohortName");
        ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleName");
            return Page();
        }

        [BindProperty]
        new public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            if (!ModelState.IsValid)
            {
                OnGet();
                return Page();
            }
            User.Password = Hash.HashPW(User.Password);
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}