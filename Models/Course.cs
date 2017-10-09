using System;

namespace Academic.Models
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string name { get; set; } = "";
        public string title {get; set;} = "";
    }    

   
}