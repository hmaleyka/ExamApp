using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Business.ViewModels.AccountVM
{
    public class RegisterVM
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(ConfirmPassword))]
        public string ConfirmPassword { get; set; }

    }
}
