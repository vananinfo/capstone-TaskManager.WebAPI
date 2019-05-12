using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public class ParentTask
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Parent_Id { get; set; }
        public string Parent_Task { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
