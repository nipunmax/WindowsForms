using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Room : Location
    {
        public string Decoration { get; private set; }
        public Room(string decoration, string name)
            : base(name)
        {
            this.Decoration = decoration;
        }
        public override string Description
        {
            get
            {
                return base.Description + " You see " + Decoration + ".";
            }
        }
    }
}

