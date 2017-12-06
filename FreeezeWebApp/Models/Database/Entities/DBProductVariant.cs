using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeezeWebApp.Models.Database.Entities
{
    [Table("fz_tbProductVariants")]
    public class DBProductVariant
    {
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Column("IDfz_tbProducts"), Required]
        [DisplayName("Product ID")]
        public int IDProduct { get; set; }

        [Column("VARIANT_NAME"), Required, MaxLength(64)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("VARIANT_IMAGE_PATH"), Required, MaxLength(2048)]
        [DisplayName("Image path")]
        public string ImagePath { get; set; }

        [Column("VARIANT_IMAGE_ALT"), MaxLength(256), Required]
        [DisplayName("Image alternative text")]
        public string ImageAlt { get; set; }

        [ForeignKey("IDProduct")]
        public virtual DBProduct Product { get; set; }
    }
}