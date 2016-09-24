using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.DB.Models
{
    public class AccountViewModel
    {
        [Required]
        [Display(Name ="帳號")]
        public string UserID { get; set; }

        [Required]
        [Display(Name ="密碼")]
        public string Password { get; set; }
    }
}
