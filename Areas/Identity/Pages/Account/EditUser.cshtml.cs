using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewsSite.Data;
using NewsSite.Models;
using NewsSite.Utility;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NewsSite.Areas.Identity.Pages.Account
{
    public class EditUserModel : PageModel
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _db;
        public EditUserModel(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, 
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }


        public string ReturnUrl { get; set; }
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync( string returnUrl = null)
        {
            string role = Request.Form["rdUserRole"].ToString();
            returnUrl = returnUrl ?? Url.Content("~/");

            var user = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id != id);
        

                            if (role == SD.Admin)
                            {
                                await _userManager.AddToRoleAsync(user, SD.Admin);
                            }
                            else
                            {
                                await _userManager.AddToRoleAsync(user, SD.Visitor);
                                return LocalRedirect(returnUrl);
                            }
    


                    // hna 3shan b3d ma acreate new user ywdene 3la sf7t el users brdo
                    return RedirectToAction("Index", "User", new { area = "Admin" });

            }
        



    }
}
