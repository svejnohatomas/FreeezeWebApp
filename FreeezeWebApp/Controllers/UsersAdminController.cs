using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
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
                this.ViewBag.Header = "Create users";
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Create(DBEditor editor)
        {
            if (this.Authorizer.IsLogedIn(this.Session) && this.ModelState.IsValid)
            {
                new DBEditorRepository(this.DatabaseContext).Add(editor, true);
                return View("Index");
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
                this.ViewBag.Header = "Edit user";
                return View(editor);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Edit(DBEditor editor)
        {
            if (this.Authorizer.IsLogedIn(this.Session) && this.ModelState.IsValid)
            {
                new DBEditorRepository(this.DatabaseContext).Update(editor, true);
                return View("Index");
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
                repository.Add(repository.Find(id), true);
                return View("Index");
            }
            return RedirectToAction("Index", "Login");
        }
        #endregion
    }
}