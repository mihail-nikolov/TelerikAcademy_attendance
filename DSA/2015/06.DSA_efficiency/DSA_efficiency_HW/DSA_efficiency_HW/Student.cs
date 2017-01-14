namespace DSA_efficiency_HW
{
    public class Student
    {
        public Student(string fName, string LName)
        {
            this.FirstName = fName;
            this.LastName = LName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format(this.FirstName + " " + this.LastName);
        }
    }
}
