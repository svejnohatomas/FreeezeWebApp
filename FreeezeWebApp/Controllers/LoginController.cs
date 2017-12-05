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
        public DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (this.Session["authorized"] is DBLogin sessionLogin && sessionLogin.LogoutTime >= DateTime.Now)
            {
                DBLoginRepository loginRepository = new DBLoginRepository(this.DatabaseContext);
                DBLogin login = loginRepository.Find((this.Session["authorized"] as DBLogin).ID);
                login.LogoutTime = DateTime.Now.AddMinutes(20);
                loginRepository.Update(login, true);
                this.Session["authorized"] = login;
                return RedirectToAction("Index", "Administrator");
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

                if (editor != null || login.Username == editor.Username || PasswordHasher.Hash(login.Password, editor.PasswordSalt) == editor.PasswordHash)
                {
                    DBLogin dBLogin = new DBLogin() { IDEditor = editor.ID, UserAgent = Request.UserAgent, UserIP = IPObtainer.GetIP() };
                    loginRepository.Add(dBLogin, true);
                    this.Session["authorized"] = dBLogin;
                    return RedirectToAction("Index", "Administrator");
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
                login.LogoutTime = DateTime.Now;
                loginRepository.Update(login, true);
                this.Session["authorized"] = null;
            }
            return View("Index");
        }
    }
}