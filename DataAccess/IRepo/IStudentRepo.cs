using Models.DTOs.Request;
using Models.DTOs.Response;

namespace DataAccess.IRepo
{
    public interface IStudentRepo
    {
        #region Students
        Task<List<StudentRes>> GetAllStudents();
        Task<StudentRes> GetStudentById(StudentReq Request);
        Task<int> SaveStudent(SaveStudentsReq saveStudentsReq);
        Task<bool> DeleteStudent(StudentReq Request);


        #endregion
    }

}
