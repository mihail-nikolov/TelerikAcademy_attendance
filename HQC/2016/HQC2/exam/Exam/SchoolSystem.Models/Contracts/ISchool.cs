namespace SchoolSystem.Models.Contracts
{
    /// <summary>
    ///  ISchool interface is used for managing teachers and students
    /// </summary>
    public interface ISchool
    {
        /// <summary>
        ///  GetTeacher is returning Teacher by ID
        /// </summary>
        /// <returns>teacher</returns>
        Teacher GetTeacher(int id);

        /// <summary>
        ///  AddTeacher adds provided teacher with provided id
        /// </summary>
        void AddTeacher(int id, Teacher teacher);

        /// <summary>
        ///  RemoveTeacher removed provided teacher by id
        /// </summary>
        void RemoveTeacher(int id);

        /// <summary>
        ///  GetStudent is returning Student by ID
        /// </summary>
        /// <returns>teacher</returns>
        Student GetStudent(int id);

        /// <summary>
        ///  AddStudent adds provided student with provided id
        /// </summary>
        void AddStudent(int id, Student student);

        /// <summary>
        ///  RemoveStudent removes provided student by id
        /// </summary>
        void RemoveStudent(int id);
    }
}
