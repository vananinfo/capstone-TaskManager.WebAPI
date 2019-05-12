using System;

namespace TaskManager.DataModel
{
    public class TaskDetailsDTO
    {
        public Int64 Task_Id { get; set; }

        public Int64? Parent_Id { get; set; }

        public string Task { get; set; }
        public string Parent_Task { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public int Priority { get; set; }
        public bool isEnded { get; set; }
    }
}
