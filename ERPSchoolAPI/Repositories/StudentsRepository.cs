using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSchoolAPI.Models;

namespace ERPSchoolAPI.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        List<Student> students = new List<Student>();
        //students.Add(new Student() { Id = 1, Name = "Ramesh", Age = 7 });
        //    students.Add(new Student() { Id = 2, Name = "Suresh", Age = 10 });
        //    students.Add(new Student() { Id = 3, Name = "Mahesh", Age = 8 });

        public List<Student> GetStudents()
        {
            return students;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
}
