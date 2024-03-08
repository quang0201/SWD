﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "UserName is required.")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty;
    }
}
