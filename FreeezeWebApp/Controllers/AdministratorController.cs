using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();

        // GET: Administrator
        public ActionResult Index()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Profiles()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Profiles";
                this.ViewBag.Profiles = new DBEditorRepository(this.DatabaseContext).FindAll();
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Logins()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Logins";
                this.ViewBag.Logins = new DBLoginRepository(this.DatabaseContext).FindAll().OrderByDescending(x => x.UTCLoginTime).ThenByDescending(x => x.UTCLogoutTime).ThenByDescending(x => x.ID);
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Products()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Products";
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Contact()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Contact";
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}