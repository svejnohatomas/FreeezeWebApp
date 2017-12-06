using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class BlogController : Controller
    {
        public BlogController()
        {
            this.DatabaseContext = new DatabaseContext();
            this.BlogArticleRepository = new DBBlogArticleRepository(this.DatabaseContext);
        }
        public DatabaseContext DatabaseContext { get; set; }
        public DBBlogArticleRepository BlogArticleRepository { get; set; }

        // GET: Blog
        [HttpGet]
        public ActionResult Index()
        {
            this.ViewBag.Articles = this.BlogArticleRepository.FindAll().OrderByDescending(x => x.UTCAddedOn).ThenByDescending(x => x.ID).Skip(1);
            this.ViewBag.LastArticle = this.BlogArticleRepository.FindLast();
            return View();
        }

        [HttpGet]
        public ActionResult Article(int id)
        {
            this.ViewBag.Article = this.BlogArticleRepository.Find(id);
            this.ViewBag.LastArticle = this.BlogArticleRepository.FindLast();
            return View();
        }
    }
}