using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlinceSurveys.Infrastructure;
using OnlinceSurveys.Infrastructure.Repositories;
using OnlineSurvey.AppServices;

namespace OnlineSurvey.Web.Controllers
{
    public class HomeController : Controller
    {
        protected RolesServices _roleService;
        public HomeController()
        {
            string connString = ConfigurationManager.ConnectionStrings["OnlineSurveyDbConn"].ToString();
            var dbContext = new OnlineSurveyContext(connString);
            var roleRepo = new RoleRepository(dbContext);
            _roleService = new RolesServices(roleRepo);

        }
        public ActionResult Index()
        {
            var allRoles = _roleService.GetAll();
            return View(allRoles);
        }

	}
}