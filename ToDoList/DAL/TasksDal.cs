using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.DbContent;
using ToDoList.Interfaces;
using ToDoList.Models;

namespace ToDoList.DAL
{
    public class TasksDal : Interfaces.ITasksDal
    {
        private readonly DbContent.ITasksDal _toDoListContext;

        #region Constuctor
        public TasksDal(DbContent.ITasksDal toDoListContext)
        {
            _toDoListContext = toDoListContext;
        }

        public void AddTask(TaskItem taskItem)
        {
            _toDoListContext.Add(taskItem);
            _toDoListContext.SaveChanges();
        }

        public void DeleteTaskById(int id)
        {
            var taskToDelete = _toDoListContext.Tasks.Single(x => x.ID == id);
            _toDoListContext.Tasks.Remove(taskToDelete);
            _toDoListContext.SaveChanges();
        }
        #endregion

        #region Public Methods
        public List<TaskItem> GetAllTasks()
        {
            return _toDoListContext.Tasks.ToList();
        }

        public void UpdateTaskById(int id)
        {
            var taskToUpdate = _toDoListContext.Tasks.Single(x => x.ID == id);
            taskToUpdate.Status = 1;
            _toDoListContext.Entry(taskToUpdate).CurrentValues.SetValues(taskToUpdate);
            _toDoListContext.SaveChanges();
        }
        #endregion
    }
}
