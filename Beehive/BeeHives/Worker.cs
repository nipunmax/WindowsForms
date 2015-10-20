using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHives
{
    class Worker:Bee
    {
        
        public int ShiftLeft {
            get
            {
                return shiftsToWork -shiftsWorked;
            }
        }
        const double honeyUnitsPerShiftWorked = .65;
        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        
        private string currentJob = "";
        public string CurrentJob
        {
            get
            {
                return currentJob;
            }
        }
        public Worker(string[] JobsICanDo,double cons)
        :base(cons)
        {
            this.jobsICanDo = JobsICanDo;
            
        }

        public bool doThisJob(string job, int shifts)
        {
            if (!String.IsNullOrEmpty(currentJob))
                return false;
            else
            {
                for (int i = 0; i < jobsICanDo.Length; i++)
                {
                    if (jobsICanDo[i] == job)
                    {
                        currentJob = job;
                        shiftsToWork = shifts;
                        shiftsWorked = 0;
                        return true;
                    }
                    
                }
            }
            return false;

        }

        public bool didYouFinish()
        {
            if (String.IsNullOrEmpty(currentJob))
                return false;
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsToWork = 0;
                shiftsWorked = 0;
                currentJob = "";
                return true;
            }
            return false;
        }

        public override double HoneyConsumptionRate()
        {
            double consumption = base.HoneyConsumptionRate();
            consumption = shiftsWorked * honeyUnitsPerShiftWorked;
            return consumption;

        }
    }
}
