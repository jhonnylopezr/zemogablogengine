using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services.Interfaces
{
    /// <summary>
    /// Set of services for PostComment Entity (Interface)
    /// </summary>
    public interface IPostCommentsServices : IDisposable
    {
        /// <summary>
        /// Gets a post comment by id
        /// </summary>
        /// <param name="id">Id of the post comment</param>
        /// <returns>Post Comment</returns>
        PostComment Find(int id);

        /// <summary>
        /// Adds a post comment to database
        /// </summary>
        /// <param name="comment">Comment to add</param>
        /// <returns>Id of the newly created post comment</returns>
        int Add(PostComment comment);

        /// <summary>
        /// Deletes a comment from database
        /// </summary>
        /// <param name="comment">Comment to delete (must include Id of the comment)</param>
        void Delete(PostComment comment);

        /// <summary>
        /// Updates a comment in database
        /// </summary>
        /// <param name="comment">Comment with new data (must include the Id of the comment)</param>
        void Update(PostComment comment);

        /// <summary>
        /// Gets comments by blog post
        /// </summary>
        /// <param name="postId">Blog post Id</param>
        /// <returns>Collection of PostComment</returns>
        List<PostComment> GetCommentsByPost(int postId);
    }
}
