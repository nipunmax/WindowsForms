using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public Location location { get; set; }
  
        public string DoorDescription { get; set; }

        public RoomWithDoor(string deco, string name, string doordes) : base(deco, name) { DoorDescription = doordes; }
        public override string Description
        {
            get
            {
                return base.Description + " You see " + DoorDescription + ".";
            }
        }
    }
}