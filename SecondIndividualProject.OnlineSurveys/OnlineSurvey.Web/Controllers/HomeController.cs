using System.Configuration;
using System.Web.Mvc;
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
            var allRoles = _roleService.GetAll();
            return View(allRoles);
        }

	}
}