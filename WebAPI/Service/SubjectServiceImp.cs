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
        private readonly string _uploadFolder;
        public SubjectServiceImp(DatabaseContext databaseContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = databaseContext;
            _uploadFolder = Path.Combine(webHostEnvironment.ContentRootPath, "uploads");

        }


        //SUBJECT
        public async Task<SubjectModels> AddSubject(SubjectModels subject, IFormFile photo)
        {
            var sj = _dbContext.Subjects.SingleOrDefault(a => a.Subject_Id.Equals(subject.Subject_Id));
            if (sj == null)
            {
                if (photo != null && photo.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                    string filePath = Path.Combine(_uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }

                    subject.Subject_Photo = "/uploads/" + fileName;
                }

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
            SubjectModels cl = await _dbContext.Subjects.FindAsync(id);
            if (cl != null)
            {
                if (!string.IsNullOrEmpty(cl.Subject_Id))
                {
                    string filePath = Path.Combine(_uploadFolder, cl.Subject_Id);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
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

        public async Task<SubjectModels> UpdateSubject(SubjectModels subject, IFormFile photo)
        {
            SubjectModels cl = await _dbContext.Subjects.FindAsync(subject.Subject_Id);
            if (photo != null && photo.Length > 0)
            {
                if (!string.IsNullOrEmpty(cl.Subject_Photo))
                {
                    string filePathUpdate = Path.Combine(_uploadFolder, cl.Subject_Photo);
                    if (File.Exists(filePathUpdate))
                    {
                        File.Delete(filePathUpdate);
                    }
                }
                // generate new unique file name 
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                string filePath = Path.Combine(_uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                subject.Subject_Photo = "/uploads/" + fileName;

                _dbContext.Entry(subject).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return subject;
            }
            else
            {
                subject.Subject_Photo = cl.Subject_Photo;
                _dbContext.Entry(subject).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return subject;
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
