using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserPortal.Models;

namespace UserPortal.Pages.Specialisations
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
            return Page();
        }

        [BindProperty]
        public Specialisation Specialisation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Specialisations.Add(Specialisation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}