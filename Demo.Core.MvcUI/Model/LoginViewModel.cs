using System.ComponentModel.DataAnnotations;

namespace Demo.Core.MvcUI.Model
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string  Password { get; set; }
        public bool  RememberMe { get; set; }
    }
}
