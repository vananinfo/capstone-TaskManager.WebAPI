using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskManager.BusinessLayer;
using TaskManager.DataModel;
using TaskManager.Entities;


namespace TaskManager.WebApi.Controllers
{
    public class TaskManagerController : ApiController
    {
        public BusinessLogicLayer_TaskManager businessLayer_TaskManagerObj = new BusinessLogicLayer_TaskManager();

        [HttpPost]
        [Route("api/AddTask")]
        public int AddTaskDetails([FromBody] TaskDetailsDTO taskDetails)
        {
            Tasks tasks = new Tasks();
            tasks.Task = taskDetails.Task;
            tasks.Parent_Id = taskDetails.Parent_Id;
            tasks.Priority = taskDetails.Priority;
            tasks.Start_Date = taskDetails.Start_Date;
            tasks.End_Date = taskDetails.End_Date;
            return businessLayer_TaskManagerObj.AddTaskwithParent(tasks);
        }
        [HttpPost]
        [Route("api/EditTask")]
        public int UpdateTask([FromBody] TaskDetailsDTO taskDetails)
        {
            Tasks tasks = new Tasks();
            tasks.Task_Id =  taskDetails.Task_Id;
            tasks.Task = taskDetails.Task;
            tasks.Parent_Id = taskDetails.Parent_Id;
            tasks.Priority = taskDetails.Priority;
            tasks.Start_Date = taskDetails.Start_Date;
            tasks.End_Date = taskDetails.End_Date;
            return businessLayer_TaskManagerObj.UpdateTask(tasks);
        }


        [HttpGet]
        [Route("api/GetAllTasks")]
        public IHttpActionResult GetAllTasks()

        {
            return Ok(JsonConvert.SerializeObject(businessLayer_TaskManagerObj.GetAllTasks(), Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
                ));
        }
        [HttpGet]
        [Route("api/GetAllTaskDetails")]
        public IHttpActionResult GetAllTaskDetails()
        {
           
            List<TaskDetailsDTO> taskDetails = businessLayer_TaskManagerObj.GetAllTaskDetails().ToList<TaskDetailsDTO>();
            return Ok(taskDetails);
        }
        [HttpGet]
        [Route("api/GetAllParentTaskDetails")]
        public IHttpActionResult GetAllParentTaskDetails()
        {

            List<TaskDetailsDTO> taskDetails = businessLayer_TaskManagerObj.GetAllParentTaskDetails().ToList<TaskDetailsDTO>();
            return Ok(taskDetails);
        }
        [HttpGet]
        [Route("api/GetTaskByID/{taskid}")]
        public IHttpActionResult GetTaskByID(long taskId)
        {
            List<TaskDetailsDTO> taskDetails = businessLayer_TaskManagerObj.GetTaskByID(taskId).ToList<TaskDetailsDTO>();
            return Ok(taskDetails);
        }

       
        [HttpGet]
        [Route("api/EndTask/{taskid}")]
        public IHttpActionResult EndTask(int taskId)
        {            
            return Ok(businessLayer_TaskManagerObj.EndTask(taskId));
        }
    }
}
