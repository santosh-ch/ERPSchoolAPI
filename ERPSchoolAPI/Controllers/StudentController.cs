using ERPSchoolAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        List<Student> students = new List<Student>();
        public StudentController()
        {
            students.Add(new Student() { Id = 1, Name = "Ramesh", Age = 7 });
            students.Add(new Student() { Id = 2, Name = "Suresh", Age = 10 });
            students.Add(new Student() { Id = 3, Name = "Mahesh", Age = 8 });
        }

        [Route("{spart:int:min(5001)}")]
        public Student GetStudentById(int spart)
        {
            return this.students.Where(x => x.Id == spart).FirstOrDefault();
        }

        [Route("{spart:int:max(5001)}")]
        public Student GetStudentByIdSmall(int spart)
        {
            return this.students.Where(x => x.Id == spart).FirstOrDefault();
        }

        [Route("{spart:minlength(6):alpha}")]
        public Student GetStudentByName(string spart)
        {
            return this.students.Where(x => x.Name.ToLower() == spart.ToLower()).FirstOrDefault();
        }
        [Route("{spart:maxlength(6):alpha}")]
        public List<Student> GetStudentByNameSmall(string spart)
        {
            return this.students.Where(x => x.Name.ToLower().Contains(spart.ToLower())).ToList();
        }

        public List<Student> GetStudents(int id = 0,string name = "",int age=0)
        {
            if(id != 0 || name != string.Empty || age !=0)
                return this.students.Where(
                        x => (id !=0 && x.Id == id)

                                || (name != string.Empty && x.Name.ToLower() == name.ToLower()) ||
                                (age != 0 && x.Age == age)).ToList();
            return this.students;
        }

    }
}
