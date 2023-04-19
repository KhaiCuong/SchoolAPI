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
        public CLassImpService(DatabaseContext context)
        {
           _dbContext = context;
        }

        public async Task<ClassModel> AddClassModel(ClassModel classmodel)
        {
            var Class = _dbContext.Classes.SingleOrDefault(a => a.Class_Id.Equals(classmodel.Class_Id));
            if (Class == null)
            {
                
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
            var cl = _dbContext.Classes.FindAsync(Class_Id);
            if (cl != null)
            {
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

        public async Task<ClassModel> UpdateClassModel(ClassModel updateClass)
        {
            ClassModel cl = await _dbContext.Classes.FindAsync(updateClass.Class_Id);
            if (cl != null)
            {
                
                _dbContext.Entry(updateClass).State = EntityState.Modified;
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
