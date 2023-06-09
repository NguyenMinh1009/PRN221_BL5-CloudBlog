using Bloggie.Web.Models.ViewModels;
using CloudBlog.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace CloudBlog.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public Register RegisterViewModel { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var user = new IdentityUser
            {
                UserName = RegisterViewModel.Username,
                Email = RegisterViewModel.Email,
            };

            var identityResult = await userManager.CreateAsync(user, RegisterViewModel.Password);

            if (identityResult.Succeeded)
            {

                var addRoleResult = await userManager.AddToRoleAsync(user, "User");
                if (addRoleResult.Succeeded)
                {
                    ViewData["Notification"] = new Notification
                    {
                        Type = Bloggie.Web.Enums.NotificationType.Success,
                        Message = "User registered successfully"
                    };

                    return Page();
                }
            }

            ViewData["Notification"] = new Notification
            {
                Type = Bloggie.Web.Enums.NotificationType.Error,
                Message = "Someting went wrong"
            };

            return Page();
        }
    }
}
