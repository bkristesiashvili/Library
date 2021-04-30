using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class LoginViewModel
    {
        [Required(ErrorMessage = "ელ.ფოსტის ველი აუცილებელია!")]
        [EmailAddress(ErrorMessage ="არასწორი ელ.ფოსტის მისამართი!")]
        [Display(Name = "ელ.ფოსტა")]
        public string Email { get; set; }

        [Required(ErrorMessage = "პაროლის ველი აუცილებელია!")]
        [Display(Name = "პაროლი")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Description = "დამახსოვრება", Name = "დამახსოვრება!")]
        public bool RememberMe { get; set; }
    }
}
