using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        public Fighter(string name, double attack, double defense, bool stealth)
            : base(name, attack, defense)
        {
            this.StealthMode = stealth;
            this.HealthPoints = 200;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            if (this.StealthMode)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
           // Console.WriteLine("Fighter {0} manufactured - attack: {1}; defense: {2}; stealth: {3}",
           //     this.Name, this.AttackPoints, this.DefensePoints, this.StealthMode ? "ON" : "OFF");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));
            return sb.ToString().TrimEnd();
        }
    }
}
