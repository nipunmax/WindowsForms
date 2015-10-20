﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Party_planner
{
    class DinnerParty : Party
    {

       
    

        public decimal CostOfBeveragesPerPerson;
        

        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations)
        {
            NumberOfPeople = numberOfPeople;
            FancyDecorations = fancyDecorations;
            SetHealthyOption(healthyOption);
            
        }

        public void SetHealthyOption(bool healthyOption)
        {
            if (healthyOption)
            {
                CostOfBeveragesPerPerson = 5.00M;
            }
            else
            {
                CostOfBeveragesPerPerson = 20.00M;
            }
        }

   

        public decimal CalculateCost(bool healthyOption)
        {
            decimal totalCost = base.Cost
               + ((CostOfBeveragesPerPerson + CostOfFoodPerPerson) * NumberOfPeople);

            if (healthyOption)
            {
                return totalCost * .95M;
            }
            else
            {
                return totalCost;
            }
        }
    }
}