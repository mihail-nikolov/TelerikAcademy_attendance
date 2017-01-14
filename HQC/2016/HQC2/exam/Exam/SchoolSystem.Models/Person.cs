namespace SchoolSystem.Models
{
    using System;

    public abstract class Person
    {
        private const int MinLenght = 2;
        private const int MaxLength = 31;
        private const string NameLengthErroMessage = "Name length should be in interval [{0}; {1}]";

        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value.Length < MinLenght || value.Length > MaxLength)
                {
                    string errorMessage = string.Format(NameLengthErroMessage, MinLenght, MaxLength);
                    throw new ArgumentException(errorMessage);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value.Length < MinLenght || value.Length > MaxLength)
                {
                    string errorMessage = string.Format(NameLengthErroMessage, MinLenght, MaxLength);
                    throw new ArgumentException(errorMessage);
                }

                this.lastName = value;
            }
        }

        public int Id { get; protected set; }

        protected abstract void SetId();
    }
}
