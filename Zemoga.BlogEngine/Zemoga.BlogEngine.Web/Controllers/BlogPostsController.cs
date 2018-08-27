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

        public ActionResult Post(int id)
        {
            BlogPost post = _blogPostsServices.Find(id);

            PostViewModel model = Mapper.Map<BlogPost, PostViewModel>(post);

            model.AllowToPublish = !model.IsPublished && (User.Identity.IsAuthenticated && User.Identity.Name == model.AspNetUser.UserName);
            model.AllowToEdit = User.Identity.Name == model.AspNetUser.UserName;

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Publish(int id)
        {
            BlogPost post = _blogPostsServices.Find(id);
            post.IsPublished = true;
            post.LastModifiedOn = DateTime.Now;

            _blogPostsServices.Update(post);

            return RedirectToAction("Post", new { id = id });
        }

        public ActionResult PostCommentsList(int id)
        {
            PostCommentsViewModel model = new PostCommentsViewModel();

            model.Comments = _postCommentsServices.GetCommentsByPost(id);

            return View(model);
        }

        public ActionResult CommentForm(int postId)
        {
            CreateCommentViewModel model = new CreateCommentViewModel();
            model.BlogPostId = postId;
            AspNetUser user = _securityServices.GetUserByUserName(User.Identity.Name);

            if (user != null)
            {
                model.AuthorEmail = user.Email;
                model.AuthorName = user.FullName;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentForm(CreateCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                PostComment comment = Mapper.Map<CreateCommentViewModel, PostComment>(model);

                _postCommentsServices.Add(comment);

                return RedirectToAction("Post", new { id = model.BlogPostId });
            }

            return View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            BlogPost post = _blogPostsServices.Find(id);

            if (post.AspNetUser.UserName != User.Identity.Name)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            }

            EditPostViewModel model = Mapper.Map<BlogPost, EditPostViewModel>(post);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditPostViewModel model)
        {
            BlogPost post = _blogPostsServices.Find(model.Id);

            if (post.AspNetUser.UserName != User.Identity.Name)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            }

            Mapper.Map<EditPostViewModel, BlogPost>(model, post);
            post.IsPublished = false;
            _blogPostsServices.Update(post);

            return RedirectToAction("Post", new { id = model.Id });
        }
    }
}