using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityPractice.Pages.Account
{
    public class LoginModel : PageModel
    {
        /// <summary>
        /// 
        /// </summary>
        [BindProperty]
        public Credential Credential { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void OnGet()
        {
            this.Credential = new Credential { UserName = "admin" };
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Credential.UserName == "admin" && Credential.Password == "password")
                {
                    // Create Security Context
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim(ClaimTypes.Email, "siri551@gmail.com"),
                        new Claim("Department", "HR"),
                        new Claim("IsAdmin", "true"),
                        new Claim("EmploymentDate", "2021-05-10")
                    };

                    var identity = new ClaimsIdentity(claims, "IdentityAuth");

                    ClaimsPrincipal principle = new ClaimsPrincipal(identity);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = Credential.RememberMe
                    };
                    await HttpContext.SignInAsync("IdentityAuth", principle, authProperties);

                    return RedirectToPage("/Index");
                }

                return Page();
            }

            return Page();
        }
    }

    public class Credential
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
