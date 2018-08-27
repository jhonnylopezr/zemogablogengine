using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zemoga.BlogEngine.Services.Interfaces;
using Zemoga.BlogEngine.Web.Models.Home;

namespace Zemoga.BlogEngine.Web.Controllers
{
    public class HomeController : Controller
    {
        IBlogPostsServices _blogPostsServices;

        public HomeController(IBlogPostsServices blogPostsServices)
        {
            _blogPostsServices = blogPostsServices;
        }

        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.BlogPosts = _blogPostsServices.GetAll(includeNotPublished: User.Identity.IsAuthenticated);
            return View(model);
        }

        
    }
}