using FreeezeWebApp.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public class BlogArticleRepository : Repository<BlogArticle>
    {
        public BlogArticleRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public override void Add(BlogArticle item, bool saveChanges)
        {
            this._Context.Articles.Add(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override BlogArticle Find(object id)
        {
            return this._Context.Articles.Find(id);
        }

        internal override List<BlogArticle> FindAll()
        {
            return this._Context.Articles.ToList();
        }

        internal override void Remove(BlogArticle item, bool saveChanges)
        {
            this._Context.Articles.Remove(item);
            if (saveChanges)
                this.SaveChanges();
        }

        internal override void Update(BlogArticle item, bool saveChanges)
        {
            BlogArticle article = this.Find(item.ID);
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