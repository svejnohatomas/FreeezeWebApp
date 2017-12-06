using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeezeWebApp.Models.Database.Entities
{
    [Table("fz_tbBlogArticle")]
    public class DBBlogArticle
    {
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Column("ARTICLE_NAME"), MaxLength(64), Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("ARTICLE_ADDED_ON_UTC"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        [DisplayName("Added on")]
        public DateTime UTCAddedOn { get; set; }

        [Column("IDfz_tbEditors"), Required]
        [DisplayName("Editor ID")]
        public int IDEditor { get; set; }

        [Column("ARTICLE_TEASER"), MaxLength(1024), Required]
        [DisplayName("Teaser")]
        public string Teaser { get; set; }

        [Column("ARTICLE_CONTENT"), Required]
        [DisplayName("Content")]
        public string Content { get; set; }

        [Column("ARTICLE_IMAGE_PATH"), MaxLength(2048), Required]
        [DisplayName("Image path")]
        public string ImagePath { get; set; }

        [Column("ARTICLE_IMAGE_ALT"), MaxLength(256), Required]
        [DisplayName("Image alternative text")]
        public string ImageAlt { get; set; }

        [ForeignKey("IDEditor")]
        public virtual DBEditor Editor { get; set; }
    }
}