using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class StudentDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم الطالب")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "رقم الطالب")]
        public int Number { get; set; }

        [Required]
        [Display(Name = "الرقم الوطني")]
        public int NationalId { get; set; }

        [Required]
        [Display(Name = "الجنسية")]
        public string Nationality { get; set; }

        [Required]
        [Display(Name = "تاريخ الميلاد")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "الجنس")]
        public string Gender { get; set; }

        public ICollection<CourseDto> Courses { get; set; }
    }
}
