using ExamApp.Business.Helpers;
using ExamApp.Business.Services.Interfaces;
using ExamApp.Business.ViewModels.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IAccountService service, RoleManager<IdentityRole> roleManager)
        {
            _service = service;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(RegisterVM registerVM)
        {
            //if(!ModelState.IsValid)
            //{
            //    return View();
            //}
              _service.Register(registerVM);
            return RedirectToAction("Index" , "Home");
        }
        public async Task <IActionResult> Logout ()
        {
             _service.Logout();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _service.Login(loginvm);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> CreateRole()
        {
            foreach (UserRole item in Enum.GetValues(typeof(UserRole)))
            {
                if(await _roleManager.FindByNameAsync(item.ToString())==null)
                {
                    await _roleManager.CreateAsync(new IdentityRole 
                    {
                        Name = item.ToString() 
                    });
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
