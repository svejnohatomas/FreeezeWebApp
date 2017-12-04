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
    public class LoginController : Controller
    {
        public DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            //Request.
            return View();
        }

        [HttpPost]
        public ActionResult Index(DBLogin login)
        {
            if (this.ModelState.IsValid)
            {
                //TODO: Check user login
                throw new NotImplementedException();
            }
            return View();
        }
    }
}