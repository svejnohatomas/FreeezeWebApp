using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeezeWebApp.Models.Database.Entities
{
    [Table("fz_tbProducts")]
    public class DBProduct
    {
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Column("PRODUCT_NAME"), Required, MaxLength(64)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("PRODUCT_DESCRIPTION"), Required, MaxLength(512)]
        [DisplayName("Description")]
        public string Description { get; set; }

        public virtual ICollection<DBProductVariant> Variants { get; set; }
    }
}