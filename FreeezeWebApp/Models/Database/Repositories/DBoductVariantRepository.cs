using FreeezeWebApp.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class DBoductVariantRepository : DBRepository<DBProductVariant>
    {
        public DBoductVariantRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(DBProductVariant item, bool saveChanges)
        {
            this._Context.ProductVariants.Add(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override DBProductVariant Find(object id)
        {
            return this._Context.ProductVariants.Find(id);
        }

        internal override List<DBProductVariant> FindAll()
        {
            return this._Context.ProductVariants.ToList();
        }

        internal override void Remove(DBProductVariant item, bool saveChanges)
        {
            this._Context.ProductVariants.Remove(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(DBProductVariant item, bool saveChanges)
        {
            DBProductVariant productVariant = this.Find(item.ID);
            productVariant.IDProduct = item.IDProduct;
            productVariant.Name = item.Name;
            productVariant.ImagePath = item.ImagePath;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}