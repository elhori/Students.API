namespace Services.Abstraction
{
    public interface IServiceManager
    {
        IStudentService StudentService { get; }

        ICourseService CourseService { get; }
    }
}
