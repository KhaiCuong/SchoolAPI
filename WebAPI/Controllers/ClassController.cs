using ModelLib.Model;
using WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IClassRepository ClassRepository;
        public ClassController(IClassRepository ClassRepository)
        {
            this.ClassRepository = ClassRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassModel>> GetClasss()
        {
            var Classs = await ClassRepository.GetClasss();
            return Classs;
        }

        [HttpGet("{id}")]
        public async Task<ClassModel> GetClass(string id)
        {
            var Classs = await ClassRepository.GetClassById(id);
            return Classs;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteClass(string id)
        {
            return await ClassRepository.DeleteClassModel(id);
        }

        [HttpPost]
        public async Task<ClassModel> PostClass(ClassModel Class)
        {
            return await ClassRepository.AddClassModel(Class);
        }

        [HttpPut("{id}")]
        public async Task<ClassModel> UpdateClass(ClassModel Class)
        {
            return await ClassRepository.UpdateClassModel(Class);
        }

    }
}
