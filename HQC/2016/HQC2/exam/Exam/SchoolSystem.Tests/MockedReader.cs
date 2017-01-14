namespace SchoolSystem.Tests
{
    using SchoolSystem.Core.Contracts;

    public class MockedReader : IReader
    {
        private string command;
        private int invoked;

        public MockedReader(string command)
        {
            this.command = command;
            invoked = 0;
        }

        public string Read()
        {
            invoked++;
            if (invoked > 1)
            {
                return "End";
            }
            return this.command;
        }
    }
}
