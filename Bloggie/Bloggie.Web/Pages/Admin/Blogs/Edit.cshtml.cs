using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            BlogPost = await blogPostRepository.GetAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                await blogPostRepository.UpdateAsync(BlogPost);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record updated successfully!",
                    Type = Enums.NotificationType.Success

                };
            }
            catch (Exception)
            {

                ViewData["Notification"] = new Notification
                {
                    Message = "Record updated failed!",
                    Type = Enums.NotificationType.Error
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Message = "Blog deleted successfully!",
                    Type = Enums.NotificationType.Success

                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();

        }
    }
}
