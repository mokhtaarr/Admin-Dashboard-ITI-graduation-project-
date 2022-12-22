using DTOs;
using ITI.Ecommerce.Models;
using ITI.Ecommerce.Presenation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace ITI.Ecommerce.Presenation.Controllers
{
    
    public class UserController : Controller
    {
        UserManager<Customer> UserManager;
        SignInManager<Customer> SignInManager;
        RoleManager<IdentityRole> RoleManager;
        
        public UserController(UserManager<Customer> _UserManager,
            SignInManager<Customer> _SignInManager,
            RoleManager<IdentityRole> _roleManager
        )
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
            RoleManager = _roleManager; 
           
        }


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult SignUp()
        {
            ViewBag.Roles = RoleManager.Roles
               .Select(i => new SelectListItem(i.Name, i.Name));
            return View();
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            DateTime Date = DateTime.Now;
            if (ModelState.IsValid == false)
                return View();
            else
            {
                Customer user = new Customer()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                   Address=model.Address,
                   MobileNumber=model.MobileNumber
                   ,DateEntered= Date
                };
                IdentityResult result
                      = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded == false)
                {
                    result.Errors.ToList().ForEach(i =>
                    {
                        ModelState.AddModelError("", i.Description);
                    });
                    return View();
                }
                else {
                    await UserManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("SignIn", "User");
                }
                    
            }
        }


        [HttpGet]

        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
      
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            if (ModelState.IsValid == false)
                return View();
            else
            {
                var userForEmail = await UserManager.FindByEmailAsync(model.UserName);
               
                   var username = userForEmail.UserName;
               

                var result
                     = await SignInManager.PasswordSignInAsync
                        (username, model.Password, model.RememberMe,
                             false);
                 
                if (result.Succeeded == false)
                {
                    ModelState.AddModelError("", "Invalid User Name Of Password");
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
        }


        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("SignIn", "User");
        }
    }
}
