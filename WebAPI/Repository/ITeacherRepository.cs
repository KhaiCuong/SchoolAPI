using ModelLib.Model;


namespace WebAPI.Repository
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherModel>>  GetTeachers();
        Task<TeacherModel> GetTeacherById(string Teacher_Id);
        Task<TeacherModel> AddTeacherModel(TeacherModel Teacher);
        Task<TeacherModel> UpdateTeacherModel(TeacherModel updateTeacher);
        Task<bool> DeleteTeacherModel(string Teacher_Id);

       Task<IEnumerable<Course>>GetCourse();

    }
}
