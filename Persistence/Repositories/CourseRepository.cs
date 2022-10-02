using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class CourseRepository : ICourseRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public CourseRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Course>> GetAllByStudentIdAsync(int studentId, CancellationToken cancellationToken = default) =>
            await _dbContext.Courses.Where(x => x.StudentId == studentId).ToListAsync(cancellationToken);

        public async Task<Course> GetByIdAsync(int courseId, CancellationToken cancellationToken = default) =>
            await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == courseId, cancellationToken);

        public void Insert(Course course) => _dbContext.Courses.Add(course);

        public void Remove(Course course) => _dbContext.Courses.Remove(course);
    }
}
