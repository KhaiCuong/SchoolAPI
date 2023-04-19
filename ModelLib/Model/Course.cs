using ModelLib.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLib.Model
{
    [Table("Course")]
    public class Course
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Class_Id { get; set; }
        public string? Subject_Id { get; set; }
        public string? Teacher_Id { get; set; }

        public virtual ClassModel? Class { get; set; }
    
        public virtual SubjectModels? Subject { get; set; }
       
        public virtual TeacherModel? Teacher { get; set; }


    }
}
