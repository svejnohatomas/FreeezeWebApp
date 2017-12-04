using FreeezeWebApp.Models.Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class ContactFormResponseRepository : Repository<ContactFormResponse>
    {
        public ContactFormResponseRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(ContactFormResponse item, bool saveChanges)
        {
            this._Context.FormResponses.Add(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override ContactFormResponse Find(object id)
        {
            return this._Context.FormResponses.Find(id);
        }

        internal override List<ContactFormResponse> FindAll()
        {
            return this._Context.FormResponses.ToList();
        }

        internal override void Remove(ContactFormResponse item, bool saveChanges)
        {
            this._Context.FormResponses.Remove(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(ContactFormResponse item, bool saveChanges)
        {
            ContactFormResponse contactFormResponse = this.Find(item.ID);
            contactFormResponse.Name = item.Name;
            contactFormResponse.Email = item.Email;
            contactFormResponse.Subject = item.Subject;
            contactFormResponse.Message = item.Message;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}