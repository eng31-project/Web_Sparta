using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserPortal.Models;

namespace UserPortal.Pages.Cohorts
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
        ViewData["SpecialisationID"] = new SelectList(_context.Specialisations, "SpecialisationID", "SpecialisationName");
            return Page();
        }

        [BindProperty]
        public Cohort Cohort { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cohorts.Add(Cohort);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}