using System;

namespace Academic.Models
{

 public class State
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string name { get; set; } = "";
    }
}