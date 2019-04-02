using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using S_cart.Controllers;


namespace S_cart.Models
{
    public class Login
    {
        [Remote("IsChecked", "Login", HttpMethod = "POST", ErrorMessage = "You may not use special characters.")]
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username:")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}