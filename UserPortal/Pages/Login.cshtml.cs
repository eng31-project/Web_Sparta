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
    public class LoginModel : PageModel
    {
        private SpartaDB db = new SpartaDB();
        public string  test;
        public IActionResult OnPost()
        {
            /*if (db.Users.Where(c => c.Email == Request.Form["email"]).Count() != 0 && db.Users.Where(c => c.Email == Request.Form["email"]).First().Password == Request.Form["password"])
            {
                HttpContext.Session.SetString("Test", "1");
                return RedirectToPage("/Contact");
            }*/
            return Page();
        }
    }
}