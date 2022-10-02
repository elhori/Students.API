using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstraction;
namespace Services
{
    internal sealed class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public StudentService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var students = await _repositoryManager.StudentRepository.GetAllAsync(cancellationToken);

            var studentsDto = students.Adapt<IEnumerable<StudentDto>>();

            return studentsDto;
        }

        public async Task<StudentDto> GetByIdAsync(int studentId, CancellationToken cancellationToken = default)
        {
            var student = await _repositoryManager.StudentRepository.GetByIdAsync(studentId, cancellationToken);

            if (student is null)
            {
                throw new StudentNotFoundException(studentId);
            }

            var studentDto = student.Adapt<StudentDto>();

            return studentDto;
        }

        public async Task<StudentDto> CreateAsync(StudentDto dto, CancellationToken cancellationToken = default)
        {
            var student = dto.Adapt<Student>();

            _repositoryManager.StudentRepository.Insert(student);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return student.Adapt<StudentDto>();
        }

        public async Task UpdateAsync(int studentId, StudentDto dto, CancellationToken cancellationToken = default)
        {
            var student = await _repositoryManager.StudentRepository.GetByIdAsync(studentId, cancellationToken);

            if (student is null)
            {
                throw new StudentNotFoundException(studentId);
            }

            student.Name = dto.Name;
            student.Number = dto.Number;
            student.NationalId = dto.NationalId;
            student.Nationality = dto.Nationality;
            student.BirthDate = dto.BirthDate;
            student.Gender = dto.Gender;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int studentId, CancellationToken cancellationToken = default)
        {
            var student = await _repositoryManager.StudentRepository.GetByIdAsync(studentId, cancellationToken);

            if (student is null)
            {
                throw new StudentNotFoundException(studentId);
            }

            _repositoryManager.StudentRepository.Remove(student);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
