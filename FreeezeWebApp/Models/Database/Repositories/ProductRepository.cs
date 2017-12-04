using FreeezeWebApp.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(Product item, bool saveChanges)
        {
            this._Context.Products.Add(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override Product Find(object id)
        {
            return this._Context.Products.Find(id);
        }

        internal override List<Product> FindAll()
        {
            return this._Context.Products.ToList();
        }

        internal override void Remove(Product item, bool saveChanges)
        {
            this._Context.Products.Remove(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(Product item, bool saveChanges)
        {
            Product product = this.Find(item.ID);
            product.Name = item.Name;
            product.Description = item.Description;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}