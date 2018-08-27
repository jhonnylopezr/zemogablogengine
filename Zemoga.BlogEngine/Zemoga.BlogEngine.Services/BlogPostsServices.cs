using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zemoga.BlogEngine.Services.Interfaces;
using ZemogaBlogEngine.Entities;


namespace Zemoga.BlogEngine.Services
{
    /// <summary>
    /// Set of services for Blog Post Entity (Implementation)
    /// </summary>
    public class BlogPostsServices : Service, IBlogPostsServices
    {
        public BlogPostsServices(IBlogEngineContext db) : base(db)
        {

        }

        /// <summary>
        /// Adds a new blog post to database
        /// </summary>
        /// <param name="post">Post to add</param>
        /// <returns>Id of the newly created blog post</returns>
        public int Add(BlogPost post)
        {
            if (post.AspNetUser != null)
            {
                post.AspNetUser = Context.EntryWithState(post.AspNetUser, System.Data.Entity.EntityState.Unchanged);
            }

            Context.BlogPosts.Add(post);
            Context.SaveChanges();

            return post.Id;
        }

        /// <summary>
        /// Deletes a blog post from database
        /// </summary>
        /// <param name="post">Post to delete (must include Id of the blog post)</param>
        public void Delete(BlogPost post)
        {
            Context.BlogPosts.Remove(post);
            Context.SaveChanges();
        }

        /// <summary>
        /// Gets a blog post by Id
        /// </summary>
        /// <param name="id">Id of the blog post</param>
        /// <returns>Blog post</returns>
        public BlogPost Find(int id)
        {
            return Context.BlogPosts.Find(id);
        }

        /// <summary>
        /// Get all the blog posts
        /// </summary>
        /// <param name="includeNotPublished">Whether or not include published posts</param>
        /// <returns>Collection of a blog posts</returns>
        public List<BlogPost> GetAll(bool includeNotPublished)
        {
            return Context.BlogPosts
                .Where(it => includeNotPublished || it.PublishingStatus == PublishingStatusEnum.Published)
                .OrderByDescending(it => it.CreatedOn)
                .ToList();

        }

        /// <summary>
        /// Gets a list of blog post in publishing status: PendingPublishingApproval
        /// </summary>
        /// <returns>Collection of blog posts</returns>
        public List<BlogPost> GetPendingForApprovalPosts()
        {
            return Context.BlogPosts
                .Where(it => it.PublishingStatus == PublishingStatusEnum.PendingPublishApproval)
                .OrderBy(it => it.CreatedOn)
                .ToList();
        }

        /// <summary>
        /// Get blog posts from database. If pageSize param is specified other than 0,
        /// you will get a server side paginated list of blog posts
        /// </summary>
        /// <param name="startIndex">First blog post in paginated set of blog posts</param>
        /// <param name="pageSize">Page size in paginated set of blog posts</param>
        /// <returns>Collection of blog posts</returns>
        public List<BlogPost> GetPosts(int startIndex = 0, int pageSize = 0)
        {
            var query = Context.BlogPosts
                .OrderByDescending("CreatedOn");

            if (pageSize > 0)
            {
                query = query.Skip(startIndex).Take(pageSize);
            }

            return query.ToList();
        }

        /// <summary>
        /// Updates a blog post ind database
        /// </summary>
        /// <param name="post">Post with new values (must include Id of the blog post)</param>
        public void Update(BlogPost post)
        {
            if (post.AspNetUser != null)
            {
                post.AspNetUser = Context.EntryWithState(post.AspNetUser, System.Data.Entity.EntityState.Unchanged);
            }

            post = Context.EntryWithState(post, System.Data.Entity.EntityState.Modified);
            Context.SaveChanges();
        }
    }
}
