using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using OnlineSurvey.Services;
using OnlineSurvey.Services.ViewModels;
using OnlineSurveys.Core.Models;
using OnlineSurveys.Infrastructure;
using OnlineSurveys.Infrastructure.Repositories;
using RoleService = OnlineSurveys.Services.RoleService;

namespace OnlineSurveys.Web.Controllers
{
   
    public class HomeController : Controller
    {
        protected RoleService _roleService;
        protected UserService _userService;
        public HomeController()
        {
            string connString = ConfigurationManager.ConnectionStrings["OnlineSurveyDbConn"].ToString();
            var dbContext = new OnlineSurveyContext(connString);
            var roleRepo = new RoleRepository(dbContext);
            var userRepo = new UserRepository(dbContext);
            _roleService = new RoleService(roleRepo);
            _userService = new UserService(userRepo);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "RoleAdmin")]
        public JsonResult GetAllUsers(string term)
        {
            var users = _userService.GetAll();
            var usersforsending = users.Where(p => p.Email.Contains(term)).Select(p => p.Email).ToList();

            return Json(usersforsending, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "RoleAdmin")]
        public JsonResult GetAllRoles()
        {
            var roles = _roleService.GetAll();
            var rolsforsending = new List<RoleViewModel>();
            foreach (var role in roles)
            {
                rolsforsending.Add(new RoleViewModel(){RoleName = role.RoleName});
            }
            return Json(rolsforsending, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "RoleAdmin")]
        [HttpPost]
        public JsonResult AddNewRole(RoleViewModel role)
        {
            Role r = new Role()
            {
                Id = Guid.NewGuid(),
                RoleName = role.RoleName
            };
            _roleService.AddRole(r);
            _roleService.SaveChanges();
            return Json("Added");
        }

        [Authorize(Roles = "RoleAdmin")]
        [HttpPost]
        public JsonResult DeleteRole(Guid modelToDelete)
        {
            _roleService.Delete(modelToDelete);
            _roleService.SaveChanges();
            return Json("Deleted");
        }

	}
}