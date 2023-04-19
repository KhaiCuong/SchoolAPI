    using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using ModelLib.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace WebAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Course>()
            .HasKey(oi => new { oi.Class_Id, oi.Subject_Id, oi.Teacher_Id });

            modelBuilder.Entity<Course>()
                .HasOne(oi => oi.Class)
                .WithMany(o => o.Courses)
                .HasForeignKey(oi => oi.Class_Id);

            modelBuilder.Entity<Course>()
                .HasOne(oi => oi.Subject)
                .WithMany(p => p.Courses)
                .HasForeignKey(p => p.Subject_Id);


            modelBuilder.Entity<Course>()
                .HasOne(oi => oi.Teacher)
                .WithMany(p => p.Courses)
                .HasForeignKey(p => p.Teacher_Id);


            modelBuilder.Entity<StudentModel>()
                 .HasOne(o => o.Class)
                 .WithMany(c => c.Students)
                 .HasForeignKey(o => o.Class_Id);


       
        }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<SubjectModels> Subjects { get; set; }
        public DbSet<ClassModel> Classes { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
