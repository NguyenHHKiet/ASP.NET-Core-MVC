﻿using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }


        public string ReturnUrl { get; set; }

        // AuthenticationScheme 的命名空间是 Microsoft.AspNetCore.Authentication
        public IList<AuthenticationScheme> ExternalLogins
        {
            get; set;
        }
    }
}
