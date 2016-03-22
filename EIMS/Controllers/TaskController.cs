using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class TaskController : Controller
    {
		private IRepository context = new Repository.Repository();
		const int pageSize = 20;

        public ActionResult Index(int groupID, DateTime selectDate)
        {
			return View(GetItemPerPage(groupID, selectDate));
        }

		private object GetItemPerPage(int groupID, DateTime selectDate, int page = 0)
		{
			var itemToSkip = page * pageSize;
			var taskForGroupByDate = new List<TaskList>();
			var task = new TaskViewModel();
			var dbLst = context.GetTaskForGroupByDate(groupID, selectDate);
			foreach(var item in dbLst)
			{
				TaskList tList = new TaskList()
				{
					taskID = item.taskID,
					lessonDateID = item.lessonDateID,
					homeTask = item.homeTask,
					expireDate = item.expiryDate,
					SubjectName = item.subjectName,
					GroupName = item.groupName
				};
				taskForGroupByDate.Add(tList);
			}
			var tmpGroup = context.GetGroupByID(groupID);
			GroupInfoViewModel gInfo = new GroupInfoViewModel()
			{
				ID = tmpGroup.GroupID,
				Name = tmpGroup.GroupName
			};
			task.taskList = taskForGroupByDate.OrderBy(t => t.taskID).Skip(itemToSkip).Take(pageSize).ToList();
			task.SelectGroup = gInfo;
			task.SelectDate = selectDate;
			return task;
		}

		public ActionResult GetTasks(int groupID, DateTime selectDate, int? id)
		{
			int page = id ?? 0;
			if(Request.IsAjaxRequest())
			{
				return PartialView("GetTasks", GetItemPerPage(groupID, selectDate, page));
			}
			return PartialView(GetItemPerPage(groupID, selectDate));
		}

		public ActionResult CreateTask(long lessonPrecenseID)
		{
			var tmp = context.GetLessonPrecenseByID(lessonPrecenseID);
			CreateEditTaskViewModel model = new CreateEditTaskViewModel()
			{
				lessonDateID = tmp.lessonDateID, 
			};
			model.SelectLessonPrecense = tmp.lessonPresenseID;
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateTask(CreateEditTaskViewModel model)
		{
			if(ModelState.IsValid)
			{
				var tmpTask = new Common.Task()
				{
					lessonDateID = model.lessonDateID,
					homeTask = model.homeTask,
					expiryDate = model.expireDate
				};
				if(context.CreateTask(tmpTask) == true)
				{
					return RedirectToAction("LessonPrecense","LessonPrecense", new { lessonPrecenseID = model.SelectLessonPrecense });
				}
				else
				{
					return View();
				}
			}
			return View(model);
		}

		public ActionResult EditTask(int taskID, int groupID, DateTime selectDate)
		{
			var task = context.GetTaskByID(taskID);
			var tmpTask = new CreateEditTaskViewModel()
			{
				taskID = task.taskID,
				lessonDateID = task.lessonDateID,
				homeTask = task.homeTask,
				expireDate = task.expiryDate,
				SelectGroup = groupID,
				SelectDate = selectDate
			};
			return View(tmpTask);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditTask(CreateEditTaskViewModel model)
		{
			bool IsChanged = false;
			var task = context.GetTaskByID(model.taskID);
			var tmpTask = new Common.Task();
			if(!task.homeTask.Equals(model.homeTask))
			{
				IsChanged = true;
				tmpTask.homeTask = model.homeTask;
			}
			if(!task.expiryDate.Equals(model.expireDate))
			{
				IsChanged = true;
				tmpTask.expiryDate = model.expireDate;
			}
			if(IsChanged)
			{
				tmpTask.taskID = model.taskID;
				tmpTask.lessonDateID = model.lessonDateID;
				tmpTask.expiryDate = model.expireDate;
				context.UpdateTask(tmpTask);
			}
			return RedirectToAction("Index", new { groupID = model.SelectGroup, selectDate = model.SelectDate });
		}

		public ActionResult DeleteTask(long id, int GroupID, DateTime SelectDate)
		{
			if (context.DeleteTask(id) == true)
				return RedirectToAction("Index", new { groupID = GroupID, selectDate = SelectDate });
			return View();
		}
    }
}