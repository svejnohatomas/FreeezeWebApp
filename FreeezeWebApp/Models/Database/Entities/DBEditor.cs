using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeezeWebApp.Models.Database.Entities
{
    [Table("fz_tbEditors")]
    public class DBEditor
    {
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Column("FIRST_NAME"), Required, MaxLength(64)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Column("MIDDLE_NAME"), MaxLength(64)]
        [DisplayName("Middle name")]
        public string MiddleName { get; set; }

        [Column("LAST_NAME"), Required, MaxLength(64)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Column("USERNAME"), Required, MaxLength(64)]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Column("PSWD_HASH"), Required, MaxLength(2048)]
        [DisplayName("Password hash")]
        public string PasswordHash { get; set; }

        [Column("PSWD_SALT"), Required, MaxLength(2048)]
        [DisplayName("Password salt")]
        public string PasswordSalt { get; set; }

        [Column("REGISTERED_ON_UTC"), Required]
        [DisplayName("Registered on")]
        public DateTime UTCRegisteredOn { get; set; }

        public virtual ICollection<DBBlogArticle> Articles { get; set; }
        public virtual ICollection<DBLogin> Logins { get; set; }
    }
}