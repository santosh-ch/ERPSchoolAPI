using ERPSchoolAPI.Models;
using ERPSchoolAPI.Repositories;
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
        private IStudentsRepository _studentsRepository;
        private IStudentsRepository _studentsRepository1;

        public StudentController(IStudentsRepository studentsRepository,IStudentsRepository studentsRepository1)
        {
            _studentsRepository = studentsRepository;
            _studentsRepository1 = studentsRepository1;
        }

        //[Route("{spart:int:min(5001)}")]
        //public Student GetStudentById(int spart)
        //{
        //    return this.students.Where(x => x.Id == spart).FirstOrDefault();
        //}

        //[Route("{spart:int:max(5001)}")]
        //public Student GetStudentByIdSmall(int spart)
        //{
        //    return this.students.Where(x => x.Id == spart).FirstOrDefault();
        //}

        [Route("{spart:minlength(6):alpha}")]
        public Student GetStudentByName(string spart)
        {
            return this._studentsRepository.GetStudents().Where(x => x.Name.ToLower() == spart.ToLower()).FirstOrDefault();
        }
        [Route("{spart:maxlength(6):alpha}")]
        public List<Student> GetStudentByNameSmall(string spart)
        {
            return this._studentsRepository.GetStudents().Where(x => x.Name.ToLower().Contains(spart.ToLower())).ToList();
        }

        [Route("{id}")]
        public List<Student> GetStudents([FromQuery] int id = 0, [FromQuery] string name = "", [FromQuery] int age=0)
        {
            if(id != 0 || name != string.Empty || age !=0)
                return this._studentsRepository.GetStudents().Where(
                        x => (id !=0 && x.Id == id)

                                || (name != string.Empty && x.Name.ToLower() == name.ToLower()) ||
                                (age != 0 && x.Age == age)).ToList();
            return this._studentsRepository.GetStudents();
        }

        [HttpPost]
        public IActionResult SubmitStudent(Student student)
        {
            try
            {
                this._studentsRepository.AddStudent(student);
                return Ok(this._studentsRepository1.GetStudents());
            }
            catch
            {
               return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetAllStudents([FromServices] IStudentsRepository studentsRepository)
        {
            return Ok(studentsRepository.GetStudents());
        }

    }
}
