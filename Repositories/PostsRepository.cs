using Reddit.Models;
using Reddit.Requests;
using System.Linq.Expressions;

namespace Reddit.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly ApplicationDBContext _context;

        public PostsRepository(ApplicationDBContext applicationDBContext)
        {
            this._context = applicationDBContext;
        }

        public async Task<PagedList<Post>> GetAll(GetPostsRequest getPostsRequest)
        {
            IQueryable<Post> postsQuery = _context.Posts;

            if (!string.IsNullOrWhiteSpace(getPostsRequest.SearchKey))
            {
                postsQuery = postsQuery.Where(p =>
                    p.Title.Contains(getPostsRequest.SearchKey) ||
                    p.Content.Contains(getPostsRequest.SearchKey));
            }

            if (getPostsRequest.IsAscending == true)
            {
                postsQuery = postsQuery.OrderByDescending(GetSortProperty(getPostsRequest.SortKey));
            }
            else
            {
                postsQuery = postsQuery.OrderBy(GetSortProperty(getPostsRequest.SortKey));
            }


            return await PagedList<Post>.CreateAsync(postsQuery, getPostsRequest.PageNumber, getPostsRequest.PageSize);
        }

        private static Expression<Func<Post, object>> GetSortProperty(string SortKey) =>
      SortKey?.ToLower() switch
      {
          "createdAt" => post => post.CreateAt,
          "positivity" => post => post.Upvotes - post.Downvotes,
          _ => post => post.Id
      };
    }
}
