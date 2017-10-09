using System;

namespace Academic.Models
{

    public class Enrollment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime dateEnrollment { get; set; } = DateTime.Now;
        public string Hour { get; set; } = "";
        public Student student { get; set; }
        public Classroom classroom { get; set; }
    }

}