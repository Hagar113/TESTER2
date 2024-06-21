using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Request
{
    public class SaveStudentsReq
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
    }
}
