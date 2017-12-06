using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            this.ViewBag.Products = productRepository.FindAll();
            return View();
        }
    }
}