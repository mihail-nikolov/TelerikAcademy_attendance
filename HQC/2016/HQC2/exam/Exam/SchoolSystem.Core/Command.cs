namespace SchoolSystem.Core
{
    using System.Collections.Generic;
    using SchoolSystem.Core.Contracts;
    using SchoolSystem.Models.Contracts;

    public abstract class Command : ICommand
    {
        public abstract string Execute(IList<string> parameters, ISchool school);
    }
}
