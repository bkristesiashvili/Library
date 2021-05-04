using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public sealed class RegisterViewModel
    {
        [Required(ErrorMessage ="სახელის ველი აუცილებელია!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "გვარის ველი აუცილებელია!")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="ელ.ფოსტა აუცილებელია!")]
        [EmailAddress]
        public string Email { get; set; }

        [Compare(nameof(Email), ErrorMessage ="ელ.ფოსტა არ ემთხვევა!")]
        [EmailAddress]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage ="პაროლის ველი აუცილებელია!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="პაროლის დადასტურება აუცილებელია!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="პაროლი არ ემთხვევა!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "როლის დამატება აუცილებელია!")]
        public string Role { get; set; }

    }
}
