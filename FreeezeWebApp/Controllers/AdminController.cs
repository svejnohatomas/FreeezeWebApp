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
    public class AdminController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();

        // GET: Administrator
        public ActionResult Index()
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        #region Logins
        [HttpGet]
        public ActionResult Logins()
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Logins";
                return View(new DBLoginRepository(this.DatabaseContext).FindAll().OrderByDescending(x => x.UTCLoginTime).ThenByDescending(x => x.UTCLogoutTime).ThenByDescending(x => x.ID));
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult DeleteLogin(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBLoginRepository repository = new DBLoginRepository(this.DatabaseContext);
                DBLogin login = repository.Find(id);
                if ((this.Session["authorized"] as DBLogin).ID != id)
                    repository.Remove(login, true);
                return RedirectToAction("Logins");
            }
            return RedirectToAction("Index", "Login");
        }
        #endregion
    }
}