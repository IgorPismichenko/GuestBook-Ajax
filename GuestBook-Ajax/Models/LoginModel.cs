using System.ComponentModel.DataAnnotations;

namespace GuestBook_Ajax.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login must be filled")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Password must be filled")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
