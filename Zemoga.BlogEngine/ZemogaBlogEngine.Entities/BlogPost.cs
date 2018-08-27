namespace ZemogaBlogEngine.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BlogPost
    {
        public BlogPost()
        {
            this.CreatedOn = DateTime.Now;
            this.LastModifiedOn = DateTime.Now;
            this.IsPublished = false;
            this.Comments = new List<PostComment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool IsPublished { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<PostComment> Comments { get; set; }
    }
}
