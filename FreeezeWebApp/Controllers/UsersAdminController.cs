using FreeezeWebApp.Models.Application.Entities;
using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
using System;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class UsersAdminController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();
        
        [HttpGet]
        public ActionResult Index()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Profiles";
                return View(new DBEditorRepository(this.DatabaseContext).FindAll());
            }
            return RedirectToAction("Index", "Login");
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Create user";
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Create(AppUser user)
        {
            if (this.Authorizer.IsLogedIn(this.Session) && this.ModelState.IsValid)
            {
                string salt = PasswordHasher.GenerateSalt(20);
                string hash = PasswordHasher.Hash(user.NewPassword, salt);
                
                DBEditor editor = new DBEditor() { FirstName = user.FirstName, MiddleName = user.MiddleName, LastName = user.LastName, Username = user.NewUsername, UTCRegisteredOn = DateTime.UtcNow, PasswordHash = hash, PasswordSalt = salt };
                new DBEditorRepository(this.DatabaseContext).Add(editor, true);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }
        #endregion

        #region Details
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBEditor editor = new DBEditorRepository(this.DatabaseContext).Find(id);
                this.ViewBag.Header = $"User { editor.ToString() }";
                return View(editor);
            }
            return RedirectToAction("Index", "Login");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBEditor editor = new DBEditorRepository(this.DatabaseContext).Find(id);
                AppUser appUser = new AppUser() { ID = editor.ID, FirstName = editor.FirstName, MiddleName = editor.MiddleName, LastName = editor.LastName, NewUsername = editor.Username, NewPassword = "******" };
                this.ViewBag.Header = $"Edit user { editor.ToString() }";
                return View(appUser);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Edit(AppUser user)
        {
            if (this.Authorizer.IsLogedIn(this.Session) && this.ModelState.IsValid)
            {
                DBEditorRepository repository = new DBEditorRepository(this.DatabaseContext);
                DBEditor editor = repository.Find(user.ID);
                editor.FirstName = user.FirstName;
                editor.MiddleName = user.MiddleName;
                editor.LastName = user.LastName;
                editor.Username = user.NewUsername;
                if (editor.PasswordHash != PasswordHasher.Hash(user.NewPassword, editor.PasswordSalt))
                {
                    editor.Username = PasswordHasher.Hash(user.NewPassword, editor.PasswordSalt);
                }
                repository.Update(editor, true);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }
        #endregion

        #region Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                DBEditorRepository repository = new DBEditorRepository(this.DatabaseContext);
                if ((this.Session["authorized"] as DBLogin).IDEditor != id)
                    repository.Remove(repository.Find(id), true);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }
        #endregion
    }
}