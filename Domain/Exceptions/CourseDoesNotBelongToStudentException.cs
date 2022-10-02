namespace Domain.Exceptions
{
    public sealed class CourseDoesNotBelongToStudentException : BadRequestException
    {
        public CourseDoesNotBelongToStudentException(int studentId, int courseId)
            : base($"The course with the identifier {courseId} does not belong to the studnet with the identifier {studentId}")
        {
        }
    }
}
