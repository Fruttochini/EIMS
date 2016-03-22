using EIMS.Common;
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
            var group = context.GetGroupByID(id);
            GroupInfoViewModel model = new GroupInfoViewModel()
            {
                ID = group.GroupID,
                CreationDate = group.CreationDate.Date.ToString(),
                Name = group.GroupName,
            };
            model.Faculty = context.GetFacultyByID(group.FacultyID).Name;

            if (group.SupervisorID != null)
            {
                var super = context.GetUserByID((long)group.SupervisorID);
                model.Supervisor = super.Name + " " + super.MiddleName + " " + super.Surname;
            }
            if (group.elderID != null)
            {
                var super = context.GetUserByID((long)group.elderID);
                model.Elder = super.Name + " " + super.MiddleName + " " + super.Surname;
            }
            return View(model);
        }

        public ActionResult AssignStudents(int id)
        {
            var dbNonGroupStudList = context.GetStudentsWOGroups();
            List<GroupUserInfo> students = new List<GroupUserInfo>();
            foreach (var stud in dbNonGroupStudList)
            {
                var tmpstud = new GroupUserInfo()
                {
                    ID = stud.ID,
                    Name = stud.Name,
                    Surname = stud.Surname,
                    MiddleName = stud.MiddleName
                };
                students.Add(tmpstud);
            }

            var dbStudInGroup = context.GetStudentByGroup(id);
            List<GroupUserInfo> stInGr = new List<GroupUserInfo>();
            foreach (var stud in dbStudInGroup)
            {
                var tmpstud = new GroupUserInfo()
                {
                    ID = stud.ID,
                    Name = stud.Name,
                    Surname = stud.Surname,
                    MiddleName = stud.MiddleName
                };
                stInGr.Add(tmpstud);
            }

            var stingrids = dbStudInGroup.Select(st => st.ID);

            var grp = context.GetGroupByID(id);

            var fac = context.GetFacultyByID(grp.FacultyID);

            StudentGroupAssignmentViewModel model = new StudentGroupAssignmentViewModel()
            {
                ID = grp.GroupID,
                Name = grp.GroupName,
                GroupStudents = stInGr,
                StudinGroupIDs = stingrids,
                Students = students,
                Faculty = fac.Name
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AssignStudents(StudentGroupAssignmentViewModel model)
        {


            if (model.StudinGroupIDs != null)
            {
                var studInGrIDs = context.GetStudentByGroup(model.ID).Select(u => u.ID).ToList();
                if (studInGrIDs.Count != model.StudinGroupIDs.ToList().Count)
                {
                    var deasignList = studInGrIDs.Except(model.StudinGroupIDs);
                    foreach (var item in deasignList)
                    {
                        context.DeassignStudent(model.ID, item);
                    }
                }
            }
            else
            {
                var studInGrIDs = context.GetStudentByGroup(model.ID).Select(u => u.ID).ToList();
                foreach (var item in studInGrIDs)
                {
                    context.DeassignStudent(model.ID, item);
                }
            }

            if (model.StudentsToAssign != null)
            {
                foreach (var item in model.StudentsToAssign)
                {
                    context.AssignStudent(model.ID, item);
                }
            }
            return RedirectToAction("Index");
        }



        //public ActionResult Delete(int id)
        //{
        //    context.DeleteRoom(id);
        //    return RedirectToAction("Index");
        //}

        public ActionResult Schedule(int id)
        {
            var dbList = context.GetLessonsByGroup(id);
            var model = new ScheduleViewModel()
            {
                GroupID = id,
                GroupName = context.GetGroupByID(id).GroupName

            };
            List<LessonInfoViewModel> lessons = new List<LessonInfoViewModel>();
            foreach (var item in dbList)
            {
                LessonInfoViewModel lesson = new LessonInfoViewModel()
                {
                    LessonID = item.LessonID,
                    DayID = item.DayOfWeek,
                    OrderID = item.LessonOrder,
                    RoomNo = item.RoomNo,
                    Subject = item.SubjectName,
                    Teacher = item.TeacherFullName
                };
                lessons.Add(lesson);
            }

            var dbDays = context.GetDayOfWeek();
            List<DayVm> days = new List<DayVm>();
            foreach (var item in dbDays)
            {
                var tmp = new DayVm()
                {
                    ID = item.DayID,
                    Name = item.DayName
                };
                days.Add(tmp);
            }
            days.OrderBy(f => f.ID);

            var dbOrdnung = context.GetLessonOrder();
            List<LessonOrderViewModel> order = new List<LessonOrderViewModel>();
            foreach (var item in dbOrdnung)
            {
                var tmp = new LessonOrderViewModel()
                {
                    lessonOrderID = item.lessonOrderID,
                    timeStart = item.timeStart,
                    timeEnd = item.timeEnd
                };
                order.Add(tmp);
            }
            order.OrderBy(o => o.timeStart);

            model.Order = order;
            model.LessonList = lessons;
            model.Days = days;
            return View(model);
        }

        public ActionResult ScheduleAddLesson(int groupID, byte dayID, int LOID)
        {
            NewLessonViewModel LVM = new NewLessonViewModel();
            var group = context.GetGroupByID(groupID);
            var lo = context.GetLessonOrderByID(LOID);
            var day = context.GetDayOfWeek().Where(d => d.DayID == dayID).FirstOrDefault();

            LVM.Group = new GroupInfoViewModel()
            {
                ID = groupID,
                Name = group.GroupName
            };

            LVM.LesOrd = new LessonOrderViewModel()
            {
                lessonOrderID = lo.lessonOrderID,
                timeStart = lo.timeStart,
                timeEnd = lo.timeEnd
            };
            LVM.Day = new DayVm()
            {
                ID = day.DayID,
                Name = day.DayName
            };

            List<SubjectInfoViewModel> sublist = new List<SubjectInfoViewModel>();
            foreach (var item in context.GetSubjectsByGroupID(groupID))
            {
                var svm = new SubjectInfoViewModel()
                {
                    ID = item.SubjectID,
                    Name = item.SubjectName
                };
                sublist.Add(svm);
            }

            LVM.Subjects = sublist;

            return View(LVM);
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