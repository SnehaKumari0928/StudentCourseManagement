using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class Student
    {

        public int StudentId { get; set; }

        public int UserId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public User User { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
