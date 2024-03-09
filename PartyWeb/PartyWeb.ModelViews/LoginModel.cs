using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is required.")]
        public string username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; } = string.Empty;
    }
}
