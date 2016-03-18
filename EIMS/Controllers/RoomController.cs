using EIMS.Common;
using EIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIMS.Controllers
{
    public class RoomController : Controller
    {
        IRepository context;
        const int pageSize = 50;

        public RoomController()
        {
            context = new Repository.Repository();
        }

        public RoomController(IRepository repo)
        {
            context = repo;
        }

        public ActionResult Index()
        {
            return View(GetItemsPerPage());
        }
        // GET: Subject

        public ActionResult GetRoomsList(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_GetRoomsListPartial", GetItemsPerPage(page));
            }
            return PartialView(GetItemsPerPage());

        }

        public ActionResult Create()
        {
            RoomViewModel model = new RoomViewModel();
            var reqList = context.GetRequirements();
            model.Capacity = 10;
            model.IsAvailable = true;
            model.Possibilities = reqList;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RoomViewModel model)
        {
            var room = new Room()
            {
                RoomNo = model.RoomNo,
                IsAvailable = model.IsAvailable,
                SelectedPossibilities = model.SelectedPossibilities,
                Capacity = model.Capacity
            };
            if (context.AddRoom(room) == true)
                return RedirectToAction("Index");
            return View(model);

        }

        public ActionResult Edit(int id)
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

        [HttpPost]
        public ActionResult Edit(RoomViewModel model)
        {
            var obj = new Room()
            {
                ID = model.ID,
                RoomNo = model.RoomNo,
                Capacity = model.Capacity,
                SelectedPossibilities = model.SelectedPossibilities,
                IsAvailable = model.IsAvailable

            };
            if (context.EditRoom(obj) == true)
                return RedirectToAction("Index");
            model.Possibilities = context.GetRequirements();
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
            var list = new List<RoomInfoViewModel>();
            var dblst = context.GetRooms();
            foreach (var sub in dblst)
            {
                RoomInfoViewModel tmp = new RoomInfoViewModel()
                {
                    ID = sub.ID,
                    RoomNo = sub.RoomNo,
                    IsAvailable = sub.IsAvailable,
                    Capacity = sub.Capacity
                };
                list.Add(tmp);
            }
            return list.OrderBy(f => f.ID).Skip(itemToSkip).Take(pageSize).ToList();
        }

    }
}
