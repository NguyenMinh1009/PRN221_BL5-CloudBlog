using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CloudBlog.Pages.Tags
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public DetailsModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public List<BlogPost> Blogs { get; set; }
        public async Task<IActionResult> OnGet(string tagName)
        {
            Blogs = (await blogPostRepository.GetAllAsync(tagName)).ToList();
            return Page();
        }
    }
}
