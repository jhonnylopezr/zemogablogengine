using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services.Interfaces
{
    public interface IPostCommentsServices : IDisposable
    {
        PostComment Find(int id);
        int Add(PostComment comment);
        void Delete(PostComment comment);
        void Update(PostComment comment);
        List<PostComment> GetCommentsByPost(int postId);
    }
}
