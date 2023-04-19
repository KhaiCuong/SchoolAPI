using ModelLib.Model;

namespace WebAPI.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentModel>>  GetStudent();
        Task<StudentModel> GetStudentById(string id);
        Task<StudentModel> AddStudent(StudentModel student);
        Task<StudentModel> UpdateStudent(StudentModel student);
        Task<bool> DeleteStudent(string id);
    }
}
