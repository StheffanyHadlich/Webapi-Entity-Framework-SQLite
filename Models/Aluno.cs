using System;

namespace Academic.Models
{
    public class Aluno
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = "";
    }
}