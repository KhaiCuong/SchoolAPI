using ModelLib.Model;

namespace WebAPI.Repository 
{ 
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>>  GetCourse();

        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);

        //Course GetStudentById(string id);
        //void AddStudent(Course student);
        //void UpdateStudent(Course student);
        //void DeleteStudent(string id);
    }
}
