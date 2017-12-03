using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeezeWebApp.Models.Database.Entities
{
    [Table("fz_tbPages")]
    public class Page
    {
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Column("TITLE"), MaxLength(16)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Column("HEADER"), MaxLength(16)]
        [DisplayName("Header")]
        public string Header { get; set; }

        [Column("CONTENT"), Required]
        [DisplayName("Content")]
        public string Content { get; set; }

        [Column("CSS_PATH"), Required, MaxLength(2048)]
        [DisplayName("CSS path"), DefaultValue("Site.css")]
        public string CssPath { get; set; }
    }
}