using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
       // private readonly RoleManager<IdentityRole> _roleManager;
       private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        //public RoleController(RoleManager<IdentityRole> roleManager)
        //{
        //    _roleManager = roleManager;
        //}


        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }



    }
}
