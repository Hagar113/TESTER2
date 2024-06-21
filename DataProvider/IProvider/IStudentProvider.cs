using DataAccess.IRepo;

namespace DataProvider.IProvider
{
    public interface IStudentProvider
    {
        public IStudentRepo studentRepo {  get;  }
    }
}
