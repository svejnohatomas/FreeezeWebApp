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

        [Column("NAME"), Required, MaxLength(64)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("IMAGE_PATH"), Required, MaxLength(2048)]
        [DisplayName("Image path")]
        public string ImagePath { get; set; }
    }
}