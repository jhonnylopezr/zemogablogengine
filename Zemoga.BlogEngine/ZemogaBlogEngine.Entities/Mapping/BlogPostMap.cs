using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZemogaBlogEngine.Entities.Mapping
{
    public class BlogPostMap : EntityTypeConfiguration<BlogPost>
    {
        public BlogPostMap()
        {
            this.HasMany(it => it.Comments)
                .WithRequired(it => it.BlogPost)
                .HasForeignKey(it => it.BlogPostId)
                .WillCascadeOnDelete(true);
        }
    }
}
