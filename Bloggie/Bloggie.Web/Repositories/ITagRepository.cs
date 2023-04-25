using Bloggie.Web.Models.Domain;

namespace CloudBlog.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
