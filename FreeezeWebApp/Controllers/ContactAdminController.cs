using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class ContactAdminController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();
        
        [HttpGet]
        public ActionResult Index()
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Contact form responses";
                return View(new DBContactFormResponseRepository(this.DatabaseContext).FindAll().OrderBy(x => x.UTCAddedOn).ThenBy(x => x.ID));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = $"Contact form response number { id }";
                return View(new DBContactFormResponseRepository(this.DatabaseContext).Find(id));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBContactFormResponseRepository repository = new DBContactFormResponseRepository(this.DatabaseContext);
                repository.Remove(repository.Find(id), true);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}