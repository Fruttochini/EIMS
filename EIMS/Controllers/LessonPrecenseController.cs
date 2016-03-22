using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class LessonPrecenseController : Controller
    {
		private IRepository context = new Repository.Repository();
		const int pageSize = 25;

        public ActionResult Index(long lessonDateID)
        {
            return View(GetItemsPerPage(lessonDateID));
        }

		private object GetItemsPerPage(long lessonDateID, int page = 0)
		{
			var itemToSkip = page * pageSize;
			var lessonPrecense = new List<LessonPrecenseList>();
			var lesson = new LessonPrecenseViewModel();
		}
	}
}