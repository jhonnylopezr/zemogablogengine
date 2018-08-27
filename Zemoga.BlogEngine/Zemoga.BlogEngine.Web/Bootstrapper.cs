using System.Data.Entity;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Zemoga.BlogEngine.Services;
using Zemoga.BlogEngine.Services.Interfaces;
using Zemoga.BlogEngine.Web.Controllers;
using Zemoga.BlogEngine.Web.Models;
using Zemoga.BlogEngine.Web.Models.BlogPosts;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            MapModelsToViewModels();
            MapViewModelsToModels();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IBlogEngineContext, BlogEngineContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IBlogPostsServices, BlogPostsServices>(new HierarchicalLifetimeManager());
            container.RegisterType<IPostCommentsServices, PostCommentsServices>(new HierarchicalLifetimeManager());
            container.RegisterType<ISecurityServices, SecurityServices>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());

            return container;
        }

        private static void MapModelsToViewModels()
        {
            Mapper.CreateMap<BlogPost, PostViewModel>();
            Mapper.CreateMap<BlogPost, EditPostViewModel>();
        }

        private static void MapViewModelsToModels()
        {
            Mapper.CreateMap<CreateBlogPostViewModel, BlogPost>();
            Mapper.CreateMap<CreateCommentViewModel, PostComment>();
            Mapper.CreateMap<EditPostViewModel, BlogPost>();
        }
    }
}