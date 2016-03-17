using EIMS.Common;
using EIMS.Models;
using EIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class SubjectController : Controller
    {
        IRepository context;
        const int pageSize = 25;

        public SubjectController()
        {
            context = new Repository.Repository();
        }

        public ActionResult Index()
        {
            return View(GetItemsPerPage());
        }
        // GET: Subject

        public ActionResult GetSubjectList(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("GetSubjectList_Partial", GetItemsPerPage(page));
            }
            return PartialView(GetItemsPerPage());
            //var subjList = context.GetSubjects();
            //var vmlist = new List<SubjectInfoViewModel>();
            //foreach (var item in subjList)
            //{
            //    var vmitem = new SubjectInfoViewModel() { ID = item.SubjectID, Name = item.SubjectName };
            //    vmlist.Add(vmitem);
            //}
            //return View(vmlist);
        }

        public ActionResult Create()
        {
            CreateSubjectViewModel model = new CreateSubjectViewModel();
            var reqList = context.GetRequirements();
            model.Requirements = reqList;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateSubjectViewModel model)
        {
            var subject = new Subject()
            {
                SubjectName = model.Name,
                Requirements = model.SelectedRequirements
            };
            if (context.CreateSubject(subject) == true)
                return RedirectToAction("Index");
            return View(model);

        }

        public ActionResult Edit(int id)
        {
            var subject = context.GetSubjects().Where(su => su.SubjectID == id).FirstOrDefault();
            CreateSubjectViewModel model = new CreateSubjectViewModel()
            {
                ID = subject.SubjectID,
                Name = subject.SubjectName,
                Requirements = context.GetRequirements(),
                SelectedRequirements = subject.Requirements
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CreateSubjectViewModel model)
        {
            var edSubj = new Subject()
            {
                SubjectID = model.ID,
                SubjectName = model.Name,
                Requirements = model.SelectedRequirements
            };
            if (context.UpdateSubject(edSubj) == true)
                return RedirectToAction("Index");
            model.Requirements = context.GetRequirements();
            return View(model);
        }


        public ActionResult Delete(int id)
        {
            context.DeleteSubject(id);
            return RedirectToAction("Index");
        }

        private object GetItemsPerPage(int page = 0)
        {
            var itemToSkip = page * pageSize;
            var subjectList = new List<SubjectInfoViewModel>();
            var dblst = context.GetSubjects();
            foreach (var sub in dblst)
            {
                SubjectInfoViewModel tmp = new SubjectInfoViewModel()
                {
                    ID = sub.SubjectID,
                    Name = sub.SubjectName
                };
                subjectList.Add(tmp);
            }
            return subjectList.OrderBy(f => f.ID).Skip(itemToSkip).Take(pageSize).ToList();
        }

    }
}