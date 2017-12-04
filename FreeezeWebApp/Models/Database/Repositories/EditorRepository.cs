using FreeezeWebApp.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class EditorRepository : Repository<Editor>
    {
        public EditorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(Editor item, bool saveChanges)
        {
            this._Context.Editors.Add(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override Editor Find(object id)
        {
            return this._Context.Editors.Find(id);
        }

        internal override List<Editor> FindAll()
        {
            return this._Context.Editors.ToList();
        }

        internal override void Remove(Editor item, bool saveChanges)
        {
            this._Context.Editors.Remove(item);

            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(Editor item, bool saveChanges)
        {
            Editor editor = this.Find(item.ID);
            editor.FirstName = item.FirstName;
            editor.MiddleName = item.MiddleName;
            editor.LastName = item.LastName;
            editor.Username = item.Username;
            editor.PasswordHash = item.PasswordHash;
            editor.PasswordSalt = item.PasswordSalt;
            editor.RegisteredOn = item.RegisteredOn;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}