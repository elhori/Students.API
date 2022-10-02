using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "رمز المادة")]
        public string CourseCode { get; set; }

        [Display(Name = "اسم المادة")]
        public string Name { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
