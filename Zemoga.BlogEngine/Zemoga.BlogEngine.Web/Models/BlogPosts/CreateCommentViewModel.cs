using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zemoga.BlogEngine.Web.Models.BlogPosts
{
    public class CreateCommentViewModel
    {
        [Required]
        public int BlogPostId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.BlogPostResources), Name = "AuthorName")]
        public string AuthorName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.BlogPostResources), Name = "AuthorEmail")]
        public string AuthorEmail { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.BlogPostResources), Name = "Comment")]
        public string Comment { get; set; }
        
    }
}