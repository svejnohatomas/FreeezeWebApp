using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class BlogController : Controller
    {
        public DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        // GET: Blog
        [HttpGet]
        public ActionResult Index()
        {
            DBBlogArticleRepository repository = new DBBlogArticleRepository(this.DatabaseContext);
            this.ViewBag.Articles = repository.FindAll().OrderByDescending(x => x.UTCAddedOn).Skip(1);
            this.ViewBag.LastArticle = repository.FindLast();
            return View();
        }
    }
}