using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Security.Principal;
using ModelLib.Model;
using WebAPI.Repository;
using WebAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Service
{
    public class CLassImpService : IClassRepository
    {   
        private DatabaseContext _dbContext;
        private readonly string _uploadFolder;

        public CLassImpService(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
           _dbContext = context;
            _uploadFolder = Path.Combine(webHostEnvironment.ContentRootPath, "uploads");
        }

        public async Task<ClassModel> AddClassModel(ClassModel classmodel, IFormFile photo)
        {
            var Class = _dbContext.Classes.SingleOrDefault(a => a.Class_Id.Equals(classmodel.Class_Id));
            if (Class == null)
            {
                if (photo != null && photo.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                    string filePath = Path.Combine(_uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }

                    classmodel.img = "/uploads/" + fileName;
                }
                await _dbContext.Classes.AddAsync(classmodel);
                await _dbContext.SaveChangesAsync();
                return Class;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteClassModel(string Class_Id)
        {
            ClassModel cl = await _dbContext.Classes.FindAsync(Class_Id);
            if (cl != null)
            {
                if (!string.IsNullOrEmpty(cl.img))
                {
                    string filePath = Path.Combine(_uploadFolder, cl.img);
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

        public async Task<ClassModel> GetClassById(string classId)
        {
            ClassModel cl = _dbContext.Classes.SingleOrDefault(a => a.Class_Id.Equals(classId));

            if (cl != null)
            {
                return cl;
            }

            return null;
        }

        public async Task<IEnumerable<ClassModel>> GetClasss()
        {
            return await _dbContext.Classes.ToListAsync();

        }

        public async Task<ClassModel> UpdateClassModel(ClassModel updateClass, IFormFile photo)
        {
            ClassModel cl = await _dbContext.Classes.FindAsync(updateClass.Class_Id);

            if (photo != null && photo.Length > 0)
            {
                if (!string.IsNullOrEmpty(cl.img))
                {
                    string filePathUpdate = Path.Combine(_uploadFolder, cl.img);
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

                updateClass.img = "/uploads/" + fileName;

                _dbContext.Entry(updateClass).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return updateClass;
            }
            else
            {
                updateClass.img = cl.img;
                _dbContext.Entry(updateClass).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return updateClass;
            }
        }
    }
}
