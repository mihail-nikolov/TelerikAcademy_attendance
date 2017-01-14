using System.Collections.Generic;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name { get; private set; }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder reportB = new StringBuilder();
            reportB.AppendLine(string.Format("{0} - {1} {2}",
                this.Name,
                this.machines.Count == 0 ? "no" : this.machines.Count.ToString(),
                this.machines.Count == 1 ? "machine" : "machines"));
            foreach (var machine in this.machines)
            {
                reportB.AppendLine(machine.ToString());
            }
            return reportB.ToString().TrimEnd();
        }
    }
}
