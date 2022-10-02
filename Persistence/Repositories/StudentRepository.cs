using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class StudentRepository : IStudentRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public StudentRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Students.Include(x => x.Courses).ToListAsync(cancellationToken);

        public async Task<Student> GetByIdAsync(int studentId, CancellationToken cancellationToken = default) =>
            await _dbContext.Students.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == studentId, cancellationToken);

        public void Insert(Student student) => _dbContext.Students.Add(student);

        public void Remove(Student student) => _dbContext.Students.Remove(student);
    }
}
