using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        public Machine(string name, double attack, double defense)
        {
            this.Name = name;
            this.AttackPoints = attack;
            this.DefensePoints = defense;
            this.Targets = new List<string>();
        }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public double HealthPoints { get; set; }

        public string Name { get; set; }

        public IPilot Pilot { get; set; }

        public IList<string> Targets { get; private set; }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder machineInfo = new StringBuilder();
            machineInfo.AppendLine(string.Format("- {0}", this.Name));
            machineInfo.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            machineInfo.AppendLine(string.Format(" *Health: {0}", this.HealthPoints.ToString()));
            machineInfo.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints.ToString()));
            machineInfo.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints.ToString()));

            string targets = string.Empty;
            if (this.Targets.Count == 0)
            {
                targets = "None";
            }
            else
            {
                targets = string.Join(", ", this.Targets.ToArray());
            }

            machineInfo.AppendLine(string.Format(" *Targets: {0}", targets));

            return machineInfo.ToString();
        }
    }
}
