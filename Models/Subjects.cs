using System;

namespace Academic.Models
{
    public class Subjects
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string name { get; set; } = "";
        public int workload {get ; set;} = 0;
        public Course course { get; set; } 
    }


}