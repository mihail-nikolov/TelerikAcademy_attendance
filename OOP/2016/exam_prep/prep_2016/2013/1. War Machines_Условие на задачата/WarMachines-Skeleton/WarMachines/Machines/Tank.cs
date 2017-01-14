using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        public Tank(string name, double attack, double defense)
            : base(name, attack, defense)
        {
            this.HealthPoints = 100;
            this.DefenseMode = true;
            this.DefensePoints += 30;
            this.AttackPoints -= 40;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
           // Console.WriteLine("Tank {0} toggled defense mode", this.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine(string.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));
            return sb.ToString().TrimEnd();
        }
    }
}
