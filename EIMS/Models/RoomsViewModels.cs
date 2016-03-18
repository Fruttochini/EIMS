using EIMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIMS.Models
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Room Number")]
        public string RoomNo { get; set; }
        public short Capacity { get; set; }
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        public IEnumerable<Requirement> Possibilities { get; set; }
        public IEnumerable<int> SelectedPossibilities { get; set; }
    }

    public class RoomInfoViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Room Number")]
        public string RoomNo { get; set; }
        public short Capacity { get; set; }
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

    }
}