using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZemogaBlogEngine.Entities.Mapping
{
    public class AspNetRoleMap : EntityTypeConfiguration<AspNetRole>
    {
        public AspNetRoleMap()
        {
            this.Property(it => it.Name).HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(256);

            this.HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

        }
    }
}
