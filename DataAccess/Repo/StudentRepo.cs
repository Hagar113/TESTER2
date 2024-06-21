using DataAccess.ApplicationContext;
using DataAccess.IRepo;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.Models;

namespace DataAccess.Repo
{
    public class StudentRepo:IStudentRepo
    {
        private readonly ApplicationDBContext _dbContext;
        public StudentRepo(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        #region Schools_Methods
        
        public async Task<List<StudentRes>> GetAllStudents()
        {
            try
            {
                List<StudentRes> studentResponses = new List<StudentRes>();
                var students = await _dbContext.students.ToListAsync();
                if (students != null)
                {
                    foreach (var student in students)
                    {
                        studentResponses.Add(new StudentRes
                        {
                            id = student.id,
                            Name = student.Name,
                            age=student.age,

                        });
                    }
                    return studentResponses;
                }
                else
                {
                    return studentResponses;
                }

            }
            catch { return new List<StudentRes>(); }
        }

        public async Task<StudentRes> GetStudentById(StudentReq Request)
        {
            try
            {
                StudentRes res = new StudentRes();
                var student = await _dbContext.students.Where(z => z.id == Request.id).FirstOrDefaultAsync();
                if (student != null)
                {
                    res.id = student.id;
                    res.Name = student.Name;
                    res.age=student.age;
                    return res;
                }
                else
                {
                    return null;
                }

            }
            catch { return null; }
        }

        
        public async Task<int> SaveStudent(SaveStudentsReq saveStudentsReq)
        {
            try
            {
                if (saveStudentsReq.id == null || saveStudentsReq.id <= 0)
                {
                    return await AddStudent(saveStudentsReq);
                }
                else
                {
                    return await EditStudent(saveStudentsReq);
                }
            }
            catch (Exception ex) { return -1; }
        }


        

        public async Task<bool> DeleteStudent(StudentReq Request)
        {
            try
            {
                var student = await _dbContext.students.FindAsync(Request.id);

                if (student != null)
                {
                    _dbContext.Remove(student);
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


        #region StudentsMethods
        private async Task<int> AddStudent(SaveStudentsReq saveStudentsReq)
        {
            try
            {
                Students students = new Students();
                students.Name = saveStudentsReq.Name;
                students.age = saveStudentsReq.age;


                await _dbContext.students.AddAsync(students);
                await _dbContext.SaveChangesAsync();
                return 1;


            }
            catch { return -1; }
        }
        private async Task<int> EditStudent(SaveStudentsReq saveStudentsReq)
        {
            try
            {
                var Student = await _dbContext.students
                                    .Where(h => h.id == saveStudentsReq.id)
                                    .FirstOrDefaultAsync();
                if (Student != null)
                {
                    Student.Name = saveStudentsReq.Name;
                    Student.age = saveStudentsReq.age;

                    _dbContext.Entry(Student).State = EntityState.Modified;
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


        #endregion
    }
}
