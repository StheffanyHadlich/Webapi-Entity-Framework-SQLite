using System;
using System.IO;
using Academic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Academic.Data
{
    public class AcademicContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Data/database.sqlite");
        }

        public static void InitDb(IServiceProvider serviceProvider)
        {
            const string path = "./Data/database.sqlite";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetRequiredService<AcademicContext>();
            dataContext.Database.EnsureCreated();

            Student a1;

            dataContext.Student.Add(a1 = new Student
            {
                name = "A",
                address = "Rua 1",
                email = "ex@j.c",
                telephone = "99999",
                city = new City
                {
                    name = "Guarapuava",
                    state = new State
                    {
                        name = "Parana"
                    }
                }
            });

            Classroom c1;

            dataContext.Classroom.Add(c1 = new Classroom
            {
                day = 2,
                classroom = "sala 2",
                vacancies = 12,
                subject = new Subjects
                {
                    name = "Portuguese",
                    workload = 20,
                    course = new Course
                    {
                        name = "Computação",
                        title = "Bacharelado"
                    }
                },
                professor = new Professor
                {
                    name = "Quinaia"
                }
            });

            dataContext.Enrollment.Add(new Enrollment {Hour = "14:00", student = a1, classroom = c1});
            
            dataContext.SaveChanges();
        }


    }
}