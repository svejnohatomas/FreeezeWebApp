﻿using FreeezeWebApp.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            login.IDEditor = item.ID;
            login.LoginTime = item.LoginTime;
            login.LogoutTime = item.LogoutTime;
            login.UserAgent = item.UserAgent;
            login.UserIP = item.UserIP;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}