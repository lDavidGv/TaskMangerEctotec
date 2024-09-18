using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;


namespace TaskManager.Models
{
    public class TaskMContext : DbContext
    {

 

        public TaskMContext()
            : base("name=TaskManegerContext")
        {

        }
        public DbSet<Tareas> Tareas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer<TaskMContext>(null);

            modelBuilder.Entity<Tareas>()
            .Property(e => e.Id)
            .IsRequired();
        }


    }
}