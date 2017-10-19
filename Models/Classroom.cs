using System;

namespace Academic.Models
{

    public class Classroom
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int day { get; set; } = 0;
        public string classroom { get; set; } = "";
        public int vacancies { get; set; } = 0;
        public Subjects subject { get; set; }
        public Professor professor {get; set;} 
        
    }

}