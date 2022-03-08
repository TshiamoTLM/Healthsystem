using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using healthsystem.Data;
using healthsystem.Models;
using healthsystem.Models.ViewModels;
using System.Threading.Tasks;

namespace healthsystem.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IRepositoryWrapper _repository;

        public AccountController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, IRepositoryWrapper repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            //ViewBag.Controller = "Account";
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
                AppUser user =
                await _userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Home/Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(loginModel);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            //    ViewBag.Controller = "Account";
            ViewBag.PatientTypeId = new SelectList(_repository.PatientType.FindAll(), "PatientTypeId", "TypeName");
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(PatientRegisterViewModels model)
        {
            //ViewBag.Controller = "Account";
            if (ModelState.IsValid) {
                var appUser = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    IdNumber = model.IdNumber,
                    PatientType = model.PatientTypeId,
                    PhoneNumber = model.Cellphone,
                    campusId = model.campusID
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "Patient");
                    return RedirectToAction("Login", "Account");
                }
                else {
                    ModelState.AddModelError("", "unable to register user - (user already exists)");
                }

            }
            ViewBag.PatientTypeId = new SelectList(_repository.PatientType.FindAll(), "PatientTypeId", "TypeName");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Home", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            //ViewBag.Controller = "Account";
            return View();
        }
    }
}
