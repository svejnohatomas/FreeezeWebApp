using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeezeWebApp.Models.Database.Entities
{
    [Table("fz_tbContactFormResponse")]
    public class DBContactFormResponse
    {
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Column("NAME"), MaxLength(32), Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("EMAIL"), MaxLength(512), Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Column("SUBJECT"), MaxLength(64), Required]
        [DisplayName("Subject")]
        public string Subject { get; set; }

        [Column("MESSAGE"), Required]
        [DisplayName("Message")]
        public string Message { get; set; }

        [Column("ADDED_ON"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Added on")]
        public DateTime AddedOn { get; set; }
    }
}