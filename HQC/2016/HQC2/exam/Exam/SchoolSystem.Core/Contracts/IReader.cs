namespace SchoolSystem.Core.Contracts
{
    /// <summary>
    ///  IReader is used to read commands
    /// </summary>
    public interface IReader
    {
        /// <summary>
        ///  Read is used to to read the commands and provides abstraction of what is used to read
        /// </summary>
        /// <returns>comamnd output</returns>
        string Read();
    }
}
