using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeezeWebApp.Models.Database.Entities
{
    [Table("fz_tbLogins")]
    public class DBLogin
    {
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Column("IDfz_tbEditors"), Required]
        [DisplayName("Editor ID")]
        public int IDEditor { get; set; }

        [Column("LOGIN_TIME"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Login time")]
        public DateTime LoginTime { get; set; }

        [Column("LOGOUT_TIME"), Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayName("Logout time")]
        public DateTime LogoutTime { get; set; }

        [Column("USER_AGENT"), Required]
        [DisplayName("User agent")]
        public string UserAgent { get; set; }

        [Column("USER_IP"), Required]
        [DisplayName("IP address")]
        public string UserIP { get; set; }
    }
}