using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLib.Model;
using WebAPI.Data;
using WebAPI.Repository;

namespace WebAPI.Service
{
    public class CourseImpService : ICourseRepository
    {

        private DatabaseContext _dbContext;

        public CourseImpService(DatabaseContext context)
        {
            _dbContext = context;
        }

        public Task<Course> AddCourse(Course course)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Course>> GetCourse()
        {
            return await _dbContext.Courses.ToListAsync();
        }

        public Task<Course> UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

    
    }
}
