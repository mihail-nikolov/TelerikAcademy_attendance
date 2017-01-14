namespace SchoolSystem.Models
{
    using System;
    using SchoolSystem.Models.Enums;

    public class Mark
    {
        private const float MinValue = 2;
        private const float MaxValue = 6;

        private float value;

        public Mark(Subject subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    string errorMessage = string.Format("Value should be in interval [{0}; {1}]", MinValue, MaxValue);
                    throw new ArgumentException(errorMessage);
                }

                this.value = value;
            }
        }

        public Subject Subject { get; set; }
    }
}
