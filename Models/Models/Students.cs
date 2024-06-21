using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Students
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int age{ get; set; }
        [ForeignKey("school")]
        public int schoolId { get; set;}
        public School schools { get; set; }
    }
}
