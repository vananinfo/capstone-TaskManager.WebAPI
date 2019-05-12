using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public class Tasks
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Task_Id { get; set; }
        [Required]
        public Int64? Parent_Id { get; set; }

        public string Task { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public int Priority { get; set; }

        public bool isEnded { get; set; }

        public virtual ParentTask ParentTask { get; set; }
    }
}
