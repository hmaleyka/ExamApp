using ExamApp.Business.Helpers;
using ExamApp.Business.Services.Interfaces;
using ExamApp.Business.ViewModels.AccountVM;
using ExamApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinmanager;
        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signinmanager)
        {
            _userManager = userManager;
            _signinmanager = signinmanager;         
        }


        public async Task Login(LoginVM loginvm)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginvm.EmailOrUernsme);
            if(user is null)
            {
                user = await _userManager.FindByNameAsync(loginvm.EmailOrUernsme);
                if (user == null)
                {
                    throw new Exception("Email or Username is incorrect");
                }
            }
            var result = _signinmanager.CheckPasswordSignInAsync(user, loginvm.Password, true).Result;
            if (!result.Succeeded)
            {
                throw new Exception("emailorusername or password is incorrect");

            }
            if(result.IsLockedOut)
            {
                throw new Exception("Try it again after a few minutes");
            }

            await _signinmanager.SignInAsync(user, loginvm.IsRemember);

        }

        public async void Logout()
        {
            await _signinmanager.SignOutAsync();

        }

        public async Task Register(RegisterVM registervm)
        {
            AppUser user = new AppUser()
            {
                Name = registervm.Name,
                Surname = registervm.Surname,
                Email = registervm.Email,
                UserName = registervm.Username,
            };

            var result = _userManager.CreateAsync(user , registervm.Password);

            if (!result.IsCompleted)
            {
                //foreach (var error in result.Errors)
                //{
                //    return;
                //}
            }
        

            await _signinmanager.SignInAsync(user, false);
            await _userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
        }
        
    }
}
