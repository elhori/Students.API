using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IStudentRepository> _lazyStudentRepository;
        private readonly Lazy<ICourseRepository> _lazyCourseRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyStudentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(dbContext));
            _lazyCourseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IStudentRepository StudentRepository => _lazyStudentRepository.Value;

        public ICourseRepository CourseRepository => _lazyCourseRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
