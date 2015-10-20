using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    abstract class Location
    {
        public string Name { private set; get; }
        public Location [] Exits;
        public virtual string Description
        {
            get
            {
                string Description = "You’re standing in the " + Name
                    + ". You see exits to the following places: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    Description += " " + Exits[i];
                    if (i != Exits.Length - 1)
                        Description += ",";
                }
                Description += ".";
                return Description;
             
            }
        }


        public Location(string name) { this.Name = name; }
    }
}