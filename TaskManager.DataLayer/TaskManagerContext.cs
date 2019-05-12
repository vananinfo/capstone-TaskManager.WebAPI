using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskManager.DataModel;
using TaskManager.Entities;


namespace TaskManager.DataLayer
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base("name=TaskManager_ConnectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            
        }

        public DbSet<ParentTask> Parenttask { get; set; }
        public DbSet<Tasks> Task { get; set; }

        public int AddTaskwithParent(Tasks tasks)
        {
            ParentTask ptask = new ParentTask();
           
            //if the task added is a parent task
            if (tasks.Task_Id != 0)
            {
                Tasks t = Task.Find(tasks.Task_Id);
                t.Parent_Id = tasks.Parent_Id;
                t.Task = tasks.Task;
                t.Priority = tasks.Priority;
                t.Start_Date = tasks.Start_Date;
                t.End_Date = tasks.End_Date;
                t.isEnded = false;
            }
            else { 

                if (tasks.Parent_Id == -1)
                    {

                        ptask.Parent_Task = tasks.Task;
                        Parenttask.Add(ptask);
                        this.SaveChanges();
                        tasks.Parent_Id = ptask.Parent_Id;
                    }
                Task.Add(tasks);
            }
            return this.SaveChanges();
        }

        public int UpdateTask(Tasks tasks)
        {
            if (tasks.Task_Id != 0)
            {
                Tasks t = Task.Find(tasks.Task_Id);
                t.Parent_Id = tasks.Parent_Id;
                t.Task = tasks.Task;
                t.Priority = tasks.Priority;
                t.Start_Date = tasks.Start_Date;
                t.End_Date = tasks.End_Date;
                t.isEnded = false;
                return this.SaveChanges();
            }
            else
                return 0;
        }

        public List<Tasks> GetAllTasks()
        {
            return Task.ToList<Tasks>();
        }

        public IQueryable<TaskDetailsDTO> GetAllTaskDetails()
        {
            var query = (from task in Task
                         join parenttask in Parenttask on task.Parent_Id equals parenttask.Parent_Id into details
                         from m in details.DefaultIfEmpty() 
                         select new TaskDetailsDTO
                         {
                             Task_Id = task.Task_Id,
                             Parent_Id = task.Parent_Id,
                             Task = task.Task,
                             Parent_Task = (m.Parent_Task != null ? m.Parent_Task : string.Empty),
                             Start_Date = task.Start_Date,
                             End_Date = task.End_Date,
                             Priority = task.Priority,
                             isEnded = task.isEnded
                         }).Where(x => x.isEnded == false).AsQueryable();
            return query;
        }

        public IQueryable<TaskDetailsDTO> GetAllParentTaskDetails()
        {
            var query = (from parenttask in Parenttask 
                         select new TaskDetailsDTO
                         {
                             Task_Id = parenttask.Parent_Id,
                             Task = parenttask.Parent_Task
                         }).AsQueryable();
            return query;
        }

        public List<TaskDetailsDTO> GetTask(Int64 taskId)
        {
            var query = (from task in Task
                         join parenttask in Parenttask on task.Parent_Id equals parenttask.Parent_Id into details
                         from m in details.DefaultIfEmpty()
                         select new TaskDetailsDTO
                         {
                             Task_Id = task.Task_Id,
                             Parent_Id = task.Parent_Id,
                             Task = task.Task,
                             Parent_Task = (m.Parent_Task!=null? m.Parent_Task : string.Empty),
                             Start_Date = task.Start_Date,
                             End_Date = task.End_Date,
                             Priority = task.Priority,
                             isEnded = task.isEnded
                         }).Where(x => x.Task_Id == taskId).AsQueryable();
            return query.ToList<TaskDetailsDTO>();
        }
        //public int RemoveTask(Int64 taskid)
        //{
        //    var query = (from task in Task
        //                 where task.Parent_Id == taskid
        //                 && task.Task_Id != taskid
        //                 select new
        //                 {
        //                     task_id = task.Task_Id
        //                 }
        //                 );
        //    if (query.ToList().Count > 0)
        //    {
        //        return 101;//Dependency exists as this task is referred as ParentId for another tasks
        //    }
        //    else
        //    {
        //        Parenttask.Remove(Parenttask.Find(taskid));
        //        Task.Remove(Task.Find(taskid));
        //        return this.SaveChanges();
        //    }
        //}
        public int EndTask(long taskId)
        {
            var query = (from task in Task
                         where task.Parent_Id == taskId
                         && (task.Task_Id != taskId && task.isEnded == false)
                         
                         select new
                         {
                             task_id = task.Task_Id
                         }
                         );
            if (query.ToList().Count > 0)
            {
                return 101;//Dependency exists as this task is referred as ParentId for another tasks
            }
            else
            {
                Tasks task = Task.Find(taskId);
                task.isEnded = true;
                return this.SaveChanges();
            }
        }
    }
    
}
