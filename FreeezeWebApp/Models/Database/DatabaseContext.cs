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
        public DbSet<BlogArticle> Articles { get; set; }
        public DbSet<ContactFormResponse> FormResponses { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}