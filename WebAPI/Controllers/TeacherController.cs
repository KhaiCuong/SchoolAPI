
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using ModelLib.Model;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherRepository TeacherRepository;
        public TeacherController(ITeacherRepository TeacherRepository)
        {
            this.TeacherRepository = TeacherRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TeacherModel>> GetTeachers()
        {
            var Teachers = await TeacherRepository.GetTeachers();
            return Teachers;
        }

        [HttpGet("{id}")]
        public async Task<TeacherModel> GetTeacher(string id)
        {
            var Teachers = await TeacherRepository.GetTeacherById(id);
            return Teachers;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteTeacher(string id)
        {
            return await TeacherRepository.DeleteTeacherModel(id);
        }

        [HttpPost]
        public async Task<TeacherModel> PostTeacher(TeacherModel Teacher)
        {
            return await TeacherRepository.AddTeacherModel(Teacher);
        }

        [HttpPut("{id}")]
        public async Task<TeacherModel> UpdateTeacher(TeacherModel Teacher)
        {
            return await TeacherRepository.UpdateTeacherModel(Teacher);
        }









    }
}
