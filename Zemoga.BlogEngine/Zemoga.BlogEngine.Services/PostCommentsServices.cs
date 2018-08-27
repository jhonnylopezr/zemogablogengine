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
    /// Set of services for PostComment Entity (Implementation)
    /// </summary>
    public class PostCommentsServices : Service, IPostCommentsServices
    {
        public PostCommentsServices(IBlogEngineContext db) : base(db)
        {

        }

        /// <summary>
        /// Adds a post comment to database
        /// </summary>
        /// <param name="comment">Comment to add</param>
        /// <returns>Id of the newly created post comment</returns>
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

        /// <summary>
        /// Deletes a comment from database
        /// </summary>
        /// <param name="comment">Comment to delete (must include Id of the comment)</param>
        public void Delete(PostComment comment)
        {
            Context.PostComments.Remove(comment);
            Context.SaveChanges();
        }

        /// <summary>
        /// Gets a post comment by id
        /// </summary>
        /// <param name="id">Id of the post comment</param>
        /// <returns>Post Comment</returns>
        public PostComment Find(int id)
        {
            return Context.PostComments.Find(id);
        }

        /// <summary>
        /// Gets comments by blog post
        /// </summary>
        /// <param name="postId">Blog post Id</param>
        /// <returns>Collection of PostComment</returns>
        public List<PostComment> GetCommentsByPost(int postId)
        {
            return Context.PostComments
                .Where(it => it.BlogPostId == postId)
                .OrderByDescending(it => it.CreatedOn)
                .ToList();
        }

        /// <summary>
        /// Updates a comment in database
        /// </summary>
        /// <param name="comment">Comment with new data (must include the Id of the comment)</param>
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
