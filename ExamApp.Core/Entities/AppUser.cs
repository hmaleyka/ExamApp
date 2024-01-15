using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Core.Entities
{
    public class AppUser :IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsRemained { get; set; }
    }
}
