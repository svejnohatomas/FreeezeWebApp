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
    public class AdministratorProductController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();
        // GET: AdministratorProduct
        public ActionResult Index()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Products";
                this.ViewBag.Products = new DBProductRepository(this.DatabaseContext).FindAll().OrderBy(x => x.Name);
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}