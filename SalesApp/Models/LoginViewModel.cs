using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesApp.Models
{
    public class LoginViewModel
    {
        public int UserId { get; set; }
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
