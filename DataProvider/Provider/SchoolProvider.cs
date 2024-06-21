using DataAccess.ApplicationContext;
using DataAccess.IRepo;
using DataAccess.Repo;
using DataProvider.IProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Provider
{
    
        public class SchoolProvider : ISchoolProvider
        {
            private readonly ApplicationDBContext dBContext;
            public SchoolProvider(ApplicationDBContext context)
            {
                dBContext = context;
                schoolRepo =new SchoolRepo(dBContext);
            }
            public ISchoolRepo schoolRepo { get; private set; }
        }
    
}
