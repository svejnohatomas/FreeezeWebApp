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

        [Column("RESPONSE_NAME"), MaxLength(32), Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("RESPONSE_EMAIL"), MaxLength(512), Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Column("RESPONSE_SUBJECT"), MaxLength(64), Required]
        [DisplayName("Subject")]
        public string Subject { get; set; }

        [Column("RESPONSE_MESSAGE"), Required]
        [DisplayName("Message")]
        public string Message { get; set; }

        [Column("RESPONSE_ADDED_ON_UTC"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Added on")]
        public DateTime UTCAddedOn { get; set; }
    }
}