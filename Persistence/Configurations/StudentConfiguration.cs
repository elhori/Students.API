using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed partial class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Number).IsRequired();

            builder.Property(s => s.Name).HasMaxLength(50).IsRequired();

            builder.Property(s => s.BirthDate).IsRequired();

            builder.Property(s => s.Gender).IsRequired();

            builder.Property(s => s.Nationality).IsRequired();

            builder.Property(s => s.NationalId).IsRequired();

            builder.HasMany(c => c.Courses)
                .WithOne(s => s.Student)
                .HasForeignKey(c => c.StudentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
