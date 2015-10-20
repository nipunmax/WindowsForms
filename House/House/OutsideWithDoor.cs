using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
    {

       
        public Location location { get; set; }
      
        public string DoorDescription { get; set; }
        public OutsideWithDoor(bool hot, string name, string doordes) : base(hot, name) { DoorDescription = doordes; }

        public override string Description
        {
            get
            {
                return base.Description + " You see " + DoorDescription + ".";
            }
        }
    }
}