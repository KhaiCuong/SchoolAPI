using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ModelLib.Model;
using WebAPI.Repository;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository StudentRepository;
        public StudentController(IStudentRepository StudentRepository)
        {
            this.StudentRepository = StudentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentModel>> GetStudents()
        {
            var Students = await StudentRepository.GetStudent();
            return Students;
        }

        [HttpGet("{id}")]
        public async Task<StudentModel> GetStudent(string id)
        {
            var Students = await StudentRepository.GetStudentById(id);
            return Students;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteStudent(string id)
        {
            return await StudentRepository.DeleteStudent(id);
        }

        [HttpPost]
        public async Task<StudentModel> PostStudent(StudentModel Student)
        {
            return await StudentRepository.AddStudent(Student);
        }

        [HttpPut("{id}")]
        public async Task<StudentModel> UpdateStudent(StudentModel Student)
        {
            return await StudentRepository.UpdateStudent(Student);
        }

    }
}
