using FreeezeWebApp.Models.Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class DBContactFormResponseRepository : DBRepository<DBContactFormResponse>
    {
        public DBContactFormResponseRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(DBContactFormResponse item, bool saveChanges)
        {
            this._Context.FormResponses.Add(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override DBContactFormResponse Find(object id)
        {
            return this._Context.FormResponses.Find(id);
        }

        internal override List<DBContactFormResponse> FindAll()
        {
            return this._Context.FormResponses.ToList();
        }

        internal override void Remove(DBContactFormResponse item, bool saveChanges)
        {
            this._Context.FormResponses.Remove(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(DBContactFormResponse item, bool saveChanges)
        {
            DBContactFormResponse contactFormResponse = this.Find(item.ID);
            contactFormResponse.Name = item.Name;
            contactFormResponse.Email = item.Email;
            contactFormResponse.Subject = item.Subject;
            contactFormResponse.Message = item.Message;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}