using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Party_planner
{
    class Party
    {
        public const int CostOfFoodPerPerson = 25;
        public int NumberOfPeople { get; set; }
        public bool FancyDecorations { get; set; }

         virtual public decimal Cost
        {
            get
            {
                decimal TotalCost = CalculateCostOfDecorations();
                TotalCost = TotalCost + NumberOfPeople*CostOfFoodPerPerson;
                if (NumberOfPeople < 10)
                {
                    TotalCost = TotalCost + 100;
                    
                }
                return TotalCost;
                   
            }

        }
        private decimal CalculateCostOfDecorations()
        {
            decimal costOfDecorations;
            if (FancyDecorations)
                costOfDecorations = (NumberOfPeople * 15.00M) + 50M;
            else
                costOfDecorations = (NumberOfPeople * 7.50M) + 30M;
            return costOfDecorations;
        }
    }
}
