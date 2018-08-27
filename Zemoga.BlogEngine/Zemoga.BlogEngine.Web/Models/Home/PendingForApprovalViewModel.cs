using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Web.Models.Home
{
    public class PendingForApprovalViewModel
    {
        public List<BlogPost> BlogPosts { get; set; }
    }
}