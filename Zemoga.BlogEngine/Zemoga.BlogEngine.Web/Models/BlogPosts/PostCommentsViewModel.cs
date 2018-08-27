using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Web.Models.BlogPosts
{
    public class PostCommentsViewModel
    {
        public List<PostComment> Comments { get; set; }
    }
}