namespace SchoolSystem.Models
{
    using SchoolSystem.Models.Enums;

    public class Teacher : Person
    {
        private static int teachersId = 0;

        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
            this.SetId();
        }

        public Subject Subject { get; private set; }

        public void AddMark(Student student, float value)
        {
            var mark = new Mark(this.Subject, value);
            student.Marks.Add(mark);
        }

        protected override void SetId()
        {
            this.Id = teachersId;
            teachersId++;
        }
    }
}
