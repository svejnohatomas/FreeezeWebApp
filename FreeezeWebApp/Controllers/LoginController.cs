using FreeezeWebApp.Models.Application.Entities;
using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
using System;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class LoginController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(AppLogin login)
        {
            if (this.ModelState.IsValid)
            {
                DBLoginRepository loginRepository = new DBLoginRepository(this.DatabaseContext);
                DBEditorRepository editorRepository = new DBEditorRepository(this.DatabaseContext);

                DBEditor editor = editorRepository.Find(login.Username);

                if (editor != null && login.Username == editor.Username && PasswordHasher.Hash(login.Password, editor.PasswordSalt) == editor.PasswordHash)
                {
                    DBLogin dBLogin = new DBLogin() { IDEditor = editor.ID, UserAgent = Request.UserAgent, UserIP = IPObtainer.GetIP(), UTCLogoutTime = DateTime.UtcNow.AddMinutes(10) };
                    loginRepository.Add(dBLogin, true);
                    this.Session["authorized"] = dBLogin;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return View(); //neexistuje nebo nesedí přihlašovací údaje
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            if (this.Session["authorized"] != null)
            {
                DBLoginRepository loginRepository = new DBLoginRepository(this.DatabaseContext);
                DBLogin login = loginRepository.Find((this.Session["authorized"] as DBLogin).ID);
                login.UTCLogoutTime = DateTime.UtcNow;
                loginRepository.Update(login, true);
                this.Session["authorized"] = null;
            }
            return View("Index");
        }
    }
}