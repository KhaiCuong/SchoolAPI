using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLib.Model;
using WebAPI.Repository;
using System.Security.Claims;
using WebAPI.Data;

namespace WebAPI.Service
{
    public class TeacherImpService : ITeacherRepository
    {

        private DatabaseContext _dbContext;
        public TeacherImpService(DatabaseContext context)
        {
            _dbContext = context;
        }

        public async Task<TeacherModel> AddTeacherModel(TeacherModel Teacher)
        {
            var sj = _dbContext.Teachers.SingleOrDefault(a => a.Teacher_Id.Equals(Teacher.Teacher_Id));
            if (sj == null)
            {

                await _dbContext.Teachers.AddAsync(Teacher);
                await _dbContext.SaveChangesAsync();
                return sj;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteTeacherModel(string Teacher_Id)
        {
            var cl = _dbContext.Teachers.FindAsync(Teacher_Id);
            if (cl != null)
            {
                _dbContext.Remove(cl);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

     

        public async Task<TeacherModel> GetTeacherById(string Teacher_Id)
        {

            TeacherModel cl = _dbContext.Teachers.SingleOrDefault(a => a.Teacher_Id.Equals(Teacher_Id));

            if (cl != null)
            {
                return cl;
            }

            return null;
        }

        public async Task<IEnumerable<TeacherModel>> GetTeachers()
        {
            return await _dbContext.Teachers.ToListAsync();
        }

        public async Task<TeacherModel> UpdateTeacherModel(TeacherModel updateTeacher)
        {
            TeacherModel cl = await _dbContext.Teachers.FindAsync(updateTeacher.Teacher_Id);
            if (cl != null)
            {

                _dbContext.Entry(updateTeacher).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return cl;
            }
            else
            {
                return null;

            }
        }




        // COURSE 
        public async Task<IEnumerable<Course>> GetCourse()
        {
            return await _dbContext.Courses.ToListAsync();
        }


        //public void AddTeacherModel(TeacherModel Teacher)
        //{
        //    _dbContext.Teachers.Add(Teacher);
        //    _dbContext.SaveChanges();
        //}

        //public void DeleteTeacherModel(string Teacher_Id)
        //{
        //    var cl = _dbContext.Classes.Find(Teacher_Id);
        //    if (cl != null)
        //    {
        //        _dbContext.Remove(cl);
        //        _dbContext.SaveChanges();
        //    }
        //}

        //public List<Course> GetCourse()
        //{
        //    var course = _dbContext.Courses.ToList();
        //    return course;
        //}

        //public TeacherModel GetTeacherById(string Teacher_Id)
        //{
        //    var subject = _dbContext.Teachers.Find(Teacher_Id);
        //    if (subject != null)
        //    { return subject; }
        //    return null;
        //}

        //public List<TeacherModel> GetTeachers()
        //{
        //    var subject = _dbContext.Teachers.ToList();
        //    return subject;
        //}


        //public void UpdateTeacherModel(TeacherModel updateTeacher)
        //{
        //    var sub = _dbContext.Subjects.Find(updateTeacher.Teacher_Id);
        //    if (sub != null)
        //    {
        //        _dbContext.Entry(updateTeacher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        _dbContext.SaveChanges();
        //    }
        //}
    }
}
