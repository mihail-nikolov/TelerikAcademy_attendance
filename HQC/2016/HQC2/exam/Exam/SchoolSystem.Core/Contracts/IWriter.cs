namespace SchoolSystem.Core.Contracts
{
    /// <summary>
    ///  IWriter interface is write command output
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        ///  WriteLine is used write the command input and provides abstraction where this output should be written
        /// </summary>
        void WriteLine(string lineToWrite);
    }
}