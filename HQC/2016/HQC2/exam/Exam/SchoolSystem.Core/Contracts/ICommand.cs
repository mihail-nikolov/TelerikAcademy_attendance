namespace SchoolSystem.Core.Contracts
{
    using System.Collections.Generic;
    using Models.Contracts;

    /// <summary>
    ///  ICommand interface is used for parsing commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///  Execute is used to execute the command with the given parameters
        /// </summary>
        /// <returns>comamnd output</returns>
        string Execute(IList<string> parameters, ISchool school);
    }
}
