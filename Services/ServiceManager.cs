using Domain.Repositories;
using Services.Abstraction;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStudentService> _lazyStudentService;
        private readonly Lazy<ICourseService> _lazyCourseService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyStudentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager));
            _lazyCourseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager));
        }

        public IStudentService StudentService => _lazyStudentService.Value;

        public ICourseService CourseService => _lazyCourseService.Value;
    }
}
