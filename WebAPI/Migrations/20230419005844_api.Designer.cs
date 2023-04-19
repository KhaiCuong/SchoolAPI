﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230419005844_api")]
    partial class api
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelLib.Model.ClassModel", b =>
                {
                    b.Property<string>("Class_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Class_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Class_Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("ModelLib.Model.Course", b =>
                {
                    b.Property<string>("Class_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Subject_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Teacher_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Class_Id", "Subject_Id", "Teacher_Id");

                    b.HasIndex("Subject_Id");

                    b.HasIndex("Teacher_Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("ModelLib.Model.StudentModel", b =>
                {
                    b.Property<string>("Student_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Class_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Student_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Student_Id");

                    b.HasIndex("Class_Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ModelLib.Model.SubjectModels", b =>
                {
                    b.Property<string>("Subject_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Learn_time")
                        .HasColumnType("int");

                    b.Property<string>("Subject_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject_Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Subject_Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("ModelLib.Model.TeacherModel", b =>
                {
                    b.Property<string>("Teacher_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Teacher_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Teacher_Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("ModelLib.Model.Course", b =>
                {
                    b.HasOne("ModelLib.Model.ClassModel", "Class")
                        .WithMany("Courses")
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLib.Model.SubjectModels", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("Subject_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLib.Model.TeacherModel", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("Teacher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ModelLib.Model.StudentModel", b =>
                {
                    b.HasOne("ModelLib.Model.ClassModel", "Class")
                        .WithMany("Students")
                        .HasForeignKey("Class_Id");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("ModelLib.Model.ClassModel", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ModelLib.Model.SubjectModels", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ModelLib.Model.TeacherModel", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
