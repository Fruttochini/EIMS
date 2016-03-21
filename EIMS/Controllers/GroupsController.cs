﻿using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class GroupsController : Controller
    {
        IRepository context;
        const int pageSize = 50;

        public GroupsController()
        {
            context = new Repository.Repository();
        }

        public GroupsController(IRepository repo)
        {
            context = repo;
        }

        public ActionResult Index()
        {
            return View(GetItemsPerPage());
        }
        // GET: Subject

        public ActionResult GetGroupsList(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_GetGroupsListPartial", GetItemsPerPage(page));
            }
            return PartialView(GetItemsPerPage());

        }

        public ActionResult Create()
        {
            CRUGroupViewModel model = new CRUGroupViewModel();
            var faclist = new List<FacultyViewModel>();
            var dbFacs = context.GetFaculties();
            foreach (var item in dbFacs)
            {
                var tmpfac = new FacultyViewModel()
                {
                    FacultyID = item.FacultyID,
                    Name = item.Name
                };
                faclist.Add(tmpfac);
            }

            var dbTech = context.GetUsers().Where(u => u.Roles.Contains("Teacher"));
            var supList = new List<GroupUserInfo>();
            supList.Add(new GroupUserInfo());
            foreach (var item in dbTech)
            {
                var tmpsup = new GroupUserInfo()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Surname = item.Surname,
                    MiddleName = item.MiddleName
                };
                supList.Add(tmpsup);
            }

            model.Faculties = faclist;
            model.TeacherList = supList;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CRUGroupViewModel model)
        {
            if (ModelState.IsValid)
            {

                var gr = new UniversityGroup()
                {
                    GroupName = model.Name,
                    CreationDate = DateTime.Now.Date,
                    FacultyID = model.SelectedFaculty
                };
                if (model.Supervisor > 0)
                    gr.SupervisorID = model.Supervisor;

                if (context.AddGroup(gr) == true)
                    return RedirectToAction("Index");
            }
            return View(model);

        }

        public ActionResult Edit(int id)
        {
            var group = context.GetGroupByID(id);

            CRUGroupViewModel model = new CRUGroupViewModel()
            {
                ID = group.GroupID,
                Name = group.GroupName,
                
            };

            if (group.SupervisorID != null)
            {
                model.Supervisor = (long)group.SupervisorID;
                //var dbsupervisor = context.GetUserByID((long)group.SupervisorID);
                //var supervisor = new GroupUserInfo()
                //{
                //    ID = (long)group.SupervisorID,
                //    Name = dbsupervisor.Name,
                //    Surname = dbsupervisor.Surname,
                //    MiddleName = dbsupervisor.MiddleName
                //};
                //model.Supervisor = supervisor.ID;
            }

            if (group.elderID != null)
            {
                model.Elder = (long)group.elderID;
                //var dbelder = context.GetUserByID((long)group.elderID);
                //var elder = new GroupUserInfo()
                //{
                //    ID = (long)group.elderID,
                //    Name = dbelder.Name,
                //    Surname = dbelder.Surname,
                //    MiddleName = dbelder.MiddleName
                //};
                //model.Elder = elder.ID;
            }
            
            var dbTech = context.GetUsers().Where(u => u.Roles.Contains("Teacher"));
            var supList = new List<GroupUserInfo>();
            supList.Add(new GroupUserInfo());
            foreach (var item in dbTech)
            {
                var tmpsup = new GroupUserInfo()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Surname = item.Surname,
                    MiddleName = item.MiddleName
                };
                supList.Add(tmpsup);
            }

            //var dbstuds = context.GetUsers().Where(u => u.Roles.Contains("Student"));
            var dbstuds = context.GetStudentByGroup(id);
            var studList = new List<GroupUserInfo>();
            studList.Add(new GroupUserInfo());
            foreach (var item in dbstuds)
            {
                var tmpstud = new GroupUserInfo()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Surname = item.Surname,
                    MiddleName = item.MiddleName
                };
                studList.Add(tmpstud);
            }

            model.Students = studList;
            model.TeacherList = supList;
            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(CRUGroupViewModel model)
        {
            var obj = new UniversityGroup()
            {
                GroupID = model.ID,
                elderID = model.Elder,
                GroupName = model.Name,
                SupervisorID = model.Supervisor
            };
            if (context.EditGroup(obj) == true)
                return RedirectToAction("Index");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var room = context.GetRoomByID(id);
            RoomViewModel model = new RoomViewModel()
            {
                ID = room.ID,
                RoomNo = room.RoomNo,
                Capacity = room.Capacity,
                IsAvailable = room.IsAvailable,
                Possibilities = context.GetRequirements(),
                SelectedPossibilities = room.SelectedPossibilities
            };
            return View(model);
        }


        public ActionResult Delete(int id)
        {
            context.DeleteRoom(id);
            return RedirectToAction("Index");
        }

        private object GetItemsPerPage(int page = 0)
        {
            var itemToSkip = page * pageSize;
            var list = new List<GroupInfoViewModel>();
            var dblst = context.GetGroups();
            foreach (var sub in dblst)
            {
                string SupervisorName = null;
                if (sub.SupervisorID != null)
                {
                    long id = (long)sub.SupervisorID;
                    var sup = context.GetUserByID(id);
                    SupervisorName = sup.Name + " " + sup.Surname;
                }
                string ElderName = null;
                if (sub.elderID != null)
                {
                    long id = (long)sub.elderID;
                    var eld = context.GetUserByID(id);
                    ElderName = eld.Name + " " + eld.Surname;
                }

                GroupInfoViewModel tmp = new GroupInfoViewModel
                {
                    ID = sub.GroupID,
                    Name = sub.GroupName,
                    CreationDate = sub.CreationDate.ToString(),
                    Faculty = context.GetFacultyByID(sub.FacultyID).Name,
                    Supervisor = SupervisorName,
                    Elder = ElderName
                };
                list.Add(tmp);
            }
            return list.OrderBy(f => f.ID).Skip(itemToSkip).Take(pageSize).ToList();
        }

    }
}