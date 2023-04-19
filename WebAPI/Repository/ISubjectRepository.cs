using ModelLib.Model;


namespace WebAPI.Repository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<SubjectModels>>  GetSubjects();
        Task<SubjectModels> GetSubjectById(string id);
        Task<SubjectModels> AddSubject(SubjectModels subject, IFormFile photo);
        Task<SubjectModels> UpdateSubject(SubjectModels subject, IFormFile photo);
        Task<bool> DeleteSubject(string id);

        Task<IEnumerable<Course>> GetCourse();
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);






    }
}
