using System;
using System.Configuration;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.Services;
using OnlineSurvey.Services.ViewModels;
using OnlineSurveys.Core.Models;
using OnlineSurveys.Infrastructure;
using OnlineSurveys.Infrastructure.Repositories;
using OnlineSurveys.Services;

namespace OnlineSurvey.Web.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        protected RoleService _roleService;
        protected UserService _userService;

        public AuthenticationController()
        {
            string connString = ConfigurationManager.ConnectionStrings["OnlineSurveyDbConn"].ToString();
            var dbContext = new OnlineSurveyContext(connString);
            var roleRepo = new RoleRepository(dbContext);
            var userRepo = new UserRepository(dbContext);
            _roleService = new RoleService(roleRepo);
            _userService = new UserService(userRepo);
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginmodel)
        {
            if (!ModelState.IsValid) //Checks if input fields have the correct format
            {
                return View(loginmodel); //Returns the view with the input values so that the user doesn't have to retype again
            }
            if (_userService.IfUserExistWithThisUserAndPass(loginmodel.Email,loginmodel.Password))
            {
                var logedinuser = _userService.GetAll().Find(u => u.Email == loginmodel.Email);
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, logedinuser.FirstName),
                    new Claim(ClaimTypes.Email, loginmodel.Email),
                    //new Claim(ClaimTypes.Country, "XtiansCountrie"),
                    //new Claim(ClaimTypes.Role, "RoleAdmin"),
                    //new Claim(ClaimTypes.Role, "Admin")
                }, "ApplicationCookie");

                foreach (var role in logedinuser.Roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
                }
                
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(loginmodel.ReturnUrl));
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(loginmodel);
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registermodel)
        {
            if (!ModelState.IsValid) //Checks if input fields have the correct format
            {
                return View(registermodel); //Returns the view with the input values so that the user doesn't have to retype again
            }
            if (CheckIfuserExist(registermodel))
            {
                ViewBag.AlertMessage = "This username or email address already exist!";
                return View(registermodel);
            }
            User user = new User()
               {
                   Id = Guid.NewGuid(),
                   Email = registermodel.Email,
                   Username = registermodel.Username,
                   FirstName = registermodel.FirstName,
                   LastName = registermodel.LastName,
                   Password = registermodel.Password
               };
            Role role = _roleService.GetAll().Find(r => r.RoleName == "OwnSurveuAdmin");
            role.Users.Add(user);
            _userService.AddUser(user);
            _userService.SaveChanges();
            return RedirectToAction("Login", "Authentication");
        }

        public bool CheckIfuserExist(RegisterViewModel registermodel)
        {
            return _userService.CheckIfUserExist(registermodel.Email, registermodel.Username);
        }
    }
}