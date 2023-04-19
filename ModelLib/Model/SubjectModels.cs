using ModelLib.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace ModelLib.Model
{ 
    [Table("Subject")]
    public class SubjectModels
    {
        public SubjectModels()
        {
            Courses = new HashSet<Course>();
       
        }

        [Key]
        public string Subject_Id { get; set; }
        [Required]
        public string Subject_Name { get; set; }
        [Required]
        public int Learn_time { get; set; }
        public string? Subject_Photo { get; set; }


        public virtual ICollection<Course>? Courses { get; set; }


    }
}
