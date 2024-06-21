using DataAccess.ApplicationContext;
using DataAccess.IRepo;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Models;

namespace DataAccess.Repo
{
    internal class SchoolRepo:ISchoolRepo
    {
        private readonly ApplicationDBContext _dbContext;
        public SchoolRepo(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        #region Schools_Methods
        
        public async Task<List<SchoolRes>> GetAllSchools()
        {
            try
            {
                List<SchoolRes> schoolResponses = new List<SchoolRes>();
                var schools = await _dbContext.schools.ToListAsync();
                if (schools != null)
                {
                    foreach (var school in schools)
                    {
                        schoolResponses.Add(new SchoolRes
                        {
                            id = school.Id,
                            name = school.name,

                        });
                    }
                    return schoolResponses;
                }
                else
                {
                    return schoolResponses;
                }

            }
            catch { return new List<SchoolRes>(); }
        }

        public async Task<SchoolRes?> GetSchoolById(SchoolRequest schoolRequest)
        {
            try
            {
                SchoolRes res = new SchoolRes();
                var school = await _dbContext.schools.Where(H => H.Id == schoolRequest.schoolId).FirstOrDefaultAsync();
                if (school != null)
                {
                    res.id = school.Id;
                    res.name = school.name;
                    return res;
                }
                else
                {
                    return null;
                }

            }
            catch { return null; }
        }

        
        public async Task<int> SaveSchool(SaveSchoolsReq saveSchoolsReq)
        {
            try
            {
                if (saveSchoolsReq.id == null || saveSchoolsReq.id <= 0)
                {
                    return await AddSchool(saveSchoolsReq);
                }
                else
                {
                    return await EditSchool(saveSchoolsReq);
                }
            }
            catch (Exception ex) { return -1; }
        }


      

        public async Task<bool> DeleteSchool(SchoolRequest schoolRequest)
        {
            try
            {
                var school = await _dbContext.schools.FindAsync(schoolRequest.schoolId);

                if (school != null)
                {
                    _dbContext.Remove(school);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex) { return false; }
        }
        #endregion


        private async Task<int> AddSchool(SaveSchoolsReq saveSchoolsReq)
        {
            try
            {
                School schools = new School();
                schools.name = saveSchoolsReq.name;


                await _dbContext.schools.AddAsync(schools);
                await _dbContext.SaveChangesAsync();
                return 1;


            }
            catch { return -1; }
        }
        private async Task<int> EditSchool(SaveSchoolsReq saveSchoolsReq)
        {
            try
            {
                var School = await _dbContext.schools
                                    .Where(h => h.Id == saveSchoolsReq.id)
                                    .FirstOrDefaultAsync();
                if (School != null)
                {
                    School.name = saveSchoolsReq.name;

                    _dbContext.Entry(School).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    return -2;
                }
            }
            catch { return -1; }
        }

    }
}
