using System;

namespace Academic.Models
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string name { get; set; } = "";
        public string address { get; set; } = "";
        public string email { get; set; } = "";
        public string telephone { get; set;} = "";
        public City city { get; set; }
    
    }

}