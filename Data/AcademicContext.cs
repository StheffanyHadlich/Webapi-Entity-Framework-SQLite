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

            dataContext.Alunos.Add(new Aluno{Nome = "João da Silva"});
            dataContext.SaveChanges();
        }
    }
}