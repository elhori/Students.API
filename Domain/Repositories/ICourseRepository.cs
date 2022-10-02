using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllByStudentIdAsync(int studentId, CancellationToken cancellationToken = default);
        Task<Course> GetByIdAsync(int courseId, CancellationToken cancellationToken = default);
        void Insert(Course course);
        void Remove(Course course);
    }
}
