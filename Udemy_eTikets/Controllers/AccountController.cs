using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy_eTikets.Data;
using Udemy_eTikets.Data.ViewModels;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Controllers
{
    public class AccountController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
           var response = new LoginVM();
           return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if(user != null)
            {
                var passCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if(passCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false,false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
            }
            
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }
    }
}
