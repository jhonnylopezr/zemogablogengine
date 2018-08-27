using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zemoga.BlogEngine.Services.Interfaces;
using Zemoga.BlogEngine.Web.Models.BlogPosts;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Web.Controllers
{
    public class BlogPostsController : Controller
    {
        IBlogPostsServices _blogPostsServices;
        IPostCommentsServices _postCommentsServices;
        ISecurityServices _securityServices;

        public BlogPostsController(IBlogPostsServices blogPostsServices, IPostCommentsServices postCommentsServices, ISecurityServices securityServices)
        {
            _blogPostsServices = blogPostsServices;
            _postCommentsServices = postCommentsServices;
            _securityServices = securityServices;
        }

        [Authorize]
        public ActionResult Create()
        {
            CreateBlogPostViewModel model = new CreateBlogPostViewModel();

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken()]
        [HttpPost]
        
        public ActionResult Create(CreateBlogPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                BlogPost post = Mapper.Map<CreateBlogPostViewModel, BlogPost>(model);
                post.AspNetUser = _securityServices.GetUserByUserName(User.Identity.Name);

                int id = _blogPostsServices.Add(post);

                return RedirectToAction("Post", new { id = id });
            }
            return View(model);
        }

        
    }
}