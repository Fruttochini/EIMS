using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Common
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomNo { get; set; }
        public bool[] Features { get; set; }
        public short Capacity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
