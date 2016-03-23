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
            return View();
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
            return View(model);
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
