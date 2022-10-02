namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IStudentRepository StudentRepository { get; }

        ICourseRepository CourseRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
