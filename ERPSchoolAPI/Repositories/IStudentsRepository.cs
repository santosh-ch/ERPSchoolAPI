using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSchoolAPI.Models;

namespace ERPSchoolAPI.Repositories
{
    public interface IStudentsRepository
    {
        public List<Student> GetStudents();
        public void AddStudent(Student student);
    }
}
