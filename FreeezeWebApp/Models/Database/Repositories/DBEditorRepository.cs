using FreeezeWebApp.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class DBEditorRepository : DBRepository<DBEditor>
    {
        public DBEditorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(DBEditor item, bool saveChanges)
        {
            this._Context.Editors.Add(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override DBEditor Find(object id)
        {
            return this._Context.Editors.Find(id);
        }
        internal virtual DBEditor Find(string username)
        {
            return this._Context.Editors.Where(x => x.Username == username).FirstOrDefault();
        }

        internal override List<DBEditor> FindAll()
        {
            return this._Context.Editors.ToList();
        }

        internal override void Remove(DBEditor item, bool saveChanges)
        {
            this._Context.Editors.Remove(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(DBEditor item, bool saveChanges)
        {
            DBEditor editor = this.Find(item.ID);
            editor.FirstName = item.FirstName;
            editor.MiddleName = item.MiddleName;
            editor.LastName = item.LastName;
            editor.Username = item.Username;
            editor.PasswordHash = item.PasswordHash;
            editor.PasswordSalt = item.PasswordSalt;
            editor.UTCRegisteredOn = item.UTCRegisteredOn;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}