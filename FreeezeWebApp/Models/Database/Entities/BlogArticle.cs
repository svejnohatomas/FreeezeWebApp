using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeezeWebApp.Models.Database.Entities
{
    [Table("fz_tbBlogArticle")]
    public class BlogArticle
    {
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Column("NAME"), MaxLength(64), Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("ADDED_ON"), Timestamp, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        [DisplayName("Added on")]
        public DateTime AddedOn { get; set; }

        [Column("IDfz_tbEditors"), Required]
        [DisplayName("Editor ID")]
        public int IDEditor { get; set; }

        [Column("TEASER"), MaxLength(1024), Required]
        [DisplayName("Teaser")]
        public string Teaser { get; set; }

        [Column("CONTENT"), Required]
        [DisplayName("Content")]
        public string Content { get; set; }

        [Column("IMAGE_PATH"), MaxLength(2048), Required]
        [DisplayName("Image path")]
        public string ImagePath { get; set; }

        [ForeignKey("IDEditor")]
        [DisplayName("Editor")]
        public virtual Editor Editor { get; set; }
    }
}