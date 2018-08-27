namespace ZemogaBlogEngine.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BlogPost
    {
        public BlogPost()
        {
            this.PublishingStatus = PublishingStatusEnum.Created;
            this.CreatedOn = DateTime.Now;
            this.LastModifiedOn = DateTime.Now;
            this.Comments = new List<PostComment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public string UserId { get; set; }
        public string ApproverId { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public PublishingStatusEnum PublishingStatus { get; set; }

        public string PublishingStatusDescription
        {
            get
            {
                string description = string.Empty;

                switch (PublishingStatus)
                {
                    case PublishingStatusEnum.Created:
                        description = Zemoga.BlogEngine.Resources.BlogPostResources.CreatedStatus;
                        break;
                    case PublishingStatusEnum.PendingPublishApproval:
                        description = Zemoga.BlogEngine.Resources.BlogPostResources.PendingPublishApprovalStatus;
                        break;
                    case PublishingStatusEnum.Published:
                        description = Zemoga.BlogEngine.Resources.BlogPostResources.PublishedStatus;
                        break;
                    
                }

                return description;
            }
        }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<PostComment> Comments { get; set; }
        public virtual AspNetUser Approver { get; set; }
    }

    public enum PublishingStatusEnum
    {
        [Display(ResourceType = typeof(Zemoga.BlogEngine.Resources.BlogPostResources), Name = "CreatedStatus")]
        Created = 0,

        [Display(ResourceType = typeof(Zemoga.BlogEngine.Resources.BlogPostResources), Name = "PendingPublishApprovalStatus")]
        PendingPublishApproval = 1,

        [Display(ResourceType = typeof(Zemoga.BlogEngine.Resources.BlogPostResources), Name = "PublishedStatus")]
        Published = 2
    }
}
