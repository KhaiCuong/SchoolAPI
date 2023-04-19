
using ModelLib.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLib.Model
{
    [Table("Class")]
    public class ClassModel
    {
        public ClassModel()
        {
            Courses = new HashSet<Course>();
            Students = new HashSet<StudentModel>();
        }
        [Key]
        public string Class_Id { get; set; }
        [Required]
        public string Class_Name { get; set; }
        [Range(1,50,ErrorMessage =("Quantity must be from 1 to 50"))]
        public int Quantity { get; set; }

        public string? img { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
        public virtual ICollection<StudentModel>? Students { get; set; }

    }
}
