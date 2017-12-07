using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class AdministratorBlogController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();

        // GET: AdministratorBlog
        public ActionResult Index()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Blog";
                this.ViewBag.Articles = new DBBlogArticleRepository(this.DatabaseContext).FindAll().OrderByDescending(x => x.UTCAddedOn).ThenByDescending(x => x.ID);
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}