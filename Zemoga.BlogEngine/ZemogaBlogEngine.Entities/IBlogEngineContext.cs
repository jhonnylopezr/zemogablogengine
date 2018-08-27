using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ZemogaBlogEngine.Entities
{
    public interface IBlogEngineContext : IDisposable
    {
        DbSet<AspNetRole> AspNetRoles { get; set; }
        DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        DbSet<AspNetUser> AspNetUsers { get; set; }
        DbSet<BlogPost> BlogPosts { get; set; }
        DbSet<PostComment> PostComments { get; set; }

        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        T EntryWithState<T>(T entity, System.Data.Entity.EntityState state) where T : class;

        int SaveChanges();
    }
}