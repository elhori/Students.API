namespace Domain.Exceptions
{
    public sealed class StudentNotFoundException : NotFoundException
    {
        public StudentNotFoundException(int studentId)
            : base($"The student with the identifier {studentId} was not found.")
        {
        }
    }
}
