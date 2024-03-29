﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserPortal.Models;

namespace UserPortal.Pages.Roles
{
    public class DetailsModel : PageModel
    {
        private readonly UserPortal.Models.SpartaDB _context;

        public DetailsModel(UserPortal.Models.SpartaDB context)
        {
            _context = context;
        }

        public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Role = await _context.Roles.FirstOrDefaultAsync(m => m.RoleID == id);

            if (Role == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
