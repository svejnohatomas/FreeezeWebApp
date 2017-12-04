using FreeezeWebApp.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class DBProductRepository : DBRepository<DBProduct>
    {
        public DBProductRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(DBProduct item, bool saveChanges)
        {
            this._Context.Products.Add(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override DBProduct Find(object id)
        {
            return this._Context.Products.Find(id);
        }

        internal override List<DBProduct> FindAll()
        {
            return this._Context.Products.ToList();
        }

        internal override void Remove(DBProduct item, bool saveChanges)
        {
            this._Context.Products.Remove(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(DBProduct item, bool saveChanges)
        {
            DBProduct product = this.Find(item.ID);
            product.Name = item.Name;
            product.Description = item.Description;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}