using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
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

        public ICollection<Course>? Courses { get; set; }
    }
}
