using FreeezeWebApp.Models.Application.Entities;
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
            return View();
        }

        [HttpPost]
        public ActionResult Index(AppLogin login)
        {
            if (this.ModelState.IsValid)
            {
                DBLoginRepository loginRepository = new DBLoginRepository(this.DatabaseContext);
                //Request
                //TODO: Check user login
                throw new NotImplementedException();
            }
            return View();
        }
    }
}