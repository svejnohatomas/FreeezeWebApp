using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Repositories;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();

        // GET: Product
        public ActionResult Index()
        {
            DBProductRepository productRepository = new DBProductRepository(this.DatabaseContext);
            return View(productRepository.FindAll());
        }
    }
}