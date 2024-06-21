using Models.DTO.Request;
using Models.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepo
{
    public interface ISchoolRepo
    {
        Task<List<SchoolRes>> GetAllSchools();
        Task<SchoolRes?> GetSchoolById(SchoolRequest schoolRequest);
        Task<int> SaveSchool(SaveSchoolsReq saveSchoolsReq);
        Task<bool> DeleteSchool(SchoolRequest schoolRequest);


    }
}
