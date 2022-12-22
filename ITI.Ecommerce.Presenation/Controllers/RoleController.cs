using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ITI.Ecommerce.Presenation.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> RoleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(RoleCreateModel model)
        {

            if (ModelState.IsValid == false)
                return View();
            else
            {
                var result =
                await RoleManager.CreateAsync(
                    new IdentityRole
                    {
                        Name = model.Name
                    });
                if (result.Succeeded == false)
                {
                    result.Errors.ToList().ForEach(i =>
                    {
                        ModelState.AddModelError("", i.Description);
                    });
                    return View();
                }
                else
                {
                    return RedirectToAction("Role", "Add");
                }

            }
        }
    }
}
