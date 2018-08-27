using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services.Interfaces
{
    /// <summary>
    /// Set of services for Blog Post Entity (Interface)
    /// </summary>
    public interface IBlogPostsServices : IDisposable
    {
        /// <summary>
        /// Gets a blog post by Id
        /// </summary>
        /// <param name="id">Id of the blog post</param>
        /// <returns>Blog post</returns>
        BlogPost Find(int id);

        /// <summary>
        /// Get all the blog posts
        /// </summary>
        /// <param name="includeNotPublished">Whether or not include published posts</param>
        /// <returns>Collection of a blog posts</returns>
        List<BlogPost> GetAll(bool includeNotPublished);

        /// <summary>
        /// Get blog posts from database. If pageSize param is specified other than 0,
        /// you will get a server side paginated list of blog posts
        /// </summary>
        /// <param name="startIndex">First blog post in paginated set of blog posts</param>
        /// <param name="pageSize">Page size in paginated set of blog posts</param>
        /// <returns>Collection of blog posts</returns>
        List<BlogPost> GetPosts(int startIndex = 0, int pageSize = 0);

        /// <summary>
        /// Adds a new blog post to database
        /// </summary>
        /// <param name="post">Post to add</param>
        /// <returns>Id of the newly created blog post</returns>
        int Add(BlogPost post);

        /// <summary>
        /// Deletes a blog post from database
        /// </summary>
        /// <param name="post">Post to delete (must include Id of the blog post)</param>
        void Delete(BlogPost post);

        /// <summary>
        /// Updates a blog post ind database
        /// </summary>
        /// <param name="post">Post with new values (must include Id of the blog post)</param>
        void Update(BlogPost post);

        /// <summary>
        /// Gets a list of blog post in publishing status: PendingPublishingApproval
        /// </summary>
        /// <returns>Collection of blog posts</returns>
        List<BlogPost> GetPendingForApprovalPosts();
    }
}
