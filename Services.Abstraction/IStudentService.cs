using Contracts;

namespace Services.Abstraction
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<StudentDto> GetByIdAsync(int studentId, CancellationToken cancellationToken = default);

        Task<StudentDto> CreateAsync(StudentDto dto, CancellationToken cancellationToken = default);

        Task UpdateAsync(int studentId, StudentDto dto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int studentId, CancellationToken cancellationToken = default);
    }
}
