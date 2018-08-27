using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zemoga.BlogEngine.Services.Interfaces;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services
{
    public class PostCommentsServices : Service, IPostCommentsServices
    {
        public PostCommentsServices(IBlogEngineContext db) : base(db)
        {

        }

        public int Add(PostComment comment)
        {
            if (comment.BlogPost != null)
            {
                comment.BlogPost = Context.EntryWithState(comment.BlogPost, System.Data.Entity.EntityState.Unchanged);
            }

            Context.PostComments.Add(comment);
            Context.SaveChanges();

            return comment.Id;
        }

        public void Delete(PostComment comment)
        {
            Context.PostComments.Remove(comment);
            Context.SaveChanges();
        }

        public PostComment Find(int id)
        {
            return Context.PostComments.Find(id);
        }

        public List<PostComment> GetCommentsByPost(int postId)
        {
            return Context.PostComments
                .Where(it => it.BlogPostId == postId)
                .OrderByDescending(it => it.CreatedOn)
                .ToList();
        }

        public void Update(PostComment comment)
        {
            if (comment.BlogPost != null)
            {
                comment.BlogPost = Context.EntryWithState(comment.BlogPost, System.Data.Entity.EntityState.Unchanged);
            }

            comment = Context.EntryWithState(comment, System.Data.Entity.EntityState.Modified);

            Context.SaveChanges();
        }
    }
}
