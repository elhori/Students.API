using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Student> GetByIdAsync(int studentId, CancellationToken cancellationToken = default);
        void Insert(Student student);
        void Remove(Student student);
    }
}
