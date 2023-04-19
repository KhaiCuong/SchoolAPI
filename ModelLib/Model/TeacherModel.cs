using ModelLib.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLib.Model
{ 
    [Table("Teacher")]
    public class TeacherModel
    {

        public TeacherModel()
        {
            Courses = new HashSet<Course>();

        }

        [Key]
        public string Teacher_Id { get; set; }
        [Required]
        public string Teacher_Name { get; set; }
        public string Teacher_Email { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }
    }
}
