using EIMS.Common;
using EIMS.AuthorizationIdentity;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;

namespace EIMS.Controllers
{
    public class AdminController : Controller
    {
        private IRepository context = new Repository.Repository();

        private EIMSUserManager _userManager;
        private EIMSRoleManager _roleManager;

        public AdminController()
        {
        }

        public AdminController(EIMSUserManager userManager, EIMSRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public EIMSUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<EIMSUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public EIMSRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<EIMSRoleManager>();
            }
            private set { this._roleManager = value; }
        }


        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> CreateUser(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new EIMSUser
                {

                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber

                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.Name))
                        await UserManager.AddClaimAsync(user.Id, new Claim("Name", model.Name));
                    if (!string.IsNullOrEmpty(model.Surname))
                        await UserManager.AddClaimAsync(user.Id, new Claim("Surname", model.Surname));
                    if (!string.IsNullOrEmpty(model.Gender))
                        await UserManager.AddClaimAsync(user.Id, new Claim("Gender", model.Gender));
                    if (!string.IsNullOrEmpty(model.DateOfBirth))
                        await UserManager.AddClaimAsync(user.Id, new Claim("DateOfBirth", model.DateOfBirth));
                    if (!string.IsNullOrEmpty(model.MiddleName))
                        await UserManager.AddClaimAsync(user.Id, new Claim("MiddleName", model.MiddleName));
                    if (!string.IsNullOrEmpty(model.photoLink))
                        await UserManager.AddClaimAsync(user.Id, new Claim("photoLink", model.photoLink));
                    if (!string.IsNullOrEmpty(model.Country))
                        await UserManager.AddClaimAsync(user.Id, new Claim("Country", model.Country));
                    if (!string.IsNullOrEmpty(model.StateOrProvince))
                        await UserManager.AddClaimAsync(user.Id, new Claim("StateOrProvince", model.StateOrProvince));
                    if (!string.IsNullOrEmpty(model.StreetAddress))
                        await UserManager.AddClaimAsync(user.Id, new Claim("StreetAddress", model.StreetAddress));
                    if (!string.IsNullOrEmpty(model.PostalCode))
                        await UserManager.AddClaimAsync(user.Id, new Claim("PostalCode", model.PostalCode));
                    await UserManager.AddClaimAsync(user.Id, new Claim("CreationDate", DateTime.Now.Date.ToString()));

                    return RedirectToAction("Index", "Home");
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult GetAllUsers()
        {
            
            return View(context.GetUsers());
        }

        public ActionResult UserDetails(long id)
        {
            return View(context.GetUserByID(id));
        }
        // GET: Admin
        //public ActionResult Index()
        //{
        //    IEnumerable<Teacher> list = context.GetTeachers();
        //    return View(list);
        //}
    }
}