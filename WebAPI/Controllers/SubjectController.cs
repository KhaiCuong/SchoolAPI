using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;
using WebAPI.Repository;
using System.Transactions;
using Microsoft.Data.SqlClient;
using System.Transactions;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ISubjectRepository SubjectRepository;
        public SubjectController(ISubjectRepository SubjectRepository)
        {
            this.SubjectRepository = SubjectRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectModels>> GetSubjects()
        {
            var Subjects = await SubjectRepository.GetSubjects();
            return Subjects;
        }

        [HttpGet("{id}")]
        public async Task<SubjectModels> GetSubject(string id)
        {
            var Subjects = await SubjectRepository.GetSubjectById(id);
            return Subjects;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSubject(string id)
        {
            return await SubjectRepository.DeleteSubject(id);
        }

        [HttpPost]
        public async Task<SubjectModels> PostSubject(SubjectModels Subject)
        {
            return await SubjectRepository.AddSubject(Subject);
        }

        [HttpPut("{id}")]
        public async Task<SubjectModels> UpdateSubject(SubjectModels Subject)
        {
            return await SubjectRepository.UpdateSubject(Subject);
        }





    }
}
