using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface ISchool
    {
        ITeacher GetTeacher(int id);

        void AddTeacher(ITeacher teacher);

        void RemoveTeacher(int id);

        IStudent GetStudent(int id);

        void AddStudent(IStudent student);

        void RemoveStudent(int id);

        int GetLastTeacherId { get; }

        int GetLastStudentId { get; }
    }
}
