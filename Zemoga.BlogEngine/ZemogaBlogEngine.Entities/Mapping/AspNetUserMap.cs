using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZemogaBlogEngine.Entities.Mapping
{
    public class AspNetUserMap : EntityTypeConfiguration<AspNetUser>
    {
        public AspNetUserMap()
        {
            this.Property(it => it.Email)
                .HasMaxLength(256);

            this.Property(it => it.UserName)
                .HasMaxLength(256)
                .IsRequired();

            this.HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            this.HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            this.HasMany(e => e.BlogPosts)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}
