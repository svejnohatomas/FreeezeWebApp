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
    public class AdministratorContactController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();
        // GET: AdministratorContact
        public ActionResult Index()
        {
            //Responses
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Contact form responses";
                this.ViewBag.Responses = new DBContactFormResponseRepository(this.DatabaseContext).FindAll().OrderBy(x => x.UTCAddedOn).ThenBy(x => x.ID);
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}