using FreeezeWebApp.Models.Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class DBLoginRepository : DBRepository<DBLogin>
    {
        public DBLoginRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(DBLogin item, bool saveChanges)
        {
            this._Context.Logins.Add(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override DBLogin Find(object id)
        {
            return this._Context.Logins.Find(id);
        }

        internal override List<DBLogin> FindAll()
        {
            return this._Context.Logins.ToList();
        }

        internal override void Remove(DBLogin item, bool saveChanges)
        {
            this._Context.Logins.Remove(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(DBLogin item, bool saveChanges)
        {
            DBLogin login = this.Find(item.ID);
            login.UTCLogoutTime = item.UTCLogoutTime;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}