using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Repository;
using WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration
   .GetConnectionString("ConnectDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


builder.Services.AddScoped<IClassRepository, CLassImpService>();
builder.Services.AddScoped<ICourseRepository, CourseImpService>();
builder.Services.AddScoped<IStudentRepository, StudentServiceImp>();
builder.Services.AddScoped<ISubjectRepository, SubjectServiceImp>();
builder.Services.AddScoped<ITeacherRepository, TeacherImpService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
