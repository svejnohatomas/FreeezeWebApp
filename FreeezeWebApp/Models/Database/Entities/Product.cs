using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeezeWebApp.Models.Database.Entities
{
    [Table("fz_tbProducts")]
    public class Product
    {
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Column("NAME"), Required, MaxLength(64)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("DESCRIPTION"), Required, MaxLength(512)]
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}