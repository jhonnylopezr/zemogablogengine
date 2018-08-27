using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Web.Models.BlogPosts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool IsPublished { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public AspNetUser Approver { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public PublishingStatusEnum PublishingStatus { get; set; }
        public string PublishingStatusDescription { get; set; }
        public bool AllowToPublish { get; set; }
        public bool AllowToEdit { get; set; }
        public bool AllowToApprove { get; set; }
    }
}