using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SteamDBCopyCatMVC.Models
{
    public class AkunModels
    {
        [Required]
        [Display(Name = "Nama")]
        public string Nama { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}