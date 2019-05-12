using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.DataModel;
using TaskManager.Entities;

namespace TaskManager.DataLayer
{
    public class DataAccessLayer_TaskManager
    {
        TaskManagerContext context = new TaskManagerContext();
        public int AddTaskwithParent(Tasks tasks)
        {
            return context.AddTaskwithParent(tasks);
        }
        public int UpdateTask(Tasks tasks)
        {
            return context.UpdateTask(tasks);
        }
        public List<Tasks> GetAllTasks()
        {
            return context.GetAllTasks();
        }

        public IQueryable<TaskDetailsDTO> GetAllTaskDetails()
        {
            return context.GetAllTaskDetails();
        }

        public IQueryable<TaskDetailsDTO> GetAllParentTaskDetails()
        {
            return context.GetAllParentTaskDetails();
        }

        public List<TaskDetailsDTO> GetTask(Int64 taskid)
        {
            return context.GetTask(taskid);
        }

        //public int RemoveTask(Int64 taskid)
        //{
        //    return context.RemoveTask(taskid);
        //}

        public int EndTask(long taskId)
        {
            return context.EndTask(taskId);
        }
    }
}
