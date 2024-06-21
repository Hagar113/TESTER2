using DataAccess;
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
    public class StudentProvider : IStudentProvider
    {
        private readonly ApplicationDBContext dBContext;
        public StudentProvider(ApplicationDBContext context)
        {
            dBContext = context;
            studentRepo=new StudentRepo(dBContext);
        }
        public IStudentRepo studentRepo {  get; private set; }
    }
}
