using ExamApp.Business.ViewModels.AccountVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterVM registervm);
        Task Login(LoginVM loginvm);
        void Logout();
    }
}
