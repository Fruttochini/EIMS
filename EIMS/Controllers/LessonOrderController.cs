using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class LessonOrderController : Controller
    {
		public IRepository context = new Repository.Repository();
		
        public ActionResult GetLessonOrders()
        {
			var lessonOrderList = new List<LessonOrderViewModel>();
			var dblst = context.GetLessonOrder();
			foreach(var item in dblst)
			{
				LessonOrderViewModel lovm = new LessonOrderViewModel()
				{
					lessonOrderID = item.lessonOrderID,
					timeStart = item.timeStart,
					timeEnd = item.timeEnd
				};
				lessonOrderList.Add(lovm);
			}
            return View(lessonOrderList);
        }

		public ActionResult CreateLessonOrder()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult CreateLessonOrder(LessonOrderViewModel lessonOrder)
		{
			if(ModelState.IsValid)
			{
				var tmpLessonOrder = new Common.LessonOrder()
				{
					timeStart = lessonOrder.timeStart,
					timeEnd = lessonOrder.timeEnd
				};
				if(context.CreateLessonOrder(tmpLessonOrder)==true)
				{
					return RedirectToAction("GetLessonOrders", "LessonOrder");
				}
				else
				{
					return View();
				}
			}
			return View(lessonOrder);
		}

		public ActionResult EditLessonOrder(int id)
		{
			var lessonOrder = context.GetLessonOrderByID(id);
			var tmpLessonOrder = new LessonOrderViewModel()
			{
				lessonOrderID = lessonOrder.lessonOrderID,
				timeStart = lessonOrder.timeStart,
				timeEnd = lessonOrder.timeEnd
			};
			return View(tmpLessonOrder);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult EditLessonOrder(LessonOrderViewModel model)
		{
			bool IsChanged = false;
			var lessonOrder = context.GetLessonOrderByID(model.lessonOrderID);
			var tmpLessonOrder = new Common.LessonOrder();
			if(!lessonOrder.timeStart.Equals(model.timeStart))
				IsChanged = true;
			if(!lessonOrder.timeEnd.Equals(model.timeEnd))
				IsChanged = true;
			if(IsChanged)
			{
				tmpLessonOrder.timeStart = model.timeStart;
				tmpLessonOrder.timeEnd = model.timeEnd;
				tmpLessonOrder.lessonOrderID = model.lessonOrderID;
				context.UpdateLessonOrder(tmpLessonOrder);
			}
			return RedirectToAction("GetLessonOrders", "LessonOrder");
		}

		public ActionResult DeleteLessonOrder(int id)
		{
			context.DeleteLessonOrder(id);
			return RedirectToAction("GetLessonOrders", "LessonOrder");
		}
    }
}