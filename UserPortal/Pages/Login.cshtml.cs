using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserPortal.Models;

namespace UserPortal.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SpartaDB _context;

        public LoginModel(SpartaDB context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        private SpartaDB db = new SpartaDB();
        public string test;

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            IList<User> users = await _context.Users.Where(u => u.Email == Input.Email).ToListAsync();

            users = db.Users.Where(u => u.Email == Input.Email).ToList();

            if (users.Count != 1)
            {
                return Page();
            }

            if (!Hash.ValidateHash(Input.Password, users[0].Password))
            {
                return Page();
            }

            HttpContext.Session.SetString("Test", "1");
            return RedirectToPage("/Users/Index");
        }

        public class InputModel
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        }
    }
}