using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //[Authorize(Policy = "CityUsersOnly")]
        public IActionResult Index()
        {
            var model = new RoleViewModel();            
            return View(model);
        }

        public IActionResult GetRoles()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new RoleViewModel();
            var data = model.GetRoles(tableModel);
            return Json(data);
        }

        //[Authorize(Policy = "InternalOfficials")]
        public IActionResult Add()
        {
            var model = new RoleUpdateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                await model.AddNewRole();
            }
            return View(model);
        }
    }
}