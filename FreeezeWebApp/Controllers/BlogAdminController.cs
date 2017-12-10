using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class BlogAdminController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();

        [HttpGet]
        public ActionResult Index()
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Blog articles";
                return View(new DBBlogArticleRepository(this.DatabaseContext).FindAll().OrderByDescending(x => x.UTCAddedOn).ThenByDescending(x => x.ID));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBBlogArticle article = new DBBlogArticleRepository(this.DatabaseContext).Find(id);
                this.ViewBag.Header = "Editing article " + article.Name;
                return View(article);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(DBBlogArticle article)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request) && this.ModelState.IsValid)
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                new DBBlogArticleRepository(this.DatabaseContext).Update(article, true);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Create blog article";
                DBEditor editor = new DBEditorRepository(this.DatabaseContext).Find((this.Session["authorized"] as DBLogin).IDEditor);
                this.ViewBag.Editor = editor;
                return View(new DBBlogArticle() { IDEditor = editor.ID });
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Create(DBBlogArticle article)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request) && this.ModelState.IsValid)
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                new DBBlogArticleRepository(this.DatabaseContext).Add(article, true);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBBlogArticleRepository repository = new DBBlogArticleRepository(this.DatabaseContext);
                DBBlogArticle article = repository.Find(id);
                repository.Remove(article, true);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}