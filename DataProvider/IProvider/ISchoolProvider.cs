﻿using DataAccess.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.IProvider
{
    public interface ISchoolProvider
    {
        public ISchoolRepo schoolRepo { get; }
    }
}
