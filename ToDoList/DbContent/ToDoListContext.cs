using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DbContent
{
    public class ITasksDal: DbContext
    {
        public ITasksDal(DbContextOptions<ITasksDal> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            ////////////////////////////////////////////////////////////
            // Change content manually to add more Tasks //
            ////////////////////////////////////////////////////////////

            #region TasksSeed
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem {ID = 1, Name = "Test1", CreatedAt = DateTime.Now, Status = 0});
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem {ID = 2, Name = "Test2", CreatedAt = DateTime.Now, Status = 0 });
            #endregion
        }
    }
}
