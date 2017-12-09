using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreeezeWebApp.Models.Application.Entities
{
    public class AppUser
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required, MaxLength(64)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [MaxLength(64)]
        [DisplayName("Middle name")]
        public string MiddleName { get; set; }

        [Required, MaxLength(64)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required, MaxLength(64)]
        [DisplayName("Username")]
        public string NewUsername { get; set; }

        [Required, MaxLength(2048)]
        [DisplayName("Password"), DataType(DataType.Password)]
        public string NewPassword { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}