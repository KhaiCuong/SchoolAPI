using Microsoft.EntityFrameworkCore;
using ModelLib.Model;
using WebAPI.Data;
using WebAPI.Repository;

namespace WebAPI.Service
{
    public class StudentServiceImp : IStudentRepository
    {
        private DatabaseContext _dbContext;
        public StudentServiceImp(DatabaseContext databaseContext)
        {
            this._dbContext = databaseContext;
        }

        public async Task<StudentModel> AddStudent(StudentModel student)
        {
            var st = _dbContext.Students.SingleOrDefault(a => a.Student_Id.Equals(student.Student_Id));
            if (st == null)
            {

                await _dbContext.Students.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                return st;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteStudent(string id)
        {
            var cl = _dbContext.Students.FindAsync(id);
            if (cl != null)
            {
                _dbContext.Remove(cl);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<StudentModel>> GetStudent()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<StudentModel> GetStudentById(string id)
        {
            StudentModel cl = _dbContext.Students.SingleOrDefault(a => a.Student_Id.Equals(id));

            if (cl != null)
            {
                return cl;
            }

            return null;
        }

        public async Task<StudentModel> UpdateStudent(StudentModel student)
        {

            StudentModel cl = await _dbContext.Students.FindAsync(student.Student_Id);
            if (cl != null)
            {

                _dbContext.Entry(student).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return cl;
            }
            else
            {
                return null;

            }
        }
    }
}
        
