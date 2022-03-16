using System.Threading.Tasks;
using Demo.Core.MvcUI.Entities;
using Demo.Core.MvcUI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;
        public SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };
                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        IdentityRole role = new IdentityRole
                        {
                            Name = "Admin"
                        };
                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can't add the role");
                            return View(registerViewModel);
                        }
                    }

                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }

            return View(registerViewModel);
        }

      
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password,
                    loginViewModel.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    var IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                    if (IsAdmin==false)
                    {
                        return View(loginViewModel);
                    }
                    return RedirectToAction("Index", "Admin");

                }
                ModelState.AddModelError("","Invalid Login");


            }


            return View();
        }


        public ActionResult LogOff()
        {

            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");   
          
        }

    }
}
