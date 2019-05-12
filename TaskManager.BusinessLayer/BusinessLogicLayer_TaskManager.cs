using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataLayer;
using TaskManager.Entities;
using TaskManager.DataModel;

namespace TaskManager.BusinessLayer
{
    public class BusinessLogicLayer_TaskManager
    {
        public DataAccessLayer_TaskManager dataLayer_TaskManagerObj = new DataAccessLayer_TaskManager();
        public int AddTaskwithParent(Tasks tasks)
        {
            return dataLayer_TaskManagerObj.AddTaskwithParent(tasks);
        }
        public int UpdateTask(Tasks tasks)
        {
            return dataLayer_TaskManagerObj.UpdateTask(tasks);
        }
        public List<Tasks> GetAllTasks()
        {
            return dataLayer_TaskManagerObj.GetAllTasks();
        }
        public IQueryable<TaskDetailsDTO> GetAllTaskDetails()
        {
            return dataLayer_TaskManagerObj.GetAllTaskDetails();
        }
        public IQueryable<TaskDetailsDTO> GetAllParentTaskDetails()
        {
            return dataLayer_TaskManagerObj.GetAllParentTaskDetails();
        }
        public List<TaskDetailsDTO> GetTaskByID(Int64 taskid)
        {
            return dataLayer_TaskManagerObj.GetTask(taskid);
        }
        //public int RemoveTask(Int64 taskid)
        //{
        //    return dataLayer_TaskManagerObj.RemoveTask(taskid);
        //}
        public int EndTask(long taskId)
        {
            return dataLayer_TaskManagerObj.EndTask(taskId);
        }
    }
}
