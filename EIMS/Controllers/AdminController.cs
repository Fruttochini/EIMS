using EIMS.Common;
using EIMS.AuthorizationIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

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
        // GET: Admin
        //public ActionResult Index()
        //{
        //    IEnumerable<Teacher> list = context.GetTeachers();
        //    return View(list);
        //}
    }
}