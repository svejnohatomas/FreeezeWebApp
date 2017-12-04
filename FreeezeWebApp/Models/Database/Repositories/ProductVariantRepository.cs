using FreeezeWebApp.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class ProductVariantRepository : Repository<ProductVariant>
    {
        public ProductVariantRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(ProductVariant item, bool saveChanges)
        {
            this._Context.ProductVariants.Add(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override ProductVariant Find(object id)
        {
            return this._Context.ProductVariants.Find(id);
        }

        internal override List<ProductVariant> FindAll()
        {
            return this._Context.ProductVariants.ToList();
        }

        internal override void Remove(ProductVariant item, bool saveChanges)
        {
            this._Context.ProductVariants.Remove(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(ProductVariant item, bool saveChanges)
        {
            ProductVariant productVariant = this.Find(item.ID);
            productVariant.IDProduct = item.IDProduct;
            productVariant.Name = item.Name;
            productVariant.ImagePath = item.ImagePath;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}