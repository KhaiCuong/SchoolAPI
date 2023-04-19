using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModelLib.Model;
using WebAPI.Data;
using WebAPI.Repository;

namespace WebAPI.Service
{
    public class SubjectServiceImp : ISubjectRepository
    {
        private DatabaseContext _dbContext;
        public SubjectServiceImp(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }


        //SUBJECT
        public async Task<SubjectModels> AddSubject(SubjectModels subject)
        {
            var sj = _dbContext.Subjects.SingleOrDefault(a => a.Subject_Id.Equals(subject.Subject_Id));
            if (sj == null)
            {

                await _dbContext.Subjects.AddAsync(subject);
                await _dbContext.SaveChangesAsync();
                return sj;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteSubject(string id)
        {
            var cl = _dbContext.Subjects.FindAsync(id);
            if (cl != null)
            {
                _dbContext.Remove(cl);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<SubjectModels> GetSubjectById(string id)
        {
            SubjectModels cl = _dbContext.Subjects.SingleOrDefault(a => a.Subject_Id.Equals(id));

            if (cl != null)
            {
                return cl;
            }

            return null;
        }

        public async Task<IEnumerable<SubjectModels>> GetSubjects()
        {
            return await _dbContext.Subjects.ToListAsync();
        }

        public async Task<SubjectModels> UpdateSubject(SubjectModels subject)
        {
            SubjectModels cl = await _dbContext.Subjects.FindAsync(subject.Subject_Id);
            if (cl != null)
            {

                _dbContext.Entry(subject).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return cl;
            }
            else
            {
                return null;

            }
        }



        // COURSE 
        public async Task<Course> AddCourse(Course course)
        {
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync(); 
            return course;
        }

        public async Task<IEnumerable<Course>> GetCourse()
        {
            return await _dbContext.Courses.ToListAsync();
        }

        public async Task<Course> UpdateCourse(Course course)
        {
         
            Course sub = await _dbContext.Courses.FindAsync(course.Id);

            if (sub != null)
            {
               _dbContext.Entry(course).State = EntityState.Modified;
               await _dbContext.SaveChangesAsync();
               return course;

            }

            return null;
        }















        //public void AddCourse(Course course)
        //{
        //    _databaseContext.Courses.Add(course);
        //    _databaseContext.SaveChanges();
        //}

        //public void AddSubject(SubjectModels subject)
        //{
        //   _databaseContext.Subjects.Add(subject);
        //    _databaseContext.SaveChanges();
        //}






        //public void DeleteSubject(string id)
        //{
        //    var subject = _databaseContext.Subjects.Find(id);
        //    if (subject != null)
        //    {
        //        _databaseContext.Subjects.Remove(subject);
        //        _databaseContext.SaveChanges();
        //    }
        //}

        //public List<Course> GetCourse()
        //{
        //    var course = _databaseContext.Courses.ToList();
        //    return course;
        //}

        //public SubjectModels GetSubjectById(string id)
        //{
        //    var subject = _databaseContext.Subjects.Find(id);
        //    if(subject != null)
        //    {  return subject; }
        //    return null;
        //}



        //public List<SubjectModels> GetSubjects()
        //{
        //    var subject = _databaseContext.Subjects.ToList();
        //    return subject;
        //}

        //public void UpdateCourse(Course course)
        //{
        //    var sub = _databaseContext.Courses.Find(course.Id);
        //    if (sub != null)
        //    {
        //        _databaseContext.Entry(course).State = EntityState.Modified;
        //        _databaseContext.SaveChanges();
        //    }
        //}

        //public void UpdateSubject(SubjectModels subject)
        //{
        //    var sub = _databaseContext.Subjects.Find(subject.Subject_Id);
        //    if (sub != null)
        //    {
        //        _databaseContext.Entry(subject).State = EntityState.Modified;
        //        _databaseContext.SaveChanges();
        //    }
        //}


    }
}
