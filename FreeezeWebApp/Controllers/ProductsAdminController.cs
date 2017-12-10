using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class ProductsAdminController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();

        [HttpGet]
        public ActionResult Index()
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                this.ViewBag.Header = "Products";
                return View(new DBProductRepository(this.DatabaseContext).FindAll().OrderBy(x => x.Name));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBProduct product = new DBProductRepository(this.DatabaseContext).Find(id);
                this.ViewBag.Header = "Editing article " + product.Name;
                return View(product);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Edit(DBProduct product)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request) && this.ModelState.IsValid)
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                new DBProductRepository(this.DatabaseContext).Update(product, true);
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
                this.ViewBag.Header = "Products";
                this.ViewBag.Products = new DBProductRepository(this.DatabaseContext).FindAll().OrderBy(x => x.Name);
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBProductRepository repository = new DBProductRepository(this.DatabaseContext);
                DBProduct product = repository.Find(id);

                DBProductVariantRepository variantRepository = new DBProductVariantRepository(this.DatabaseContext);
                while (product.Variants.Count > 0)
                {
                    variantRepository.Remove(product.Variants.ElementAt(0), false);
                }

                repository.Remove(product, true);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}