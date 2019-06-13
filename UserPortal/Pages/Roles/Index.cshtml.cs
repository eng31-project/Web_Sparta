using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserPortal.Models;

namespace UserPortal.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public IndexModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

        public IList<Role> Role { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            Role = await _context.Roles.ToListAsync();
            return Page();
        }
    }
}
