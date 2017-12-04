using FreeezeWebApp.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class DBBlogArticleRepository : DBRepository<DBBlogArticle>
    {
        public DBBlogArticleRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public override void Add(DBBlogArticle item, bool saveChanges)
        {
            this._Context.Articles.Add(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override DBBlogArticle Find(object id)
        {
            return this._Context.Articles.Find(id);
        }

        internal override List<DBBlogArticle> FindAll()
        {
            return this._Context.Articles.ToList();
        }

        internal override void Remove(DBBlogArticle item, bool saveChanges)
        {
            this._Context.Articles.Remove(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(DBBlogArticle item, bool saveChanges)
        {
            DBBlogArticle article = this.Find(item.ID);
            article.Name = item.Name;
            article.AddedOn = item.AddedOn;
            article.IDEditor = item.IDEditor;
            article.Teaser = item.Teaser;
            article.Content = item.Content;
            article.ImagePath = item.ImagePath;

            article.Editor = item.Editor;

            if (saveChanges)
                this.SaveChanges();
        }
    }
}