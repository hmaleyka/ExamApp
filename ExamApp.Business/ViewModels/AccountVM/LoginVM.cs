using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Business.ViewModels.AccountVM
{
    public class LoginVM
    {
        public string EmailOrUernsme { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
