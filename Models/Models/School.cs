﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class School
    {
        public int Id { get; set; }
        public string name { get; set;}
        public List<Students> students { get; set; }
    }
}
