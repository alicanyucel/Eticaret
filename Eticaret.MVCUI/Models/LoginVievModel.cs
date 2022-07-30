using System.ComponentModel.DataAnnotations;

namespace Eticaret.MVCUI.Models
{
    public class LoginVievModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
