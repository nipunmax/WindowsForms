using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Party_planner
{
    class Birthday : Party
    {
        

        public string CakeWriting { get; set; }

        public Birthday(int numb, bool fancy, string cake) { NumberOfPeople = numb; FancyDecorations = fancy; CakeWriting = cake; }
        private int ActualLength
        {
            get
            {
                if (CakeWriting.Length > MaxWritingLength())
                    return MaxWritingLength();
                else
                    return CakeWriting.Length;
            }
        }

        public bool iscakewritinglong
        {
            get
            {
                if (CakeWriting.Length < MaxWritingLength())
                    return false;
                else
                    return true;
            }
        }
        private int CakeSize()
        {
            if (NumberOfPeople <= 4)
                return 8;
            else
                return 16;
        }
        private int MaxWritingLength()
        {
            if (CakeSize() == 8)
                return 16;
            else
                return 40;
        }


        override public decimal Cost
        {
            get
            {
                decimal totalCost = base.Cost;
                decimal cakeCost;
                if (CakeSize() == 8)
                    cakeCost = 40M + ActualLength * .25M;
                else
                    cakeCost = 75M + ActualLength * .25M;
                return totalCost + cakeCost;
            }
        }
    }
}
