using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zemoga.BlogEngine.Web.Models.BlogPosts
{
    public class EditPostViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(ResourceType = typeof(Resources.BlogPostResources), Name = "Title")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [Display(ResourceType = typeof(Resources.BlogPostResources), Name = "PostContent")]
        public string PostContent { get; set; }
    }
}