using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public StudentsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetStudents(CancellationToken cancellationToken)
        {
            var students = await _serviceManager.StudentService.GetAllAsync(cancellationToken);

            return Ok(students);
        }

        [HttpGet("{studentId:int}")]
        public async Task<IActionResult> GetStudentById(int studentId, CancellationToken cancellationToken)
        {
            var studentDto = await _serviceManager.StudentService.GetByIdAsync(studentId, cancellationToken);

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto dto)
        {
            var studentDto = await _serviceManager.StudentService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetStudentById), new { studentId = studentDto.Id }, studentDto);
        }

        [HttpPut("{studentId:int}")]
        public async Task<IActionResult> UpdateOwner(int studentId, [FromBody] StudentDto dto, CancellationToken cancellationToken)
        {
            await _serviceManager.StudentService.UpdateAsync(studentId, dto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{studentId:int}")]
        public async Task<IActionResult> DeleteOwner(int studentId, CancellationToken cancellationToken)
        {
            await _serviceManager.StudentService.DeleteAsync(studentId, cancellationToken);

            return NoContent();
        }
    }
}
