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
            RegisterUserViewModel usr = new RegisterUserViewModel();
            var roles = new List<string>();
            roles.Add("");
            var iroles = RoleManager.Roles.Select(rol => rol.Name);
            roles.AddRange(iroles);
            usr.Roles = roles;
            return View(usr);
        }

        [HttpPost]
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
                    if (!string.IsNullOrEmpty(model.RoleToAssign))
                    {
                        await UserManager.AddToRoleAsync(user.Id, model.RoleToAssign);
                    }

                    return RedirectToAction("GetAllUsers", "Admin");
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult GetAllUsers()
        {
            var lst = context.GetUsers();
            List<UserInfoViewModel> UserList = new List<UserInfoViewModel>();
            foreach (var dbUser in lst)
            {
                var user = new UserInfoViewModel()
                {
                    Email = dbUser.Email,
                    ID = dbUser.ID,
                    Name = dbUser.Name,
                    Surname = dbUser.Surname,
                    Role = dbUser.Roles.FirstOrDefault()
                };
                UserList.Add(user);
            }
            return View(UserList);
        }

        public ActionResult UserDetails(long id)
        {
            var cUser = context.GetUserByID(id);
            var uservm = new RegisterUserViewModel()
            {
                ID = cUser.ID,
                Username = cUser.Username,
                Email = cUser.Email,
                Name = cUser.Name,
                Surname = cUser.Surname,
                MiddleName = cUser.MiddleName,
                Gender = cUser.Gender,
                DateOfBirth = cUser.DateOfBirth,
                PhoneNumber = cUser.PhoneNumber,
                Country = cUser.Country,
                photoLink = cUser.photoLink,
                PostalCode = cUser.PostalCode,
                StateOrProvince = cUser.StateOrProvince,
                StreetAddress = cUser.StreetAddress

            };
            return View(uservm);
        }

        public async Task<ActionResult> EditUser(long id)
        {
            var cUser = context.GetUserByID(id);
            var uservm = new RegisterUserViewModel()
            {
                ID = cUser.ID,
                Username = cUser.Username,
                Email = cUser.Email,
                Name = cUser.Name,
                Surname = cUser.Surname,
                MiddleName = cUser.MiddleName,
                Gender = cUser.Gender,
                DateOfBirth = cUser.DateOfBirth,
                PhoneNumber = cUser.PhoneNumber,
                Country = cUser.Country,
                photoLink = cUser.photoLink,
                PostalCode = cUser.PostalCode,
                StateOrProvince = cUser.StateOrProvince,
                StreetAddress = cUser.StreetAddress

            };

            //Create Role List
            var result = await UserManager.GetRolesAsync(id);
            uservm.RoleToAssign = result.FirstOrDefault();
            var roles = new List<string>();
            roles.Add("");
            var iroles = RoleManager.Roles.Select(rol => rol.Name);
            roles.AddRange(iroles);
            uservm.Roles = roles; /**/

            return View(uservm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(RegisterUserViewModel model)
        {
            bool IsChanged = false;
            var user = await UserManager.FindByIdAsync(model.ID);
            if (!user.UserName.Equals(model.Username))
            {
                user.UserName = model.Username;
                IsChanged = true;
            }
            if (!user.PhoneNumber.Equals(model.PhoneNumber))
            {
                user.PhoneNumber = model.PhoneNumber;
                IsChanged = true;
            }
            if (!user.Email.Equals(model.Email))
            {
                user.Email = model.Email;
                IsChanged = true;
            }


            if (!string.IsNullOrEmpty(model.RoleToAssign))
            {
                bool isInRole = await UserManager.IsInRoleAsync(model.ID, model.RoleToAssign);
                if (!isInRole)
                {
                    var role = (await UserManager.GetRolesAsync(model.ID)).FirstOrDefault();
                    if (role != null)
                        await UserManager.RemoveFromRoleAsync(model.ID, role);
                    await UserManager.AddToRoleAsync(model.ID, model.RoleToAssign);
                }

            }
            else
            {
                var role = (await UserManager.GetRolesAsync(model.ID)).FirstOrDefault();
                if (role != null)
                    await UserManager.RemoveFromRoleAsync(model.ID, role);
            }

            if (IsChanged)
            {
                var result = await UserManager.UpdateAsync(user);

            }

            var ClaimList = user.Claims.ToList();
            EIMSClaim claim = ClaimList.Where(cl => cl.ClaimType == "Name").Single();
            if (!claim.ClaimValue.Equals(model.Name))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("Name", model.Name));
            }

            claim = ClaimList.Where(cl => cl.ClaimType == "Surname").Single();
            if (!claim.ClaimValue.Equals(model.Surname))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("Surname", model.Surname));
            }

            claim = ClaimList.Where(cl => cl.ClaimType == "Gender").Single();
            if (!claim.ClaimValue.Equals(model.Gender))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("Gender", model.Gender));
            }

            claim = ClaimList.Where(cl => cl.ClaimType == "DateOfBirth").Single();
            if (!claim.ClaimValue.Equals(model.DateOfBirth))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("DateOfBirth", model.DateOfBirth));
            }

            claim = ClaimList.Where(cl => cl.ClaimType == "MiddleName").Single();
            if (!claim.ClaimValue.Equals(model.MiddleName))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("MiddleName", model.MiddleName));
            }

            claim = ClaimList.Where(cl => cl.ClaimType == "photoLink").Single();
            if (!claim.ClaimValue.Equals(model.photoLink))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("photoLink", model.photoLink));
            }

            claim = ClaimList.Where(cl => cl.ClaimType == "Country").Single();
            if (!claim.ClaimValue.Equals(model.Country))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("Country", model.Country));
            }

            claim = ClaimList.Where(cl => cl.ClaimType == "StateOrProvince").Single();
            if (!claim.ClaimValue.Equals(model.StateOrProvince))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("StateOrProvince", model.StateOrProvince));
            }

            claim = ClaimList.Where(cl => cl.ClaimType == "StreetAddress").Single();
            if (!claim.ClaimValue.Equals(model.StreetAddress))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("StreetAddress", model.StreetAddress));
            }
            claim = ClaimList.Where(cl => cl.ClaimType == "PostalCode").Single();
            if (!claim.ClaimValue.Equals(model.PostalCode))
            {
                await UserManager.RemoveClaimAsync(user.Id, new Claim(claim.ClaimType, claim.ClaimValue));
                await UserManager.AddClaimAsync(user.Id, new Claim("PostalCode", model.PostalCode));
            }



            return RedirectToAction("GetAllUsers");

        }


        public ActionResult ChangeUserPassword(long id)
        {
            var cUser = context.GetUserByID(id);
            var userVM = new ChangeUserPasswordViewModel()
            {
                ID = cUser.ID,
                Username = cUser.Username,
                Email = cUser.Email
            };
            return View(userVM);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeUserPassword(ChangeUserPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            var result = await UserManager.RemovePasswordAsync(model.ID);
            if (result.Succeeded)
            {
                result = await UserManager.AddPasswordAsync(model.ID, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("EditUser", new { id = model.ID });
                }
                else
                {
                    ModelState.AddModelError("", result.Errors.FirstOrDefault());
                }
            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
            }
            return View(model);

        }


        public ActionResult GetFaculties()
        {
            var facultyList = new List<FacultyViewModel>();
            var dblst = context.GetFaculties();
            foreach (var fac in dblst)
            {
                FacultyViewModel tmp = new FacultyViewModel()
                {
                    FacultyID = fac.FacultyID,
                    Name = fac.Name
                };
                facultyList.Add(tmp);
            }
            return View(facultyList);
        }
        // GET: Admin
        //public ActionResult Index()
        //{
        //    IEnumerable<Teacher> list = context.GetTeachers();
        //    return View(list);
        //}
    }
}