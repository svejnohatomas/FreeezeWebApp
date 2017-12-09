using FreeezeWebApp.Models.Database.Entities;
using System.Data.Entity;

namespace FreeezeWebApp.Models.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=MSSQL")
        {
            //this.Configuration.ProxyCreationEnabled = false;
            //this.Configuration.LazyLoadingEnabled = true;
        }

        #region Properties
        public DbSet<DBBlogArticle> Articles { get; set; }
        public DbSet<DBContactFormResponse> FormResponses { get; set; }
        public DbSet<DBEditor> Editors { get; set; }
        public DbSet<DBLogin> Logins { get; set; }
        public DbSet<DBProduct> Products { get; set; }
        public DbSet<DBProductVariant> ProductVariants { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Entity<DBBlogArticle>()
                .HasRequired(a => a.Editor)
                .WithMany(e => e.Articles)
                .HasForeignKey(a => a.IDEditor);

            modelBuilder.Entity<DBLogin>()
                .HasRequired(l => l.Editor)
                .WithMany(e => e.Logins)
                .HasForeignKey(l => l.IDEditor);

            modelBuilder.Entity<DBProductVariant>()
                .HasRequired(v => v.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(v => v.IDProduct);
        }

        public System.Data.Entity.DbSet<FreeezeWebApp.Models.Application.Entities.AppUser> AppUsers { get; set; }
    }
}