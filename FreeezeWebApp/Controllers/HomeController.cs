using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class HomeController : Controller
    {
        internal DatabaseContext databaseContext = new DatabaseContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(DBContactFormResponse response)
        {
            if (this.ModelState.IsValid)
            {
                DBContactFormResponseRepository responseRepository = new DBContactFormResponseRepository(this.databaseContext);
                responseRepository.Add(response, true);
                return RedirectToAction("Contact");
            }
            return View();
        }
    }
}