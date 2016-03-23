using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EIMS.Models;
using EIMS.Common;

namespace EIMS.Controllers
{
    public class TeacherController : Controller
    {
        IRepository context;
        const int pageSize = 50;

        public TeacherController()
        {
            context = new Repository.Repository();
        }

        public TeacherController(IRepository repo)
        {
            context = repo;
        }
        // GET: Teacher
        public ActionResult Index()
        {
            return View(GetItemsPerPage());
        }

        public ActionResult GetTeacherList(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_GetTeacherListPartial", GetItemsPerPage(page));
            }
            return PartialView(GetItemsPerPage());

        }

        [Authorize(Roles = "Admin")]
        public ActionResult AssignSubjects(long id)
        {
            var model = new TeacherSubjectAssignViewModel();
            var repoTeacher = context.GetTeacherByID(id);
            GroupUserInfo t = new GroupUserInfo()
            {
                ID = repoTeacher.ID,
                Name = repoTeacher.Name,
                MiddleName = repoTeacher.MiddleName,
                Surname = repoTeacher.Surname
            };


            List<SubjectInfoViewModel> all = new List<SubjectInfoViewModel>();
            foreach (var item in context.GetSubjects())
            {
                SubjectInfoViewModel sub = new SubjectInfoViewModel()
                {
                    ID = item.SubjectID,
                    Name = item.SubjectName
                };
                all.Add(sub);
            }
            model.Teacher = t;
            model.AllSubjects = all;
            model.SelectedSubjects = repoTeacher.AssignedSubjects;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AssignSubjects(TeacherSubjectAssignViewModel model)
        {
            Teacher teacher = new Teacher()
            {
                ID = model.Teacher.ID,
                AssignedSubjects = model.SelectedSubjects
            };
            if (context.AssignTeacherSubjects(teacher))
                return RedirectToAction("Index");
            List<SubjectInfoViewModel> all = new List<SubjectInfoViewModel>();
            foreach (var item in context.GetSubjects())
            {
                SubjectInfoViewModel sub = new SubjectInfoViewModel()
                {
                    ID = item.SubjectID,
                    Name = item.SubjectName
                };
                all.Add(sub);
            }
            model.AllSubjects = all;
            return View(model);
        }

        private object GetItemsPerPage(int page = 0)
        {
            var itemToSkip = page * pageSize;
            var teachList = new List<UserInfoViewModel>();
            var dblst = context.GetUsers().Where(u => u.Roles.Contains("Teacher"));
            foreach (var sub in dblst)
            {
                UserInfoViewModel tmp = new UserInfoViewModel()
                {
                    ID = sub.ID,
                    Name = sub.Name,
                    Surname = sub.Surname,
                    Email = sub.Email

                };
                teachList.Add(tmp);
            }
            return teachList.OrderBy(f => f.ID).Skip(itemToSkip).Take(pageSize).ToList();
        }
    }
}
