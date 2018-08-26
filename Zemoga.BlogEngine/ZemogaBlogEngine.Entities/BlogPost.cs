namespace ZemogaBlogEngine.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastModifiedOn { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
