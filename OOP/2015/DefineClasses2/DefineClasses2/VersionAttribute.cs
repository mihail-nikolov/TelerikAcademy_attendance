using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method,
    AllowMultiple = true)]
    public class VersionAttribute : System.Attribute
    {
        public string Version { get; private set; }
        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}