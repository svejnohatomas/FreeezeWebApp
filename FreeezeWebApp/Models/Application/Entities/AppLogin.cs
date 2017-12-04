using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreeezeWebApp.Models.Application.Entities
{
    public class AppLogin
    {
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}