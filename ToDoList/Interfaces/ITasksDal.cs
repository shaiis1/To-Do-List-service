using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Interfaces
{
    public interface ITasksDal
    {
        List<TaskItem> GetAllTasks();

        void DeleteTaskById(int id);

        void AddTask(TaskItem taskItem);

        void UpdateTaskById(int id);
    }
}
