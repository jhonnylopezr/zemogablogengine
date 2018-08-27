using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zemoga.BlogEngine.Services.Interfaces;
using ZemogaBlogEngine.Entities;


namespace Zemoga.BlogEngine.Services
{
    public class BlogPostsServices : Service, IBlogPostsServices
    {
        public BlogPostsServices(IBlogEngineContext db) : base(db)
        {

        }
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

        public void Delete(BlogPost post)
        {
            Context.BlogPosts.Remove(post);
            Context.SaveChanges();
        }

        public BlogPost Find(int id)
        {
            return Context.BlogPosts.Find(id);
        }

        public List<BlogPost> GetAll(bool includeNotPublished)
        {
            return Context.BlogPosts
                .Where(it => includeNotPublished || it.PublishingStatus == PublishingStatusEnum.Published)
                .OrderByDescending(it => it.CreatedOn)
                .ToList();

        }

        public List<BlogPost> GetPendingForApprovalPosts()
        {
            return Context.BlogPosts
                .Where(it => it.PublishingStatus == PublishingStatusEnum.PendingPublishApproval)
                .OrderBy(it => it.CreatedOn)
                .ToList();
        }

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
