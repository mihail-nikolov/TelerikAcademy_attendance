using Dealership.Common;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string author;
        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }
        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                // no valudation is neede regarding the task
                //string exceptionMessage = string.Format(
                //    Constants.StringMustBeBetweenMinAndMax,
                //    nameof(this.Author).ToString(),
                //    Constants.MinNameLength,
                //    Constants.MaxNameLength);

                //Validator.ValidateIntRange(
                //    value.Length,
                //    Constants.MinNameLength,
                //    Constants.MaxNameLength,
                //    exceptionMessage
                //    );
                this.author = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            
            private set
            {
                string exceptionMessage = string.Format(
                    Constants.StringMustBeBetweenMinAndMax,
                    "Content",
                    Constants.MinCommentLength,
                    Constants.MaxCommentLength);

                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinCommentLength,
                    Constants.MaxCommentLength,
                    exceptionMessage
                    );
                this.content = value;
            }
        }
    }
}
