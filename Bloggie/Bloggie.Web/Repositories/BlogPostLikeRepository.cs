using Bloggie.Web.Data;

namespace CloudBlog.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public BlogPostLikeRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public Task<int> GetTotalLikesForBlog(Guid blogPostId)
        {
            throw new NotImplementedException();
        }
    }
}
