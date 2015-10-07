using System;
using System.Configuration;
using System.Web.Mvc;
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
        public HomeController()
        {
            string connString = ConfigurationManager.ConnectionStrings["OnlineSurveyDbConn"].ToString();
            var dbContext = new OnlineSurveyContext(connString);
            var roleRepo = new RoleRepository(dbContext);
            _roleService = new RoleService(roleRepo);

        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllRoles()
        {
            return Json(_roleService.GetAll(), JsonRequestBehavior.AllowGet);
        }

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

        [HttpPost]
        public JsonResult DeleteRole(string modelToDelete)
        {
            var id = new Guid(modelToDelete);
            _roleService.Delete(id);
            return Json("Deleted");
        }

        //public ActionResult Index()
        //{
        //    var allRoles = _roleService.GetAll();
        //    return View(allRoles);
        //}
        //[HttpGet]
        //public ActionResult AddRole()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddRole(Role role)
        //{
        //    role.Id = Guid.NewGuid();
        //    _roleService.AddRole(role);
        //    _roleService.SaveChanges();
        //    return RedirectToAction("Index");
        //}

	}
}