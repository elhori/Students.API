using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstraction;

namespace Services
{
    internal sealed class CourseService : ICourseService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CourseService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<CourseDto>> GetAllByStudentIdAsync(int courseId, CancellationToken cancellationToken = default)
        {
            var course = await _repositoryManager.CourseRepository.GetAllByStudentIdAsync(courseId, cancellationToken);

            var courseDtos = course.Adapt<IEnumerable<CourseDto>>();

            return courseDtos;
        }

        public async Task<CourseDto> GetByIdAsync(int studentId, int courseId, CancellationToken cancellationToken)
        {
            var student = await _repositoryManager.StudentRepository.GetByIdAsync(studentId, cancellationToken);

            if (student is null)
            {
                throw new StudentNotFoundException(studentId);
            }

            var course = await _repositoryManager.CourseRepository.GetByIdAsync(courseId, cancellationToken);

            if (course is null)
            {
                throw new CourseNotFoundException(courseId);
            }

            if (course.StudentId != student.Id)
            {
                throw new CourseDoesNotBelongToStudentException(student.Id, course.Id);
            }

            var courseDto = course.Adapt<CourseDto>();

            return courseDto;
        }

        public async Task<CourseDto> CreateAsync(int studentId, CourseDto dto, CancellationToken cancellationToken = default)
        {
            var student = await _repositoryManager.StudentRepository.GetByIdAsync(studentId, cancellationToken);

            if (student is null)
            {
                throw new StudentNotFoundException(studentId);
            }

            var course = dto.Adapt<Course>();

            course.StudentId = student.Id;

            _repositoryManager.CourseRepository.Insert(course);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return course.Adapt<CourseDto>();
        }

        public async Task DeleteAsync(int studentId, int courseId, CancellationToken cancellationToken = default)
        {
            var student = await _repositoryManager.StudentRepository.GetByIdAsync(studentId, cancellationToken);

            if (student is null)
            {
                throw new StudentNotFoundException(studentId);
            }

            var course = await _repositoryManager.CourseRepository.GetByIdAsync(courseId, cancellationToken);

            if (course is null)
            {
                throw new CourseNotFoundException(courseId);
            }

            if (course.StudentId != student.Id)
            {
                throw new CourseDoesNotBelongToStudentException(student.Id, course.Id);
            }

            _repositoryManager.CourseRepository.Remove(course);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
