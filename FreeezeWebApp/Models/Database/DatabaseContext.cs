using FreeezeWebApp.Models.Database.Entities;
using System.Data.Entity;

namespace FreeezeWebApp.Models.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=MySQL")
        {
            this.Configuration.ProxyCreationEnabled = false;
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
        }
    }
}