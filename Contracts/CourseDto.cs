using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class CourseDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "رمز المادة")]
        public string CourseCode { get; set; }

        [Display(Name = "اسم المادة")]
        public string Name { get; set; }

        public int StudentId { get; set; }
    }
}
