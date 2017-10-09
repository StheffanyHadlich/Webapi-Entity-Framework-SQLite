using System;

namespace Academic.Models
{
    public class City
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string name { get; set; } = "";
        public State estate { get; set; }
    }
}