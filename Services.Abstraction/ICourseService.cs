using Contracts;

namespace Services.Abstraction
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllByStudentIdAsync(int studentId, CancellationToken cancellationToken = default);

        Task<CourseDto> GetByIdAsync(int studentId, int courseId, CancellationToken cancellationToken);

        Task<CourseDto> CreateAsync(int studentId, CourseDto dto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int studentId, int courseId, CancellationToken cancellationToken = default);
    }
}
