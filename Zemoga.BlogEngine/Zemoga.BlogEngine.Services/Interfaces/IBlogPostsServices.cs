using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services.Interfaces
{
    public interface IBlogPostsServices : IDisposable
    {
        BlogPost Find(int id);
        List<BlogPost> GetAll(bool includeNotPublished);
        List<BlogPost> GetPosts(int startIndex = 0, int pageSize = 0);
        int Add(BlogPost post);
        void Delete(BlogPost post);
        void Update(BlogPost post);
    }
}
