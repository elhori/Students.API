using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/students/{studentId:int}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CoursesController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetCourses(int studentId, CancellationToken cancellationToken)
        {
            var coursesDto = await _serviceManager.CourseService.GetAllByStudentIdAsync(studentId, cancellationToken);

            return Ok(coursesDto);
        }

        [HttpGet("{courseId:int}")]
        public async Task<IActionResult> GetCourseById(int studentId, int courseId, CancellationToken cancellationToken)
        {
            var courseDto = await _serviceManager.CourseService.GetByIdAsync(studentId, courseId, cancellationToken);

            return Ok(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(int studentId, [FromBody] CourseDto dto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.CourseService.CreateAsync(studentId, dto, cancellationToken);

            return CreatedAtAction(nameof(GetCourseById), new { studentId = response.StudentId, courseId = response.Id }, response);
        }

        [HttpDelete("{courseId:int}")]
        public async Task<IActionResult> DeleteCourse(int studentId, int courseId, CancellationToken cancellationToken)
        {
            await _serviceManager.CourseService.DeleteAsync(studentId, courseId, cancellationToken);

            return NoContent();
        }
    }
}
