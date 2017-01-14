using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsWorkers
{
    class Worker: Human
    {
        const double workingDaysPerWeek = 5;
        private double weekSalary;
        private double worksHoursPerDay;

        public Worker(string fname, string lname, double weekSalary, double worksHoursPerDay)
            : base(fname, lname)
        {
            this.WeekSalary = weekSalary;
            this.WorksHoursPerDay = worksHoursPerDay;
        }
        public double WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("cannot input negative salary");
                }
                this.weekSalary = value;
            }
        }
        public double WorksHoursPerDay
        {
            get { return this.worksHoursPerDay; }
            set
            {
                if (value < 0 || value > 8)
                {
                    throw new ArgumentException("working hours [0; 8]");
                }
                this.worksHoursPerDay = value;
            }
        }
        public double MoneyPerHour()
        {
            return this.WeekSalary / (this.WorksHoursPerDay * workingDaysPerWeek);
        }

    }
}
