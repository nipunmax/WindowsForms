
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Outside:Location
    {
        public bool isHot { get; private set; }
    public Outside(bool hot , string name):base(name)
    {
        this.isHot = hot;
    }
    public override string Description
    {
        get
        {
            string newDescription = base.Description;
            if (isHot)
                newDescription += " It’s very hot.";
            return newDescription;
        }
    }
    }

}
