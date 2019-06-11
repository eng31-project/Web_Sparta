using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserPortal.Models;

namespace UserPortal.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }
        public string test;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Test") != "1")
                return RedirectToPage("/Login");
            Message = "Your contact page.";
            return Page();
        }
    }
}
