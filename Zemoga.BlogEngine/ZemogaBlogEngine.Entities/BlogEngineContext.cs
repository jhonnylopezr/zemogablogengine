namespace ZemogaBlogEngine.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure;
    using ZemogaBlogEngine.Entities.Mapping;

    public partial class BlogEngineContext : DbContext, IBlogEngineContext
    {
        static BlogEngineContext()
        {
            Database.SetInitializer<BlogEngineContext>(null);
        }

        public BlogEngineContext()
            : base("name=BlogEngineContext")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<PostComment> PostComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new BlogPostMap());
        }

        public virtual T EntryWithState<T>(T entity, EntityState state) where T : class
        {
            if (entity == null)
                return null;

            var objContext = ((IObjectContextAdapter)this).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            object foundState;

            var exists = objContext.TryGetObjectByKey(entityKey, out foundState);
            if (exists)
            {
                objContext.ObjectStateManager.ChangeObjectState(foundState, state);
                return (foundState as T);
            }
            else
            {
                DbEntityEntry entry = this.Entry(entity);
                entry.State = state;
                return entry.Entity as T;
            }
        }
    }
}
