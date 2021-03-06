﻿using EIMS.Common;
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

        public SubjectController(IRepository repo)
        {
            context = repo;
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

        public ActionResult Details(int id)
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


        public ActionResult Delete(int id)
        {
            context.DeleteSubject(id);
            return RedirectToAction("Index");
        }

        public ActionResult AddRequirement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRequirement(RequirementViewModel model)
        {
            Requirement req = new Requirement()
            {
                Name = model.Name
            };
            if (context.AddRequirement(req))
                return RedirectToAction("Index");
            return View(model);

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