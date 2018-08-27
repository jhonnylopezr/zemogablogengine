using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Web.Models.Home
{
    public class IndexViewModel
    {
        public List<BlogPost> BlogPosts { get; set; }
    }
}