using ModelLib.Model;
using System.Security.Principal;

namespace WebAPI.Repository
{
    public interface IClassRepository
    {
        //ClassModel checkLogin(string CLassId, string Password);
        Task<IEnumerable<ClassModel>> GetClasss();
        Task<ClassModel> GetClassById(string classId);
        Task<ClassModel> AddClassModel(ClassModel classmodel, IFormFile photo);
        Task<ClassModel> UpdateClassModel(ClassModel updateClass, IFormFile photo);
        Task<bool> DeleteClassModel(string Class_Id);
    }
}
