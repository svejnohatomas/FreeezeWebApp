using FreeezeWebApp.Models.Application.Objects;
using FreeezeWebApp.Models.Database;
using FreeezeWebApp.Models.Database.Entities;
using FreeezeWebApp.Models.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeezeWebApp.Controllers
{
    public class ProductVariantAdminController : Controller
    {
        internal DatabaseContext DatabaseContext { get; set; } = new DatabaseContext();
        internal Authorizer Authorizer { get; set; } = new Authorizer();

        [HttpGet]
        public ActionResult Create(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBProduct product = new DBProductRepository(this.DatabaseContext).Find(id);
                this.ViewBag.Header = $"Create variant for product { product.Name }";
                return View(new DBProductVariant() { IDProduct = id, Product = product });
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Create(DBProductVariant productVariant)
        {
            ModelState.Remove("Product");
            if (this.Authorizer.IsLogedIn(this.Session, this.Request) && this.ModelState.IsValid)
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                new DBProductVariantRepository(this.DatabaseContext).Add(productVariant, true);
                return RedirectToAction("Edit", "ProductsAdmin", new { id = productVariant.IDProduct });
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (this.Authorizer.IsLogedIn(this.Session, this.Request))
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                DBProductVariant productVariant = new DBProductVariantRepository(this.DatabaseContext).Find(id);
                this.ViewBag.Header = $"Editing variant for product { productVariant.Product.Name }";
                return View(productVariant);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(DBProductVariant productVariant)
        {
            ModelState.Remove("Product");
            if (this.Authorizer.IsLogedIn(this.Session, this.Request) && this.ModelState.IsValid)
            {
                this.Authorizer.ReauthorizeLogin(this.Session);
                new DBProductVariantRepository(this.DatabaseContext).Update(productVariant, true);
                return RedirectToAction("Edit", "ProductsAdmin", new { id = productVariant.IDProduct });
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            DBProductVariantRepository repository = new DBProductVariantRepository(this.DatabaseContext);
            DBProductVariant productVariant = repository.Find(id);
            if (productVariant != null)
                repository.Remove(productVariant, true);
            return RedirectToAction("Edit", "ProductsAdmin", new { id = productVariant.IDProduct });
        }
    }
}